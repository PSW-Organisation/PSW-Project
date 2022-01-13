
using PharmacyAPI;
using PharmacyLibrary;
using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.MedicineBenefitRepository;
using PharmacyLibrary.Service;
using RabbitMQ.Client;
using System;
using Xunit;

namespace PharmacyAPIIntegrationTests
{
    public class MedicineBenefitTest
    {
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;

        [SkippableFact]
        public void check_if_benefit_exits()
        {
            Skip.If(skippable);
            IMedicineBenefitRepository medineBenefitRepository = new MedicineBenefitRepository(new PharmacyDbContext());
            IPublishService rabbitMq = new RabbitMQPublishService();
            MedicineBenefit benefit = new MedicineBenefit() { Id = 50, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = new DateTime(2030, 10,11), MedicineId = 0 };
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(medineBenefitRepository, rabbitMq);
            bool added = medineBenefitRepository.Add(benefit);

            MedicineBenefit m = medicineBenefitService.Get(benefit.Id);
            Assert.NotNull(m);
            medicineBenefitService.Delete(m.Id);
        }

        [SkippableFact]
        public void check_if_benefit_not_exits()
        {
            Skip.If(skippable);
            IMedicineBenefitRepository medineBenefitRepository = new MedicineBenefitRepository(new PharmacyDbContext());
            IPublishService rabbitMq = new RabbitMQPublishService();
            MedicineBenefit benefit = new MedicineBenefit() { Id = 20, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId = 0 };
            medineBenefitRepository.Add(benefit);
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(medineBenefitRepository, rabbitMq);
            MedicineBenefit m = medicineBenefitService.Get(55);
            Assert.Null(m);
            medicineBenefitService.Delete(benefit.Id);
        }


        [SkippableFact]
        public void check_if_benefit_posted_to_queue_exits()
        {
            Skip.If(skippable);
            IMedicineBenefitRepository medineBenefitRepository = new MedicineBenefitRepository(new PharmacyDbContext());
            RabbitMQPublishService rabbitMq = new RabbitMQPublishService();
            MedicineBenefit benefit = new MedicineBenefit() { Id = 20, MedicineBenefitContent = "Neki String", MedicineBenefitTitle = "Neki String", MedicineBenefitDueDate = DateTime.Now, MedicineId = 0 };
            MedicineBenefitService medicineBenefitService = new MedicineBenefitService(medineBenefitRepository, rabbitMq);
            medicineBenefitService.Add(benefit);
            BasicGetResult resp = rabbitMq.channel.BasicGet("Flos", false);
            Assert.NotNull(resp);
            //rabbitMq.connection.Close();
            //rabbitMq.channel.Close();
            uint i = rabbitMq.channel.QueuePurge(queue: "Flos");
         }
    }
}
