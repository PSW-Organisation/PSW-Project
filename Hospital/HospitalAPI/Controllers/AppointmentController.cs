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

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{username}")]
        public ActionResult<IEnumerable<Visit>> GetVisitsByUsername(string username)
        {
            return _visitService.GetVisitsByUsername(username);
        }


        [HttpGet("visit/{id}")]
        public ActionResult<Visit> GetVisitById(int id)
        {
            return _visitService.GetVisitById(id);
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
            //if (!ModelState.IsValid)
            //  return BadRequest();
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
    }
}
