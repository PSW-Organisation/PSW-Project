using AutoMapper;
using HospitalAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;


namespace HospitalAPI.Controllers
{
    [Route("api/oncallshift")]
    [ApiController]
    public class OnCallShiftController : ControllerBase
    {
        private readonly IMapper _mapper;
        

        public OnCallShiftController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("doctorsoncallshift")] // [Route("doctorsoncallshift/{time}")]
        public ActionResult<List<DoctorDTO>> GetDoctorsOnCallShift()    // DateTime time
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>() 
            {
                new DoctorDTO(){Address="Marka kralja", City="Novi Sad", Country="Serbia", Email="email", Id="PavleID", Name="Pavle", Phone="02434", RoomId=1, Specialization="specializacija", Surname="Pavlovic", Username="pavlekk"},
                new DoctorDTO(){Address="Marka kralja", City="Novi Sad", Country="Serbia", Email="email", Id="MikiID", Name="Mikica", Phone="02434", RoomId=1, Specialization="specializacija", Surname="Mikitovic", Username="mikiii"},
                new DoctorDTO(){Address="Marka kralja", City="Novi Sad", Country="Serbia", Email="email", Id="KikiID", Name="Kikica", Phone="02434", RoomId=1, Specialization="specializacija", Surname="Kikitovic", Username="kikiii"}
            };
            return Ok(doctors);
        }

        [HttpGet]
        [Route("doctorsnotoncallshift")] //[Route("doctorsnotoncallshift/{time}")]
        public ActionResult<List<DoctorDTO>> GetDoctorsNOTOnCallShift() // DateTime time
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>()
            {
                new DoctorDTO(){Address="Marka kralja", City="Novi Sad", Country="Serbia", Email="email", Id="stefanID", Name="Stefan", Phone="02434", RoomId=1, Specialization="specializacija", Surname="Steganovic", Username="stefankk"},
                new DoctorDTO(){Address="Marka kralja", City="Novi Sad", Country="Serbia", Email="email", Id="zikaID", Name="Zika", Phone="02434", RoomId=1, Specialization="specializacija", Surname="Zikic", Username="zika"}
            };
            return Ok(doctors);
        }
    }
}
