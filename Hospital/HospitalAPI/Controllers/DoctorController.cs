using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.RoomsAndEquipment.Terms.Service;
using Microsoft.AspNetCore.Mvc;


namespace HospitalAPI.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;

        public DoctorController(IMapper mapper, IDoctorService doctorService)
        {
            _mapper = mapper;
            _doctorService = doctorService;
        }

        [HttpGet]
        public ActionResult<List<DoctorDTO>> GetAllDoctors()
        {
            List<DoctorDTO> doctorsDTO = new List<DoctorDTO>();
            foreach (Doctor doctor in _doctorService.GetAllDoctors())
            {
                DoctorDTO doctorDTO = _mapper.Map<DoctorDTO>(doctor);
                doctorsDTO.Add(doctorDTO);
            }
            return Ok(doctorsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DoctorDTO> GetDoctorById(string id)
        {
            Doctor doctor = _doctorService.GetDoctorById(id);
            DoctorDTO doctorDTO = _mapper.Map<DoctorDTO>(doctor);
            return Ok(doctorDTO);
        }

    }
}
