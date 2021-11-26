using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IAllergenService _allergenService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public ProfileController(IAllergenService allergenService, IDoctorService doctorService,
                           IPatientService patientService, IMapper mapper)
        {
            _allergenService = allergenService;
            _doctorService = doctorService;
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet("{username}")]
        public ActionResult<PatientDto> GetProfileData(string username)
        {
            Patient patient = _patientService.GetProfileData(username);
            if (patient == null) return NotFound();
            if (!patient.IsActivated) return BadRequest();
            PatientDto profile = _mapper.Map<PatientDto>(patient);
            profile.Password = "";
            profile.Medical.DoctorId = patient.Medical.Doctor.FullName;
            profile.Medical.Doctor = null;
            return profile;
        }
    }
}
