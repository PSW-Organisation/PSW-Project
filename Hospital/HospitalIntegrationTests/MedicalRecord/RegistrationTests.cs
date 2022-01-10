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
using System.Net;

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
            Assert.Equal("micko", context.Patients.FirstOrDefault(p => p.Username == "micko").Username);
            Assert.Equal("micko", context.MedicalRecords.FirstOrDefault(m => m.PatientId == "micko").PatientId);
            Assert.Equal(1, context.PatientAllergens.FirstOrDefault(pa => pa.PatientId == "micko" && pa.AllergenId == 1).AllergenId);
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

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Update_PUT_Action_AccountActivation(string token, HttpStatusCode expectedStatus)
        {
            var putRequest = new HttpRequestMessage(HttpMethod.Put, $"api/Registration/{token}");

            var response = await _client.SendAsync(putRequest);

            Assert.Equal(expectedStatus, response.StatusCode);
        }

        public static IEnumerable<object[]> Data =>
                                           new List<object[]>
                                           {
                                                new object[] { "55455454-32434324-asdfs!-sdadad", HttpStatusCode.BadRequest },
                                                new object[] { "12fd2a13-39e7-4672-bc7f-a1d6f6d79030", HttpStatusCode.NotFound },
                                                new object[] { "98dd3304-2326-4e8e-9f6d-868f30f9a9cc", HttpStatusCode.BadRequest },
                                                new object[] { "601ccaa8-3a07-4a7c-89b9-9953e6eac8a7", HttpStatusCode.OK },
                                           };

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
                    Info = new MedicalRecordInfo("micko", "1234567891234", BloodType.A_positive, 183, 80, "Software Engineer"),
                    DoctorId = "nelex"
                },
                Token = new Guid("3e8549d0-db22-4d38-bd30-84b6c3e3e344"),
                IsActivated = true,
                IsBlocked = false,
                MedicalPermits = new List<MedicalPermit>()
            };
        }
    }
}
