using AutoMapper;
using HospitalAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Service;
using HospitalLibrary.Model;
using Microsoft.AspNetCore.Http;


namespace HospitalAPI.Controllers
{
    [Route("api/oncallshift")]
    [ApiController]
    public class OnCallShiftController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOnCallShiftService _onCallShiftService;

        public OnCallShiftController(IMapper mapper, IOnCallShiftService onCallShiftService)
        {
            _mapper = mapper;
            _onCallShiftService = onCallShiftService;
        }

        [HttpGet]
        public ActionResult<List<OnCallShiftDTO>> GetAllOnCallShifts()
        {
            var result = _onCallShiftService.GetAllOnCallShifts();
            return Ok(result.Select(v => _mapper.Map<OnCallShiftDTO>(v)).ToList());
        }

        [HttpGet]
        [Route("doctorsoncallshift/{date}")]
        public ActionResult<List<DoctorDTO>> GetDoctorsOnCallShift(string date) 
        {
            var result = _onCallShiftService.GetDoctorsOnCallShifts(DateTime.ParseExact(date, "dd.M.yyyy.", CultureInfo.InvariantCulture));
            return Ok(result.Select(d => _mapper.Map<DoctorDTO>(d)).ToList());
        }

        [HttpGet]
        [Route("doctorsnotoncallshift/{date}")]
        public ActionResult<List<DoctorDTO>> GetDoctorsNotOnCallShift(string date)  
        {
            var result = _onCallShiftService.GetDoctorsNotOnCallShift(DateTime.ParseExact(date, "dd.M.yyyy.", CultureInfo.InvariantCulture));
            return Ok(result.Select(d => _mapper.Map<DoctorDTO>(d)).ToList());
        }

        [HttpGet("{username}/onCallYearly")]
        public AppointmentCount GetOnCallCountYearly(string username)
        {
            return  _onCallShiftService.GetOnCallCountYearly(username);
        }

        [HttpGet("{username}/onCallMonthly")]
        public AppointmentCount GetOnCallCountMonthly(string username)
        {
            return _onCallShiftService.GetOnCallCountMonthly(username);
        }

        [HttpGet("{username}/onCallWeekly")]
        public AppointmentCount GetOnCallCountWeekly(string username)
        {
            return _onCallShiftService.GetOnCallCountWeekly(username);
        }
        [HttpGet("{username}/onCallDaily")]
        public AppointmentCount GetOnCallCountDaily(string username)
        {
            return _onCallShiftService.GetOnCallCountDaily(username);
        }

        [HttpPost]
        public ActionResult<OnCallShiftDTO> CreateOnCallShift(OnCallShiftDTO onCallShift)
        {
            var result = _onCallShiftService.CreateOnCallShift(_mapper.Map<OnCallShift>(onCallShift));
            return Ok(_mapper.Map<OnCallShiftDTO>(result));
        }

        [HttpPut]
        public ActionResult<OnCallShiftDTO> UpdateOnCallShift(OnCallShiftDTO onCallShift)
        {
            var result = _onCallShiftService.UpdateOnCallShift(_mapper.Map<OnCallShift>(onCallShift));
            return Ok(_mapper.Map<OnCallShiftDTO>(result));
        }

        [HttpGet]
        [Route("{doctorId}")]
        public ActionResult<List<OnCallShiftDTO>> GetAllOnCallShiftByDoctorId(string doctorId)
        {
            var result = _onCallShiftService.GetAllOnCallShiftByDoctorId(doctorId);
            return Ok(result.Select(v => _mapper.Map<OnCallShiftDTO>(v)).ToList());
        }

        [HttpDelete]
        public ActionResult<OnCallShiftDTO> DeleteOnCallShift(OnCallShiftDTO onCallShift)
        { 
            var result = _onCallShiftService.DeleteOnCallShift(_mapper.Map<OnCallShift>(onCallShift));
            return Ok(result);
        }
    }
}
