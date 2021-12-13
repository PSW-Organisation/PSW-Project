using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Parnership.Repository.RepoInterfaces;
using IntegrationLibrary.Parnership.Service.ServiceImpl;
using Moq;
using System;
using Xunit;

namespace IntegrationAPIUnitTests
{
    public class MedicineBenefitTest
    {
        [Fact]
        public void check_if_medicinebenefit_exits()
        {
            var stubBenefitRepo = new Mock<MedicineBenefitRepository>();

            var benefit = new MedicineBenefit() { Id = 0, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId = 0 };
            stubBenefitRepo.Setup(m => m.Get(0)).Returns(benefit);
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(stubBenefitRepo.Object);
            MedicineBenefit m = medicineBenefitService.Get(benefit.Id);
            Assert.NotNull(m);

        }

        [Fact]
        public void check_if_medicinebenefit_not_exits()
        {
            var stubBenefitRepo = new Mock<MedicineBenefitRepository>();

            var benefit = new MedicineBenefit() { Id = 1, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId = 0 };
            stubBenefitRepo.Setup(m => m.Get(0)).Returns(benefit);
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(stubBenefitRepo.Object);
            MedicineBenefit m = medicineBenefitService.Get(benefit.Id);
            Assert.Null(m);

        }
    }
}
