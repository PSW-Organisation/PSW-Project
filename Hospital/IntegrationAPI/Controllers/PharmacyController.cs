using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Service.ServiceImpl;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
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
        private IPharmacyService pharmacyService;
        private RabbitMQService rabbitMQService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        [HttpGet]       // GET /api/pharmacy
        public IActionResult Get()
        {
            List<PharmacyDto> result = new List<PharmacyDto>();
            pharmacyService.GetAll().ForEach(pharmacy => result.Add(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/pharmacy/1
        public IActionResult Get(int id)
        {
            Pharmacy pharmacy = pharmacyService.Get(id);
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

            string apiKey = pharmacyService.Save(PharmacyAdapter.PharmacyDtoToPharmacy(dto));


            return Ok(apiKey);
        }

        [HttpPut]
        public IActionResult Put(UpdateHospitalApiKeyDTO dto)
        {
            Pharmacy pharmacy = pharmacyService.Get(dto.PharmacyID);
            if (pharmacy == null)
            {
                return NotFound();
            }
            pharmacyService.UpdateHospitalApiKey(pharmacy, dto.HospitalApiKey);
            return Ok();
        }

        [HttpPut("{id?}")]
        public IActionResult Put(PharmacyDto dto, int id)
        {
            Pharmacy pharmacy = pharmacyService.Get(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            pharmacyService.Update(PharmacyAdapter.PharmacyDtoToPharmacy(dto));
            return Ok();
        }

        [HttpDelete("{id?}")]       // DELETE /api/pharmacy/1
        public IActionResult Delete(int id)
        {
            Pharmacy pharmacy = pharmacyService.Get(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            else
            {
                pharmacyService.Delete(pharmacy);
                return Ok();
            }
        }
    }
}
