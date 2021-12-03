using Moq;
using PharmacyAPI.Model;
using PharmacyLibrary.Repository.MedicineRepository;
using PharmacyLibrary.Service;
using System;
using Xunit;

namespace PharmacyAPIUnitTests
{
    public class MedicineTest
    {
        [Fact]
        public void check_if_medicine_existsTrue()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();
            var medicine = new Medicine(0, "panklav", 0, 10);

            stubMedicineRepository.Setup(m => m.FindByName("panklav")).Returns(medicine);

            MedicineService medicineService = new MedicineService(stubMedicineRepository.Object);

            Boolean exists = medicineService.CheckIfExists("panklav", 1);

            Assert.True(exists);
        }

        [Fact]
        public void check_if_medicine_existsFalse()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();

            stubMedicineRepository.Setup(m => m.FindByName("panklav")).Returns(new Medicine(0, "panklav", 0, 10));

            MedicineService medicineService = new MedicineService(stubMedicineRepository.Object);

            Boolean exists = medicineService.CheckIfExists("panklav", 11);

            Assert.True(!exists);
        }

        /*[Fact]
        public void check_if_quantity_is_reduced()
        {
            var stubMedicineRepository = new Mock<IMedicineRepository>();

            stubMedicineRepository.Setup(m => m.FindByName("analgin")).Returns(new Medicine(0, "analgin", 0, 10));

            MedicineService medicineService = new MedicineService(stubMedicineRepository.Object);

            int quantity = medicineService.reduceQuantityOfMedicine("analgin", 1);

            Assert.True(quantity.ToString().Equals("9"));
        }*/

    }
}
