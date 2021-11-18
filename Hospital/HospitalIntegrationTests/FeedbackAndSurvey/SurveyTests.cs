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
    public class SurveyTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;
        public SurveyTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create_POST_Action_ValidModel()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/Survey");
            SurveyQuestionDto formModel = GetData();

            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal("tzone", context.Surveys.FirstOrDefault(p => p.PatientId == "tzone")?.PatientId);
            Assert.Equal(15,context.Questions.Count(c => c.SurveyId == 1));
        }

        [Fact]
        public async Task Create_POST_Action_InvalidModel()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/survey");
            SurveyQuestionDto formModel = GetData();
            formModel.Questions.Add(new Question(1, 16, 3, QuestionCategory.portal));

            var scope = _factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            postRequest.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(formModel), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            Assert.NotEqual(15, context.Questions.Count());
            Assert.NotNull(context.Questions);
        }

        private static SurveyQuestionDto GetData()
        {
            List<Question> questions = new List<Question>();
            for (int i = 0; i < 15; i++)
            {
                questions.Add(new Question(1, i+1, 3,  i > 0 && i < 5 ? QuestionCategory.staff : 
                                                                        i > 4 && i < 10 ? QuestionCategory.hospital : QuestionCategory.portal));   
            }
            return new SurveyQuestionDto()
            {
                PatientId = "tzone",
                SubmissionDate = new DateTime(2021,11,25),
                VisitId = 1,
                Questions = questions
            };
        }
    }
}