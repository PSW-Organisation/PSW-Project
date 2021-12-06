using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IMedicinePrescriptionService prescriptionService;

        public PrescriptionController(IMedicinePrescriptionService prescriptionService)
        {
            this.prescriptionService = prescriptionService;
        }

        [HttpPost]
        public IActionResult Add(MedicinePrescription prescription)
        {
            if (prescription.DoctorId.Length <= 0 || prescription.MedicineId.Length <= 0 || prescription.PatientId.Length <= 0)
                return BadRequest();
            prescription.PrescriptionDate = DateTime.Now;
            prescriptionService.Save(prescription);

            var client = new RestClient("http://localhost:16928/api2");
            var request = new RestRequest("/prescription", Method.POST);
            var values = new Dictionary<string, object>
                {
                    {"patientId", prescription.PatientId}, 
                    {"doctorId", prescription.DoctorId}, 
                    {"medicineId", prescription.MedicineId}, 
                    {"prescriptionDate", prescription.PrescriptionDate},
                    {"diagnosis", prescription.Diagnosis}
                };
            request.AddJsonBody(values);

            var cancellationTokenSource = new CancellationTokenSource();
            client.ExecuteAsync(request, cancellationTokenSource.Token);

            return Ok();
        }
    }
}
