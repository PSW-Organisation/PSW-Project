using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api2/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IntegrationDbContext dbContext;

        public PharmacyController(IntegrationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]       // GET /api/pharmacy
        public IActionResult Get()
        {
            List<PharmacyDto> result = new List<PharmacyDto>();
            //Program.Pharmacies.ForEach(pharmacy => result.Add(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy)));
            dbContext.Pharmacies.ToList().ForEach(pharmacy => result.Add(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/pharmacy/1
        public IActionResult Get(long id)
        {
            //Pharmacy pharmacy = Program.Pharmacies.Find(pharmacy => pharmacy.PharmacyId == id);
            Pharmacy pharmacy = dbContext.Pharmacies.FirstOrDefault(pharmacy => pharmacy.PharmacyId == id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy));
            }
        }

        [HttpPost]      // POST /api/pharmacy Request body: {"pharmacyUrl":"someUrl", "pharmacyName":"someName", "pharmacyAddress":"someAddress", "hospitalApiKey":"someApiKey"}
        public IActionResult Add(PharmacyDto dto)
        {
            if (dto.PharmacyName.Length <= 0 || dto.PharmacyUrl.Length <= 0 || dto.PharmacyAddress.Length <= 0)
            {
                return BadRequest();
            }

            //long id = Program.Pharmacies.Count > 0 ? Program.Pharmacies.Max(Pharmacy => Pharmacy.PharmacyId) + 1 : 1;
            long id = dbContext.Pharmacies.ToList().Count > 0 ? dbContext.Pharmacies.Max(Pharmacy => Pharmacy.PharmacyId) + 1 : 1;
            Pharmacy pharmacy = PharmacyAdapter.PharmacyDtoToPharmacy(dto);
            pharmacy.PharmacyId = id;
            string apiKey = GenerateApiKey();
            pharmacy.PharmacyApiKey = apiKey;
            //Program.Pharmacies.Add(pharmacy);
            dbContext.Pharmacies.Add(pharmacy);
            dbContext.SaveChanges();
            return Ok(apiKey);

        }

        [HttpPut]
        public IActionResult Put(UpdateHospitalApiKeyDTO dto)
        {
            Pharmacy pharmacy = dbContext.Pharmacies.SingleOrDefault(pharmacy => pharmacy.PharmacyId == dto.PharmacyID);
            if(pharmacy == null)
            {
                return NotFound();
            }
            pharmacy.HospitalApiKey = dto.HospitalApiKey;
            dbContext.Update(pharmacy);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut("{id?}")]
        public IActionResult Put(PharmacyDto dto, long id)
        {
            Pharmacy pharmacy = dbContext.Pharmacies.SingleOrDefault(pharmacy => pharmacy.PharmacyId == id);
            if(pharmacy == null)
            {
                return NotFound();
            }
            pharmacy = PharmacyAdapter.UpdatePharmacyDtoToPharmacy(dto, pharmacy);
            dbContext.Update(pharmacy);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id?}")]       // DELETE /api/pharmacy/1
        public IActionResult Delete(long id = 0)
        {
            //Pharmacy pharmacy = Program.Pharmacies.Find(pharmacy => pharmacy.PharmacyId == id);
            Pharmacy pharmacy = dbContext.Pharmacies.SingleOrDefault(pharmacy => pharmacy.PharmacyId == id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            else
            {
                //Program.Pharmacies.Remove(pharmacy);
                dbContext.Pharmacies.Remove(pharmacy);
                dbContext.SaveChanges();
                return Ok();
            }
        }
        

        public string GenerateApiKey()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
