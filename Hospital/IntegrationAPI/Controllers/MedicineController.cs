using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
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
    public class MedicineController : ControllerBase
    {
        private IMedicineService medicineService;
       

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
          
        }

        [HttpGet]       // GET /api/medicine
        public IActionResult Get()
        {
            List<MedicineDTO> result = new List<MedicineDTO>();
            medicineService.GetAllMedicine().ForEach(medicine => result.Add(MedicineAdapter.MedicineToMedicineDto(medicine)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/medicine/1
        public IActionResult Get(int id)
        {

            Medicine medicine = medicineService.GetMedicine(id);
            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(MedicineAdapter.MedicineToMedicineDto(medicine));
            }
        }

        [HttpPost]      // POST /api/medicine Request body:
        public IActionResult Add(MedicineDTO dto)
        {
            if (dto.Name.Length <= 0 || dto.MedicineAmount <= 0)
            {
                return BadRequest();
            }

            medicineService.AddMedicine(MedicineAdapter.MedicineDtoToMedicine(dto));
            return Ok();

        }

        [HttpGet("{medicineName}/{medicineAmount}")]
        public IActionResult SearchMedicine(string medicineName, int medicineAmount)
        {
            List<PharmacyDto> result = new List<PharmacyDto>();
            if (medicineName.Equals("") || medicineAmount <= 0)
            {
                return BadRequest();
            }
            medicineService.searchMedicine(medicineName, medicineAmount).ForEach(pharmacy => result.Add(PharmacyAdapter.PharmacyToPharmacyDto(pharmacy)));
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(MedicineDTO dto)
        {
            Medicine medicine = medicineService.GetMedicine(dto.Id);
            if (medicine == null)
            {
                return NotFound();
            }
            medicineService.SetMedicine(medicine);
            return Ok();
        }

        [HttpDelete("{id?}")]       // DELETE /api/medicine/1
        public IActionResult Delete(int id)
        {
            Medicine medicine = medicineService.GetMedicine(id);
            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                medicineService.DeleteMedicine(medicine);
                return Ok();
            }
        }
    }
}
