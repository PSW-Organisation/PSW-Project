using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.DTO;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Service;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorVacationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorVacationService _doctorVacationService;

        public DoctorVacationController(IMapper mapper, IDoctorVacationService doctorVacationService)
        {
            _mapper = mapper;
            _doctorVacationService = doctorVacationService;
        }

        [HttpPost]
        public ActionResult<DoctorVacationDTO> CreateDoctorVacation(DoctorVacationDTO doctorVacation)
        {
            var result = _doctorVacationService.CreateDoctorVacation(_mapper.Map<DoctorVacation>(doctorVacation));
            return Ok(_mapper.Map<DoctorVacationDTO>(result));
        }

        [HttpGet]
        public ActionResult<List<DoctorVacationDTO>> GetAllDoctorVacations()
        {
            var result = _doctorVacationService.GetAllDoctorVacations();
            return Ok(result.Select(v => _mapper.Map<DoctorVacationDTO>(v)).ToList());
        }

        [HttpGet]
        [Route("{doctorId}")]
        public ActionResult<List<DoctorVacationDTO>> GetDoctorVacations(string doctorId)
        {
            var result = _doctorVacationService.GetDoctorVacations(doctorId);
            return Ok(result.Select(v => _mapper.Map<DoctorVacationDTO>(v)).ToList());
        }

        [HttpPut]
        public ActionResult<DoctorVacationDTO> UpdateDoctorVacation(DoctorVacationDTO doctorVacation)
        {
            var result = _doctorVacationService.UpdateDoctorVacation(_mapper.Map<DoctorVacation>(doctorVacation));
            return Ok(_mapper.Map<DoctorVacationDTO>(result));
        }

        [HttpDelete]
        public ActionResult<DoctorVacationDTO> DeleteDoctorVacation(DoctorVacationDTO doctorVacation)
        {
            var result = _doctorVacationService.DeleteDoctorVacation(_mapper.Map<DoctorVacation>(doctorVacation));
            return Ok(result);
        }
    }
}
