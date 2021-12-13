using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Parnership.Repository.RepoImpl;
using IntegrationLibrary.Parnership.Repository.RepoInterfaces;
using IntegrationLibrary.Parnership.Service.ServiceImpl;
using System;
using Xunit;

namespace IntegrationAPIIntegrationTests
{
    public class MedificineBenefitTest
    {
        [Fact]
        public void check_if_benefit_exits()
        {
            MedicineBenefitRepository medineBenefitRepository = new MedicineBenefitDbRepository(new IntegrationDbContext());
            MedicineBenefit benefit = new MedicineBenefit() { Id = 20, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId = 0 };
            medineBenefitRepository.Save(benefit);
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(medineBenefitRepository);
            MedicineBenefit m = medicineBenefitService.Get(benefit.Id);
            Assert.NotNull(m);
            medicineBenefitService.Delete(benefit);
        }
        [Fact]
        public void check_if_benefit_not_exits()
        {
            MedicineBenefitRepository medineBenefitRepository = new MedicineBenefitDbRepository(new IntegrationDbContext());
            
            MedicineBenefit benefit = new MedicineBenefit() { Id = 20, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId = 0 };
            medineBenefitRepository.Save(benefit);
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(medineBenefitRepository);
            MedicineBenefit m = medicineBenefitService.Get(55);
            Assert.Null(m);
            medicineBenefitService.Delete(benefit);
        }

       
    }
}
