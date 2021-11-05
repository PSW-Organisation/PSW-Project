using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Adapter;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{   [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase

    {
        private readonly PharmacyDbContext dbContext;

        public HospitalController(PharmacyDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<HospitalDto> result = new List<HospitalDto>();
            dbContext.Hospitals.ToList().ForEach(hospital => result.Add(HospitalAdapter.HospitalToHospitalDto(hospital)));
            return Ok(result);
        }

        [HttpGet("{id?}")]
        public IActionResult Get(long id)
        {
            Hospital hospital = dbContext.Hospitals.FirstOrDefault(hospital => hospital.HospitalId == id);
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
            if(dto.HospitalName.Length <= 0 || dto.HospitalUrl.Length <= 0 || dto.HospitalApiKey.Length <= 0 || dto.HospitalAddress.Length <= 0)
            {
                return BadRequest();
            }
            long id = dbContext.Hospitals.ToList().Count > 0 ? dbContext.Hospitals.Max(Hospital => Hospital.HospitalId) + 1 : 1;
            Hospital hospital = HospitalAdapter.HospitalDtoToHospital(dto);
            hospital.HospitalId = id;
            dbContext.Hospitals.Add(hospital);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(long id = 0)
        {
            Hospital hospital = dbContext.Hospitals.SingleOrDefault(hospital => hospital.HospitalId == id);
            if(hospital == null)
            {
                return NotFound();

            }
            else
            {
                dbContext.Hospitals.Remove(hospital);
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
