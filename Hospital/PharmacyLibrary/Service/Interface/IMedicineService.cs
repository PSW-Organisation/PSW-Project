using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public interface IMedicineService
    {
        public List<Medicine> Get();

        public Medicine Get(int id);

        public Boolean Add(Medicine newMedicine);

        public Boolean Delete(int id);

        public Boolean Update(Medicine m);

        public Boolean CheckAvaliableQuantity(int idMedicine, int quantity);

        public Boolean CheckIfExists(string medicineName, int medicineQuantity);

        public int reduceQuantityOfMedicine(string medicineName, int medicineAmount);
        
        public List<Medicine> Search(string name, string useFor);
    }
}
