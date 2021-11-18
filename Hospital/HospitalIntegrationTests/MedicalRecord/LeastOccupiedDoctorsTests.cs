using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HospitalAPI;
using Xunit;

namespace HospitalIntegrationTests.MedicalRecord
{
    public class LeastOccupiedDoctorsTests : IClassFixture<TestingHospitalFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestingHospitalFactory<Startup> _factory;
        public LeastOccupiedDoctorsTests(TestingHospitalFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Read_GET_Action_ValidData()
        {
            var getRequest = new HttpRequestMessage(HttpMethod.Get, "api/Registration/Doctors");
            var response = await _client.SendAsync(getRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}