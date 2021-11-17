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
            if (dto.Id <= 0 || dto.Name.Length <= 0 || dto.MedicineAmmount <= 0)
            {
                return BadRequest();
            }
            Medicine existingMedicine = medicineService.GetMedicine(dto.Id);
            if (existingMedicine == null)
            {
                Medicine newMedicine = MedicineAdapter.MedicineDtoToMedicine(dto);
                medicineService.AddMedicine(newMedicine);
            }
            else
            {
                //existingMedicine.Name = dto.Name;
                //existingMedicine.MedicineAmmount = existingMedicine.MedicineAmmount + dto.MedicineAmmount;
                //dbContext.Medicine.Update(existingMedicine);
                existingMedicine.MedicineAmmount = existingMedicine.MedicineAmmount + dto.MedicineAmmount;
                medicineService.SetMedicine(existingMedicine);
            }
            MedicineTransaction transaction = MedicineAdapter.MedicineDtoToMedicineTransaction(dto);
            transactionService.Save(transaction);
            return Ok();

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
