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
    [Route("api2/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IntegrationDbContext dbContext;

        public MedicineController(IntegrationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]       // GET /api/medicine
        public IActionResult Get()
        {
            List<MedicineDTO> result = new List<MedicineDTO>();
            dbContext.Medicine.ToList().ForEach(medicine => result.Add(MedicineAdapter.MedicineToMedicineDto(medicine)));
            return Ok(result);
        }

        [HttpGet("{id?}")]      // GET /api/medicine/1
        public IActionResult Get(int id)
        {
           
            Medicine medicine = dbContext.Medicine.FirstOrDefault(medicine => medicine.Id == id);
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
            Medicine newMedicine = MedicineAdapter.MedicineDtoToMedicine(dto);
            Medicine existingMedicine = dbContext.Medicine.SingleOrDefault(medicine => medicine.Id == dto.Id);
            if (existingMedicine == null)
            {
                dbContext.Medicine.Add(newMedicine);
            }
            else
            {
                existingMedicine.Name = dto.Name;
                existingMedicine.MedicineAmmount = existingMedicine.MedicineAmmount + dto.MedicineAmmount;
                dbContext.Medicine.Update(existingMedicine);
            }
            MedicineTransaction transaction = MedicineAdapter.MedicineDtoToMedicineTransaction(dto);
            int id = dbContext.MedicineTransactions.ToList().Count > 0 ? dbContext.MedicineTransactions.Max(transaction => transaction.Id) + 1 : 1;
            transaction.Id = id;
            dbContext.MedicineTransactions.Add(transaction);
            dbContext.SaveChanges();
            return Ok();

        }

        [HttpPut]
        public IActionResult Put(MedicineDTO dto)
        {
            Medicine medicine = dbContext.Medicine.SingleOrDefault(medicine => medicine.Id == dto.Id);
            if (medicine == null)
            {
                return NotFound();
            }
            medicine.Name = dto.Name;
            medicine.MedicineAmmount = dto.MedicineAmmount;
            dbContext.Update(medicine);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id?}")]       // DELETE /api/medicine/1
        public IActionResult Delete(int id)
        {
            Medicine medicine = dbContext.Medicine.SingleOrDefault(medicine => medicine.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Medicine.Remove(medicine);
                dbContext.SaveChanges();
                return Ok();
            }
        }
    }
}
