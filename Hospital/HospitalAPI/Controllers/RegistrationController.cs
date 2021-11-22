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

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IAllergenService _allergenService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public RegistrationController(IAllergenService allergenService, IDoctorService doctorService,
                           IPatientService patientService, IUserService userService, IMapper mapper)
        {
            _allergenService = allergenService;
            _doctorService = doctorService;
            _patientService = patientService;
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/Allergens
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
            /*if (!ModelState.IsValid)
                return BadRequest();
            */


            _patientService.Register(_mapper.Map<Patient>(patientDto), patientDto.Allergens.ToList());

            return Ok();
        }

    }
}
