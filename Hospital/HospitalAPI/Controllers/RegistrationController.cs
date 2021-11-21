using AutoMapper;
using ehealthcare.Model;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.MedicalRecords.Service;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        private readonly IAllergenService _allergenService;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;


        public RegistrationController(IAllergenService allergenService, IDoctorService doctorService, IMapper mapper)
        {
            _allergenService = allergenService;
            _doctorService = doctorService;
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

    }
}
