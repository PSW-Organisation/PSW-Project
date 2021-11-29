using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HospitalAPI;
using Xunit;

namespace HospitalIntegrationTests.Schedule
{
    public class MaliciousPatientTests : IClassFixture<TestingHospitalFactory<Startup>>
    {

        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;

        public MaliciousPatientTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Read_GET_Action_MaliciousPatients()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/Patients");
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Update_PUT_Action_BlockPatient()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Put, "api/Patients/kristina");
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }

}