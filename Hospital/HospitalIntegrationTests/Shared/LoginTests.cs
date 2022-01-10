using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ehealthcare.Model;
using HospitalAPI;
using HospitalAPI.DTO;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HospitalIntegrationTests.Shared
{
    public class LoginTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;

        public LoginTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(); 
        }

        [Fact]
        public async Task Create_POST_Action_ValidModel()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/login/authenticate");
            UserDTO formModel = GetData();
            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
            Assert.True(response.Headers.Contains("Authorization"));
        }

        private static UserDTO GetData()
        {
            return new UserDTO()
            {
                Username = "imbiamba",
                Password = "pecurkaa",
                LoginType = ehealthcare.Model.LoginType.patient
            };
        }
    }
}
