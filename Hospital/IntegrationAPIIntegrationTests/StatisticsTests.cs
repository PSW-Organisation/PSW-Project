using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Repository.RepoImpl;
using IntegrationLibrary.Pharmacies.Repository.RepoInterfaces;
using IntegrationLibrary.Pharmacies.Service.ServiceImpl;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoImpl;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using IntegrationLibrary.Tendering.Service.ServiceImpl;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAPIIntegrationTests
{
    public class StatisticsTests
    {
        [Fact]
        public void statisticPharmacyWinningsDefeat()
        {
            ITenderService tenderService = new TenderService(new TenderDbRepository(new IntegrationDbContext()), new TenderItemDbRepository(new IntegrationDbContext()), new TenderRabbitMQService(), new PharmacyService(new PharmacyDbRepository(new IntegrationDbContext())));

            List<int> ret = tenderService.statisticPharmacyWinningsDefeat("bc56df25-0d34-4801-b76a-931e61b4c752");

            Assert.NotNull(ret);
        }

        [Fact]
        public void statisticPharmacyParticipation()
        {
            ITenderService tenderService = new TenderService(new TenderDbRepository(new IntegrationDbContext()), new TenderItemDbRepository(new IntegrationDbContext()), new TenderRabbitMQService(), new PharmacyService(new PharmacyDbRepository(new IntegrationDbContext())));

            List<int> ret = tenderService.statisticPharmacyWinningsDefeat("bc56df25-0d34-4801-b76a-931e61b4c752");

            Assert.NotNull(ret);
        }

    }
}
