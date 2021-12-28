using AutoMapper;
using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.MedicalRecords.Service;
using HospitalAPI.DTO;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegistrationController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IAllergenService _allergenService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;


        public RegistrationController(IAllergenService allergenService, IDoctorService doctorService,
                           IPatientService patientService, IMapper mapper)
        {
            _allergenService = allergenService;
            _doctorService = doctorService;
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Allergen>> GetAllergens()
        {
            return _allergenService.GetAllergens();
        }

        [HttpGet("Doctors")]
        public ActionResult<IEnumerable<Doctor>> GetDoctors()
        {
            return _doctorService.GetLeastOccupiedDoctors(_doctorService.FindLeastNumberOfPatient());
        }

        [HttpPost]
        public ActionResult Register(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            patientDto.Token = Guid.NewGuid();
            _patientService.Register(_mapper.Map<Patient>(patientDto), patientDto.Allergens.ToList());
            _patientService.SendEmail(patientDto.Email, patientDto.Token);

            return Ok();
        }

        [HttpPut("{token}")]
        public ActionResult Activate(string token)
        {
            if (!Guid.TryParse(token, out Guid guid)) return BadRequest();
            int statusCode = _patientService.Activate(guid);
            return statusCode switch
            {
                200 => Ok(),
                400 => BadRequest(),
                _ => NotFound(),
            };
        }
    }
}
