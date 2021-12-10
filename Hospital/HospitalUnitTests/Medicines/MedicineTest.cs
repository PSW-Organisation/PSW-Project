using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Medicines.Repository;
using HospitalLibrary.Medicines.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HospitalAPI.Medicines.UnitTests
{
    public class MedicineTest
    {
         [Fact]
         public void Add_if_medicine_does_not_exsist()
         {
             var stubMedicineRepository = new Mock<IMedicineRepository>();
             Medicine medicine = new Medicine(-1, "panklav", 0, 5, new List<string>());
             stubMedicineRepository.Setup(m => m.GetMedicineByName("panklav")).Returns(medicine);
             MedicineService medicineService = new MedicineService(stubMedicineRepository.Object);

             Medicine ret = medicineService.Save(new Medicine(-1, "analgin", 0, 5, new List<string>()));

             Assert.False(ret.MedicineName.Equals(medicine.MedicineName));
         }

         [Fact]
         public void Do_Not_Add_if_medicine_exsist()
         {
             var stubMedicineRepository = new Mock<IMedicineRepository>();
             Medicine medicine = new Medicine(1, "panklav", 0, 5, new List<string>());
             stubMedicineRepository.Setup(m => m.GetMedicineByName("panklav")).Returns(medicine);
             MedicineService medicineService = new MedicineService(stubMedicineRepository.Object);

             Medicine ret = medicineService.Save(new Medicine(1, "panklav", 0, 3, new List<string>()));

             Assert.True(ret.MedicineName.Equals(medicine.MedicineName));
         }
    }
}
