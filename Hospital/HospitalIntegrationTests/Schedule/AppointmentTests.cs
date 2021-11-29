using HospitalAPI;
using HospitalAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ehealthcare.Model;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HospitalIntegrationTests.Schedule
{
    public class AppointmentTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;

        public AppointmentTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Read_GET_BY_Username_Action()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/appointment/imbiamba");
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Create_POST_Action()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/appointment");
            VisitDto formModel = GetData();
            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            //response.EnsureSuccessStatusCode();
            Assert.Equal("mkisic", context.Visits.FirstOrDefault(v => v.DoctorId == "mkisic")?.DoctorId);
        }
        [Fact]
        public async Task Create_POST_Invalid_Action()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/appointment");
            VisitDto formModel = GetData();
            formModel.StartTime = new DateTime(2021, 11, 30, 19, 0, 0);
            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Status_Update_Cancel_Action()
        {
            var putRequest = new HttpRequestMessage(HttpMethod.Put, "api/appointment/1");
            var response = await _client.SendAsync(putRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Status_Update_Review_Action()
        {
            var putRequest = new HttpRequestMessage(HttpMethod.Put, "api/appointment/visit/-1");
            var response = await _client.SendAsync(putRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Read_GET_ALL_GENERATED_FREE_VISITS_BY_DATE_AND_DOCTOR_Action_ValidData()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/Appointment/generatedFreeVisits?DoctorId=nelex&Priority=false&IsVisitScheduleByPriority=true&Beginning=12/11/2021&Ending=12/12/2021");
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private static VisitDto GetData()
        {
            return new VisitDto()
            {
                StartTime = new DateTime(2021, 12, 29, 7, 0, 0),
                EndTime = new DateTime(2021, 12, 29, 7, 15, 0),
                VisitType = VisitType.examination,
                DoctorId = "mkisic",
                PatientId = "imbiamba",
                IsReviewed = false,
                IsCanceled = false
            };

        }

    }
}