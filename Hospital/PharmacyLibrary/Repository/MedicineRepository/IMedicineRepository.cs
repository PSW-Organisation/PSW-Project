using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository.MedicineRepository
{
    public interface IMedicineRepository
    {
        List<Medicine> Get();

        Medicine Get(int id);

        Boolean Add(Medicine newMedicine);

        Boolean Delete(int id);

        Boolean Update(Medicine m);

        Boolean CheckAvaliableQuantity(int idMedicine, int quantity);
        
        Boolean CheckIfExists(string medicineName, int medicineQuantity);

        int reduceQuantityOfMedicine(string medicineName, int medicineAmount);

        List<Medicine> Search(string name, string useFor);
    }
}
