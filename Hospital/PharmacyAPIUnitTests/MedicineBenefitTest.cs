using Moq;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.MedicineBenefitRepository;
using PharmacyLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PharmacyAPIUnitTests
{
    public class MedicineBenefitTest
    {

        [Fact]
        public void check_if_medicinebenefit_exits()
        {
            var stubBenefitRepo = new Mock<IMedicineBenefitRepository>();

            var benefit = new MedicineBenefit() {Id = 0, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId=0 };
            stubBenefitRepo.Setup(m => m.Get(0)).Returns(benefit);
            RabbitMQPublishService rabbitMQPublishService = new RabbitMQPublishService();
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(stubBenefitRepo.Object, rabbitMQPublishService);
            MedicineBenefit m = medicineBenefitService.Get(benefit.Id);
            Assert.NotNull(m);

        }

        [Fact]
        public void check_if_medicinebenefit_not_exits()
        {
            var stubBenefitRepo = new Mock<IMedicineBenefitRepository>();

            var benefit = new MedicineBenefit() { Id = 1, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId = 0 };
            stubBenefitRepo.Setup(m => m.Get(0)).Returns(benefit);
            RabbitMQPublishService rabbitMQPublishService = new RabbitMQPublishService();
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(stubBenefitRepo.Object, rabbitMQPublishService);
            MedicineBenefit m = medicineBenefitService.Get(benefit.Id);
            Assert.Null(m);

        }
        [Fact]
        public void check_if_exchange_declared()
        {
            var rabbitMqPublishService = new RabbitMQPublishService();
            bool started = rabbitMqPublishService.initConnection();

            Assert.True(started);
        }
    }
}
