using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Adapter;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{   [ApiController]
    [Route("api3/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<HospitalDto> result = new List<HospitalDto>();
            hospitalService.Get().ToList().ForEach(hospital => result.Add(HospitalAdapter.HospitalToHospitalDto(hospital)));
            return Ok(result);
        }

        [HttpGet("{id?}")]
        public IActionResult Get(long id)
        {
            Hospital hospital = hospitalService.Get(id);
            if(hospital == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(HospitalAdapter.HospitalToHospitalDto(hospital));
            }
        }

        [HttpPost]
        public IActionResult Add(HospitalDto dto)
        {
            if(dto.HospitalName.Length <= 0 || dto.HospitalUrl.Length <= 0 || dto.HospitalAddress.Length <= 0)
            {
                return BadRequest();
            }
            
            return Ok(hospitalService.Add(HospitalAdapter.HospitalDtoToHospital(dto)));
        }

        /*[HttpPut]
        public IActionResult Put(UpdatePharmacyApiKey dto)
        {
            Hospital hospital = dbContext.Hospitals.SingleOrDefault(hospital => hospital.HospitalId == dto.HospitalId);
            if (hospital == null)
            {
                return NotFound();
            }
            hospital.PharmacyApiKey = dto.PharmacyApiKey;
            dbContext.Update(hospital);
            dbContext.SaveChanges();
            return Ok();
        }*/
        [HttpPut("{id?}")]
        public IActionResult Put(HospitalDto dto, long id)
        {
            Hospital hospital = hospitalService.Get(id);
            if (hospital == null)
            {
                return NotFound();
            }
            hospitalService.Update(HospitalAdapter.UpdateHospitalDtoToHospital(dto, hospital));
            return Ok();
        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(long id)
        {
            Hospital hospital = hospitalService.Get(id);
            if(hospital == null)
            {
                return NotFound();

            }
            else
            {
                hospitalService.Delete(id);
                return Ok();
            }
        }
    }
}
