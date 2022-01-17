using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.Schedule.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.Schedule.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HospitalLibrary.Model;
using HospitalLibrary.Shared.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Patient")]
    public class AppointmentController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IVisitService _visitService;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public AppointmentController(HospitalDbContext context, IVisitService visitService, IMapper mapper, IDoctorService doctorService)
        {
            _context = context;
            _visitService = visitService;
            _mapper = mapper;
            _doctorService = doctorService;
        }

       
        [Authorize]
        [HttpGet("{username}")]
        public ActionResult<IEnumerable<Visit>> GetVisitsByUsername(string username)
        {
            return _visitService.GetVisitsByUsername(username);
        }

        [HttpGet("{username}/appointmentYearly")]
        public ActionResult<AppointmentCount> GetVisitsCountYearly(string username)
        {
            return _visitService.GetVisitsCountYearly(username);
        }

        [HttpGet("{username}/patientYearly")]
        public ActionResult<AppointmentCount> GetPatientsCountYearly(string username)
        {
            return _visitService.GetPatientsCountYearly(username);
        }


        [HttpGet("{username}/appointmentMonthly")]
        public ActionResult<AppointmentCount> GetVisitsCountMonthly(string username)
        {
            return _visitService.GetVisitsCountMonthly(username);
        }

        [HttpGet("{username}/patientMonthly")]
        public ActionResult<AppointmentCount> GetPatientsCountMonthly(string username)
        {
            return _visitService.GetPatientsCountMonthly(username);
        }

        [HttpGet("{username}/appointmentWeekly")]
        public ActionResult<AppointmentCount> GetVisitsCountWeekly(string username)
        {
            return _visitService.GetVisitsCountWeekly(username);
        }

        [HttpGet("{username}/patientWeekly")]
        public ActionResult<AppointmentCount> GetPatientsCountWeekly(string username)
        {
            return _visitService.GetPatientsCountWeekly(username);
        }

        [HttpGet("{username}/appointmentDaily")]
        public ActionResult<AppointmentCount> GetVisitsCountDaily(string username)
        {
            return _visitService.GetVisitsCountDaily(username);
        }

        [HttpGet("{username}/patientDaily")]
        public ActionResult<AppointmentCount> GetPatientsCountDaily(string username)
        {
            return _visitService.GetPatientsCountDaily(username);
        }


        [HttpGet("visit/{id}")]
        public ActionResult<Visit> GetVisitById(int id)
        {
            return _visitService.GetVisitById(id);
        }

        [HttpGet("room/{id}")]
        public ActionResult<List<ScheduleTermDTO>> GetVisitByRoomId(int id)
        {
            var result = _visitService.GetVisitsForRoom(id);
            List<ScheduleTermDTO> scheduleTermDTOS = new List<ScheduleTermDTO>();
            foreach (Visit v in result)
            {
                ScheduleTermDTO scheduleTermDTO = _mapper.Map<ScheduleTermDTO>(v);
                scheduleTermDTO.Type = "Appointment";
                scheduleTermDTOS.Add(scheduleTermDTO);
            }
            return Ok(scheduleTermDTOS);
        }


        [HttpGet]
        [Route("doctors")]
        public ActionResult<IEnumerable<Doctor>> GetАllDoctors()
        {
            return _doctorService.GetAllDoctors();
        }

        [HttpPost]
        public ActionResult PostVisit(VisitDto visitDto)
        {
            Visit mappedVisit = _mapper.Map<Visit>(visitDto);
            if (_visitService.AddVisit(mappedVisit))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult CancelVisit(int id)
        {
            Visit visitForUpdate = _visitService.GetVisitById(id);
            if (DateTime.Now >= visitForUpdate.EndTime || visitForUpdate.IsCanceled)
                return BadRequest();
            _visitService.CancelVisit(visitForUpdate);
            return Ok();
        }

        [HttpPut("visit/{id}")]
        public IActionResult ReviewVisit(int id)
        {
            Visit visitForUpdate = _visitService.GetVisitById(id);
            if (DateTime.Now <= visitForUpdate.EndTime || visitForUpdate.IsReviewed)
                return BadRequest();
            _visitService.ReviewVisit(visitForUpdate);
            return Ok();
        }


        [HttpGet]
        [Route("generatedFreeVisits")]
        public ActionResult<IEnumerable<Visit>> GetАllGeneratedFreeVisits(string doctorId, bool priority, 
            bool isVisitScheduleByPriority, string beginning, string ending)
        {
            string[] startSplit = beginning.Split("/");
            string[] endSplit = ending.Split("/");
            DateTime startTime = new DateTime(int.Parse(startSplit[2]), int.Parse(startSplit[0]), int.Parse(startSplit[1]));
            DateTime endTime = new DateTime(int.Parse(endSplit[2]), int.Parse(endSplit[0]), int.Parse(endSplit[1]));
            return _visitService.GetАllGeneratedFreeVisits(new VisitRecommendation(startTime, endTime, doctorId, priority, isVisitScheduleByPriority));
        }

        [HttpGet]
        [Route("report/{id}")]
        public ActionResult<AppointmentReport> GetReport(int id)
        {
            AppointmentReport report = _visitService.GetReport(id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        [HttpGet]
        [Route("prescription/{id}")]
        public ActionResult<AppointmentReport> GetPreciption(int id)
        {
            AppointmentPrescription prescription = _visitService.GetPrescription(id);
            if (prescription == null) return NotFound();
            return Ok(prescription);
        }
    }
}
