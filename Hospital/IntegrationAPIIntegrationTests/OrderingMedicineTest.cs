using IntegrationAPI.Controllers;
using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.DatabaseRepository;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntegrationAPIIntegrationTests
{
    public class OrderingMedicineTest
    {

        [Fact]
        public void search_medicine_found()
        {
            var stubRepositoryPharmacy = new Mock<PharmacyRepository>();
            var stubRepositoryMedicine = new Mock<MedicineRepository>();
            var stubRepositoryTransaction = new Mock<MedicineTransactionRepository>();
            var pharmacies = new List<Pharmacy>();

            pharmacies.Add(new Pharmacy("http://localhost:29631", "Flos", "Bulevar Oslobodjenja, Novi Sad", "bc56df25-0d34-4801-b76a-931e61b4c752", "108817cf-dc25-40f4-a18f-244c1315840a", "", "", 0));
            stubRepositoryPharmacy.Setup(p => p.GetAll()).Returns(pharmacies);
            IPharmacyService pharmacyService = new PharmacyService(stubRepositoryPharmacy.Object);
            IMedicineTransactionService medicineTransactionService = new MedicineTransactionService(stubRepositoryTransaction.Object); 
            MedicineService medicineService = new MedicineService(stubRepositoryMedicine.Object, pharmacyService, medicineTransactionService);

            List<Pharmacy> retVal = medicineService.searchMedicine("panklav", 1);

            Assert.True(retVal.Count.ToString().Equals("1"));
        }

        [Fact]
        public void search_medicine_not_found()
        {
            var stubRepositoryPharmacy = new Mock<PharmacyRepository>();
            var stubRepositoryMedicine = new Mock<MedicineRepository>();
            var stubRepositoryTransaction = new Mock<MedicineTransactionRepository>();
            var pharmacies = new List<Pharmacy>();

            pharmacies.Add(new Pharmacy("http://localhost:29631", "Flos", "Bulevar Oslobodjenja, Novi Sad", "bc56df25-0d34-4801-b76a-931e61b4c752", "108817cf-dc25-40f4-a18f-244c1315840a", "", "", 0));
            stubRepositoryPharmacy.Setup(p => p.GetAll()).Returns(pharmacies);
            IPharmacyService pharmacyService = new PharmacyService(stubRepositoryPharmacy.Object);
            IMedicineTransactionService medicineTransactionService = new MedicineTransactionService(stubRepositoryTransaction.Object);
            MedicineService medicineService = new MedicineService(stubRepositoryMedicine.Object, pharmacyService, medicineTransactionService);
            List<Pharmacy> retVal = medicineService.searchMedicine("nepostojim", 1);

            Assert.True(retVal.Count.ToString().Equals("0"));
        }

        [Fact]
        public void search_medicine_found_GRPC()
        {
            MedicineController medicineController = new MedicineController(new MedicineService(new MedicineDbRepository(new IntegrationDbContext()), new PharmacyService(new PharmacyDbRepository(new IntegrationDbContext())), new MedicineTransactionService(new MedicineTransactionDbRepository(new IntegrationDbContext()))), new PharmacyService(new PharmacyDbRepository(new IntegrationDbContext())));

            bool retVal = medicineController.checkIfMedicineExistsGRPC(new MedicineSearchDTO("panklav",2, "108817cf-dc25-40f4-a18f-244c1315840a33"));

            Assert.True(retVal);
        }

        [Fact]
        public void search_medicine_not_found_GRPC()
        {
            MedicineController medicineController = new MedicineController(new MedicineService(new MedicineDbRepository(new IntegrationDbContext()), new PharmacyService(new PharmacyDbRepository(new IntegrationDbContext())), new MedicineTransactionService(new MedicineTransactionDbRepository(new IntegrationDbContext()))), new PharmacyService(new PharmacyDbRepository(new IntegrationDbContext())));

            bool retVal = medicineController.checkIfMedicineExistsGRPC(new MedicineSearchDTO("fraksiparin", 2, "108817cf-dc25-40f4-a18f-244c1315840a33"));

            Assert.False(retVal);
        }
    }
}
