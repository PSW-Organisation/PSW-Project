using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api3/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService medicineService;
        private readonly IHospitalService hospitalService;

        public MedicineController(IMedicineService medicineService, IHospitalService hospitalService)
        {
            this.medicineService = medicineService;
            this.hospitalService = hospitalService;
        }

        [HttpGet]       // GET /api3/pharmacy
        public List<Medicine> GetAllPharmacies()
        {
            return medicineService.Get();
        }

        [HttpGet("{id?}")]
        public Medicine Get(int id)
        {
            return medicineService.Get(id);
        }

        [HttpPost]
        public Boolean Add(Medicine newMedicine)
        {
            return medicineService.Add(newMedicine);
        }

        [HttpDelete("{id?}")]
        public Boolean Delete(int id)
        {
            return medicineService.Delete(id);
        }

        [HttpPut]
        public Boolean Update(Medicine m)
        {
            return medicineService.Update(m);
        }
         
        [HttpGet("{id}/{quantity}")]  // api/medicine/id/quantity
        public bool CheckAvaliableQuantity(int id, int quantity)
        {
            return medicineService.CheckAvaliableQuantity(id, quantity);
        }

        [HttpPost("{hospitalApiKey?}")] 
        public IActionResult CheckIfExists(SearchMedicineDTO searchMedicine, string hospitalApiKey)
        {
            List<Hospital> result = new List<Hospital>();
            hospitalService.Get().ToList().ForEach(hospital => result.Add(hospital));
            foreach (Hospital hospital in result)
            {
                if (hospital.HospitalApiKey == hospitalApiKey)
                {
                    return Ok(medicineService.CheckIfExists(searchMedicine.medicineName, searchMedicine.medicineAmount));
                }
            }
            return NotFound();
        }

        [HttpPut("{hospitalApiKey}")]
        public IActionResult reduceQuantityOfMedicine(SearchMedicineDTO searchMedicine, string hospitalApiKey)
        {
            List<Hospital> result = new List<Hospital>();
            hospitalService.Get().ToList().ForEach(hospital => result.Add(hospital));
            foreach (Hospital hospital in result)
            {
                if (hospital.HospitalApiKey == hospitalApiKey)
                {
                    return Ok(medicineService.reduceQuantityOfMedicine(searchMedicine.medicineName, searchMedicine.medicineAmount));
                }
            }
            return NotFound();
        }
    }
}
