using IntegrationAPI.Adapters;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
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
        private IMedicineTransactionService transactionService;

        public MedicineController(IMedicineService medicineService, IMedicineTransactionService transactionService)
        {
            this.medicineService = medicineService;
            this.transactionService = transactionService;
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

            Medicine existingMedicine = new Medicine();
            if (dto.Id == -1) { 
                //id ce biti -1 kada se salje zahtev za narucivanje i treba uvecati kolicinu a imamo informaciju samo o nazivu leka, nemamo id
                existingMedicine = medicineService.GetMedicineByName(dto.Name);
            } else
            {
               existingMedicine = medicineService.GetMedicine(dto.Id);
            }

            if (existingMedicine == null)
            {
                Medicine newMedicine = MedicineAdapter.MedicineDtoToMedicine(dto);
                medicineService.AddMedicine(newMedicine);
                MedicineTransaction transaction = MedicineAdapter.MedicineDtoToMedicineTransaction(dto); 
                transaction.MedicineId = newMedicine.Id;//da bi MedicineTransaction imao id novog leka
                transactionService.Save(transaction);
            }
            else
            {
                //existingMedicine.Name = dto.Name;
                //existingMedicine.MedicineAmmount = existingMedicine.MedicineAmmount + dto.MedicineAmmount;
                //dbContext.Medicine.Update(existingMedicine);
                existingMedicine.MedicineAmmount = existingMedicine.MedicineAmmount + dto.MedicineAmount;
                medicineService.SetMedicine(existingMedicine);
                MedicineTransaction transaction = MedicineAdapter.MedicineDtoToMedicineTransaction(dto); 
                transaction.MedicineId = existingMedicine.Id;//da bi MedicineTransaction imao id pronadjenog leka
                transactionService.Save(transaction);
            }
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
