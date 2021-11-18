using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ehealthcare.Model;
using HospitalAPI;
using HospitalAPI.DTO;
using HospitalLibrary.FeedbackAndSurvey.Model;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HospitalIntegrationTests.FeedbackAndSurvey
{
    public class SurveyStats : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;
        public SurveyStats(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Read_GET_Action_ValidData()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/Survey/SurveyStats");
            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}