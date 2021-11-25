using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntegrationAPIUnitTests
{
    public class MedicineTest
    { 
        [Fact]
        public void Add_if_medicine_does_not_exsist()
        {
            var stubMedicineRepository = new Mock<MedicineRepository>();
            var stubTransactionRepository = new Mock<MedicineTransactionRepository>();
            var stubRepositoryPharmacy = new Mock<PharmacyRepository>();
            stubMedicineRepository.Setup(m => m.GetMedicineByName("panklav")).Returns(new Medicine(-1, "panklav", 0, 5));
            IMedicineTransactionService medicineTransactionService = new MedicineTransactionService(stubTransactionRepository.Object);
            IPharmacyService pharmacyService = new PharmacyService(stubRepositoryPharmacy.Object);
            MedicineService medicineService = new MedicineService(stubMedicineRepository.Object, pharmacyService, medicineTransactionService);

            Medicine ret = medicineService.AddMedicine(new Medicine(-1, "analgin", 0, 5));

            Assert.NotNull(ret);
        }

        [Fact]
        public void Do_Not_Add_if_medicine_exsist()
        {
            var stubMedicineRepository = new Mock<MedicineRepository>();
            var stubTransactionRepository = new Mock<MedicineTransactionRepository>();
            var stubRepositoryPharmacy = new Mock<PharmacyRepository>();
            stubMedicineRepository.Setup(m => m.GetMedicineByName("panklav")).Returns(new Medicine(1, "panklav", 0, 5));
            IMedicineTransactionService medicineTransactionService = new MedicineTransactionService(stubTransactionRepository.Object);
            IPharmacyService pharmacyService = new PharmacyService(stubRepositoryPharmacy.Object);
            MedicineService medicineService = new MedicineService(stubMedicineRepository.Object, pharmacyService, medicineTransactionService);

            Medicine ret = medicineService.AddMedicine(new Medicine(1, "panklav", 0, 3));

            Assert.Null(ret);
        }

    }
}
