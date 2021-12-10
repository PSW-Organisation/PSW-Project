using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAPIUnitTests
{
    public class MedicineConsumptionTest
    {
        private static MedicineTransactionRepository CreateTransactionStubRepository()
        {
            var stubTransactionRepository = new Mock<MedicineTransactionRepository>();
            var transactions = new List<MedicineTransaction>();
            transactions.Add(new MedicineTransaction { Id = 1, MedicineAmmount = 20, MedicineId = 1, TransactionTime = new DateTime(2021, 11, 20) });
            transactions.Add(new MedicineTransaction { Id = 2, MedicineAmmount = 15, MedicineId = 1, TransactionTime = new DateTime(2021, 11, 23) });
            stubTransactionRepository.Setup(t => t.GetAll()).Returns(transactions);
            return stubTransactionRepository.Object;
        }

        private static MedicineRepository CreateMedicineStubRepository()
        {
            var stubMedicineRepository = new Mock<MedicineRepository>();
            var medicine = new Medicine { Id = 1, MedicineAmount = 25, MedicineIngredient = new List<string>(), MedicineStatus = MedicineStatus.approved, MedicineName = "Panklav" };
            stubMedicineRepository.Setup(m => m.Get(1)).Returns(medicine);
            return stubMedicineRepository.Object;
        }

        [Fact]
        public void Get_consumption_for_dates()
        {
            MedicineConsumptionService consumptionService = new MedicineConsumptionService(CreateMedicineStubRepository(), CreateTransactionStubRepository());

            var consumption = consumptionService.GetMedicineConsumptionForDates(new DateTime(2021, 11, 15), new DateTime(2021, 11, 25));

            Assert.NotEmpty(consumption);
        }

        [Fact]
        public void Get_consumption_for_dates_empty()
        {
            MedicineConsumptionService consumptionService = new MedicineConsumptionService(CreateMedicineStubRepository(), CreateTransactionStubRepository());

            var consumption = consumptionService.GetMedicineConsumptionForDates(new DateTime(2021, 11, 10), new DateTime(2021, 11, 15));

            Assert.Empty(consumption);
        }
    }
}
