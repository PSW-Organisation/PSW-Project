using PharmacyAPI.Model;
using PharmacyLibrary.Repository.MedicineRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        public bool Add(Medicine newMedicine)
        {
            return medicineRepository.Add(newMedicine);
        }

        public bool Delete(int id)
        {
            return medicineRepository.Delete(id);
        }

        public List<Medicine> Get()
        {
            return medicineRepository.Get();
        }

        public Medicine Get(int id)
        {
            return medicineRepository.Get(id);
        }

        public bool Update(Medicine m)
        {
            return medicineRepository.Update(m);
        }

        public bool CheckAvaliableQuantity(int idMedicine, int quantity)
        {
            return medicineRepository.CheckAvaliableQuantity(idMedicine, quantity);
        }

        public bool CheckIfExists(string medicineName, int medicineQuantity)
        {
            Medicine medicine = medicineRepository.FindByName(medicineName);
            if (medicine == null || medicine.Quantity < medicineQuantity)
            {
                return false;
            }

            return true;
        }

        public bool reduceQuantityOfMedicine(string medicineName, int medicineAmount)
        {
            Medicine medicine = medicineRepository.FindByName(medicineName);
            medicine.Quantity = medicine.Quantity - medicineAmount;
            medicineRepository.Update(medicine);
            return true;
        }

        public List<Medicine> Search(string name, string useFor)
        {
            return medicineRepository.Search(name, useFor);
        }
    }
}
