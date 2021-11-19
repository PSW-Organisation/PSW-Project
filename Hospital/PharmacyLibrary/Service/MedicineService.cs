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

            return medicineRepository.CheckIfExists(medicineName, medicineQuantity);
        }

        public int reduceQuantityOfMedicine(string medicineName, int medicineAmount)
        {
           return medicineRepository.reduceQuantityOfMedicine(medicineName, medicineAmount);
        }
        
        public List<Medicine> Search(string name, string useFor)
        {
            return medicineRepository.Search(name, useFor);
        }
    }
}
