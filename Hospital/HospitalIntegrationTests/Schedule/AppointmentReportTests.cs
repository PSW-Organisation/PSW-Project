using AutoMapper.Configuration;
using HospitalAPI;
using HospitalAPI.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests.Schedule
{
    public class AppointmentReportTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;

        public AppointmentReportTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        private async Task<string> GetToken()
        {
            var loginRequest = new HttpRequestMessage(HttpMethod.Post, "api/login/authenticate");
            loginRequest.Content = new StringContent("{\"username\":\"imbiamba\",\"password\":\"pecurkaa\"}", Encoding.UTF8, "application/json");
            var loginResponse = await _client.SendAsync(loginRequest);
            loginResponse.EnsureSuccessStatusCode();

            JwtDto jwt = JsonConvert.DeserializeObject<JwtDto>(await loginResponse.Content.ReadAsStringAsync());
            var token = JObject.Parse(jwt.Token.ToString());

            return token["token"].ToString();
        }

        [Fact]
        public async Task Read_GET_BY_Id_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointment/report/-1");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GET_BY_Id_Error()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointment/report/-1485");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
            var response = await _client.SendAsync(getRequest);

            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }
    }
}
