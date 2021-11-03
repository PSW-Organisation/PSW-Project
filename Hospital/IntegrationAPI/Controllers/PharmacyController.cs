using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        [HttpGet]       // GET /api/pharmacy
        public IActionResult Get()
        {
            List<PharmacyDto> result = new List<PharmacyDto>();
            Program.Pharmacies.ForEach(pharmacy => result.Add(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/pharmacy/1
        public IActionResult Get(long id)
        {
            Pharmacy pharmacy = Program.Pharmacies.Find(pharmacy => pharmacy.PharmacyId == id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy));
            }
        }

        [HttpPost]      // POST /api/pharmacy Request body: {"pharmacyUrl":"someUrl", "pharmacyName":"someName", "pharmacyAddress":"someAddress", "pharmacyApiKey":"someApiKey"}
        public IActionResult Add(PharmacyDto dto)
        {
            if (dto.PharmacyName.Length <= 0 || dto.PharmacyUrl.Length <= 0 || dto.PharmacyAddress.Length <= 0 || dto.PharmacyApiKey.Length <= 0)
            {
                return BadRequest();
            }

            long id = Program.Pharmacies.Count > 0 ? Program.Pharmacies.Max(Pharmacy => Pharmacy.PharmacyId) + 1 : 1;
            Pharmacy pharmacy = PharmacyAdapter.PharmacyDtoToPharmacy(dto);
            pharmacy.PharmacyId = id;
            Program.Pharmacies.Add(pharmacy);
            return Ok();

        }

        [HttpDelete("{id?}")]       // DELETE /api/pharmacy/1
        public IActionResult Delete(long id = 0)
        {
            Pharmacy pharmacy = Program.Pharmacies.Find(pharmacy => pharmacy.PharmacyId == id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            else
            {
                Program.Pharmacies.Remove(pharmacy);
                return Ok();
            }
        }
    }
}
