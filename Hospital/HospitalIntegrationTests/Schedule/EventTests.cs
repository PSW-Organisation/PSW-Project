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
    public class EventTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;

        public EventTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        public async Task<string> GetManagerToken()
        {
            var loginRequest = new HttpRequestMessage(HttpMethod.Post, "api/login/authenticate");
            loginRequest.Content = new StringContent("{\"username\":\"laki\",\"password\":\"Laki123!\"}", Encoding.UTF8, "application/json");
            var loginResponse = await _client.SendAsync(loginRequest);
            loginResponse.EnsureSuccessStatusCode();

            JwtDto jwt = JsonConvert.DeserializeObject<JwtDto>(await loginResponse.Content.ReadAsStringAsync());
            var token = JObject.Parse(jwt.Token.ToString());

            return token["token"].ToString();
        }

        public async Task<string> GetPatientToken()
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
        public async Task Read_GetAbortStepBreakdown_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointmentSchedulingEvent/abortStepBreakdown");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetManagerToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GetStepDurationBreakdown_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointmentSchedulingEvent/stepDurationBreakdown");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetManagerToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GetSuccessfullSchedulingPerMonth_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointmentSchedulingEvent/successfullSchedulingPerMonth");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetManagerToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GetUnsuccessfullSchedulingPerMonth_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointmentSchedulingEvent/unsuccessfullSchedulingPerMonth");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetManagerToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GetSchedulingPerTimeOfDay_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointmentSchedulingEvent/schedulingPerTimeOfDay");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetManagerToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GetUnsuccessfullSchedulingByAgeGroup_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointmentSchedulingEvent/unsuccessfullSchedulingByAgeGroup");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetManagerToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GetAverageStats_Success()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointmentSchedulingEvent/averageStats");
            getRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetManagerToken());
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
