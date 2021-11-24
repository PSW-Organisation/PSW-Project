using Microsoft.Net.Http.Headers;
using HospitalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HospitalAPI.DTO;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.Model;
using ehealthcare.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace HospitalIntegrationTests.MedicalRecord
{
    public class RegistrationTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;
        public RegistrationTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_POST_Action_ValidModel()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/Registration");
            PatientDto formModel = GetData();
            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal("micko", context.Patients.Where(p => p.Username == "micko").FirstOrDefault().Username);
            Assert.Equal("micko", context.MedicalRecords.Where(m => m.PatientId == "micko").FirstOrDefault().PatientId);
            Assert.Equal(1, context.PatientAllergens.Where(pa => pa.PatientId == "micko" && pa.AllergenId == 1).FirstOrDefault().AllergenId);
        }

        [Fact]
        public async Task Create_POST_Action_InvalidModel()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/Registration");
            PatientDto formModel = GetData();
            formModel.Password = "micko";
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task Create_POST_Action_DuplicateUsername()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/Registration");
            PatientDto formModel = GetData();
            formModel.Username = "coalukas";
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }

        private static PatientDto GetData()
        {
            return new PatientDto()
            {
                LoginType = 0,
                Username = "micko",
                Password = "Micko1999!",
                Name = "Mihajlo",
                Surname = "Kisić",
                ParentName = "Zvezdan",
                Gender = "male",
                DateOfBirth = new DateTime(1999, 10, 21),
                Phone = "066059455",
                Email = "micko99@gmail.com",
                Address = "Drvarska, 8",
                City = "Backa Palanka",
                Country = "Serbia",
                Allergens = new List<Allergen>() {
                    new Allergen() {
                        Name = "penicilin",
                        Id = 1,
                        PatientAllergens = new List<PatientAllergen>()
                        {
                            new PatientAllergen()
                            {
                                PatientId = "micko",
                                AllergenId = 1
                            }
                        }
                    }
                },
                Medical = new HospitalLibrary.MedicalRecords.Model.MedicalRecord()
                {
                    PatientId = "micko",
                    PersonalId = "1234567891234",
                    BloodType = BloodType.A_positive,
                    Height = 183,
                    Weight = 80,
                    Profession = "Software Engineer",
                    DoctorId = "nelex"
                },
                IsActivated = false,
                IsBlocked = false,
                MedicalPermits = new List<MedicalPermit>()
            };
        }
    }
}
