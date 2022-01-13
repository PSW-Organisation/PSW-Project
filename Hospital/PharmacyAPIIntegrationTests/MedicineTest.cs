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
        private bool skippable = Environment.GetEnvironmentVariable("SkippableTest") != null;

        [SkippableFact]
        public void check_if_medicine_existsTrue()
        {
            Skip.If(skippable);
            IMedicineRepository stubMedicineRepository = new MedicineRepository(new PharmacyDbContext());

            MedicineService medicineService = new MedicineService(stubMedicineRepository);

            Boolean exists = medicineService.CheckIfExists("panklav", 1);

            Assert.True(exists);
        }

        [SkippableFact]
        public void check_if_medicine_existsFalse()
        {
            Skip.If(skippable);
            IMedicineRepository stubMedicineRepository = new MedicineRepository(new PharmacyDbContext());

            MedicineService medicineService = new MedicineService(stubMedicineRepository);

            Boolean exists = medicineService.CheckIfExists("analgin", 11);

            Assert.True(!exists);
        }

    }
}
