using Microsoft.EntityFrameworkCore;
using PharmacyAPI;
using PharmacyAPI.Model;
using PharmacyLibrary.Repository.MedicineRepository;
using PharmacyLibrary.Service;
using System;
using Xunit;

namespace PharmacyAPIIntegrationTests
{
    public class MedicineTest
    {
        [Fact]
        public void check_if_medicine_existsTrue()
        {
            IMedicineRepository stubMedicineRepository = new MedicineRepository(new PharmacyDbContext());

            MedicineService medicineService = new MedicineService(stubMedicineRepository);

            Boolean exists = medicineService.CheckIfExists("panklav", 1);

            Assert.True(exists);
        }

        [Fact]
        public void check_if_medicine_existsFalse()
        {
            IMedicineRepository stubMedicineRepository = new MedicineRepository(new PharmacyDbContext());

            MedicineService medicineService = new MedicineService(stubMedicineRepository);

            Boolean exists = medicineService.CheckIfExists("panklav", 11);

            Assert.True(!exists);
        }

    }
}
