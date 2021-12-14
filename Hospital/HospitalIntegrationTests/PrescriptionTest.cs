using ehealthcare.Model;
using HospitalAPI;
using HospitalLibrary.MedicalRecords.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    public class PrescriptionTest : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;
        public PrescriptionTest(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_POST_Action_ValidModel()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/prescription");
            MedicinePrescription formModel = new MedicinePrescription { DoctorId = "Pera Peric", Diagnosis = "Umobol", MedicineId = "Panklav", PatientId = "Mika Mikic" };
            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal("Mika Mikic", context.Prescriptions.FirstOrDefault(p => p.PatientId.Equals("Mika Mikic")).PatientId);
            Assert.Equal("Pera Peric", context.Prescriptions.FirstOrDefault(p => p.DoctorId.Equals("Pera Peric")).DoctorId);
            Assert.Equal("Umobol", context.Prescriptions.FirstOrDefault(p => p.Diagnosis.Equals("Umobol")).Diagnosis);
        }
    }
}
