﻿using AutoMapper;
using ehealthcare.Model;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using HospitalLibrary.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentResults;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;

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
        private readonly IHostingEnvironment _env;
        public ProfileController(IAllergenService allergenService, IDoctorService doctorService,
                           IPatientService patientService, IMapper mapper, IHostingEnvironment env)
        {
            _allergenService = allergenService;
            _doctorService = doctorService;
            _patientService = patientService;
            _mapper = mapper;
            _env = env;
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

        [HttpPost]
        [Route("UploadImage/{username}")]
        public async Task<IActionResult> UploadImage(IFormFile profileImage)
        {
            string[] paths = HttpContext.Request.Path.Value.Split("/");
            string uploads = Path.Combine(_env.ContentRootPath, "ProfileImages");
        
            if (profileImage is null) return BadRequest();
            string filePath = Path.Combine(uploads, paths[paths.Length - 1] + ".jpeg");

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                await profileImage.CopyToAsync(fileStream);
            
            return Ok();
        }

        [HttpGet]
        [Route("GetImage/{username}")]
        public object GetImage(string username)
        {
            string[] paths = HttpContext.Request.Path.Value.Split("/");
            string uploads = Path.Combine(_env.ContentRootPath, "ProfileImages");
            string filePath = Path.Combine(uploads, username + ".jpeg");

            byte[] imageArray = System.IO.File.ReadAllBytes(filePath);

            return new {image = "data:image/jpeg;base64," + Convert.ToBase64String(imageArray)};
        }
    }
}
