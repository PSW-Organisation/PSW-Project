using IntegrationAPI;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationAPIIntegrationTests
{
    public class PrescriptionTest : IClassFixture<TestingIntegrationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingIntegrationFactory<Startup> _factory;

        public PrescriptionTest(TestingIntegrationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_Prescription_Pdf()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api2/prescription");
            PrescriptionDTO formModel = new PrescriptionDTO { Diagnosis = "Umobol", DoctorId = "Pera Peric", MedicineId = "Panklav", PatientId = "Mika Mikic", PrescriptionDate = DateTime.Now };
            postRequest.Content = new StringContent(JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
        }
    }
}
