using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using PharmacyLibrary.Emailing.Service.Interface;
using PharmacyLibrary.Emailing.Utility;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyAPI.Controllers
{
    [Route("api3/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService medicineService;
        private readonly IHospitalService hospitalService;
        private readonly IEmailSender emailSender;

        public MedicineController(IMedicineService medicineService, IHospitalService hospitalService, IEmailSender emailSender)
        {
            this.medicineService = medicineService;
            this.hospitalService = hospitalService;
            this.emailSender = emailSender;
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
                    var sb = new StringBuilder();
                    sb.Append(@"Your order was accepted.");
                    sb.AppendLine();
                    sb.Append(@"Order information:");
                    sb.AppendLine();
                    sb.AppendFormat(@"Medicine: {0}", searchMedicine.medicineName);
                    sb.AppendLine();
                    sb.AppendFormat(@"Ammount: {0}", searchMedicine.medicineAmount);
                    var message = new Message(new string[] { hospital.Email }, "Medicine order", sb.ToString());
                    emailSender.SendEmail(message);
                    return Ok(medicineService.reduceQuantityOfMedicine(searchMedicine.medicineName, searchMedicine.medicineAmount));
                }
            }
            return NotFound();
        }
    }
}
