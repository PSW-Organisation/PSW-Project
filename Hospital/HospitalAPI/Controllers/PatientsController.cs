using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Service;


namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public PatientsController(HospitalDbContext context, IMapper mapper, IPatientService patientService)
        {
            _context = context;
            _mapper = mapper;
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            return _patientService.GetMaliciousPatients();
        }

        [HttpPut("{username}")]
        public IActionResult BlockPatient(string username)
        {
            Patient maliciousPatient = _patientService.GetProfileData(username);
            if (maliciousPatient.IsBlocked || !maliciousPatient.IsActivated)
                return BadRequest();
            _patientService.BlockPatient(maliciousPatient);
            return Ok();
        }
    }
}