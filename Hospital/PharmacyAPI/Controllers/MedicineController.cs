using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Model;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
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
        

    }
}
