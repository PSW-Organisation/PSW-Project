using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HospitalAPI;
using Xunit;

namespace HospitalIntegrationTests.MedicalRecord
{ 
    public class ProfileTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;
        public ProfileTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Read_GET_Action_PatientData(string username, HttpStatusCode expectedStatus)
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"api/Profile/{username}");

            var response = await _client.SendAsync(getRequest);

            Assert.Equal(expectedStatus, response.StatusCode);
        }

        public static IEnumerable<object[]> Data =>
                                           new List<object[]>
                                           {
                                                new object[] { "nonexistent", HttpStatusCode.NotFound },
                                                new object[] { "imbiamba", HttpStatusCode.BadRequest }
                                           };
    }
}
