using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IMedicineService
    {
        public void SetMedicine(Medicine medicine);
        public Medicine AddMedicine(Medicine medicine);
        public void SetMedicineIngredients(Medicine medicine, List<MedicineIngredient> medicineIngredients);
        public List<Medicine> GetAllMedicine();
        public void AddMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient);
        public void RemoveMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient);
        public void DeleteMedicine(Medicine id);
        public Medicine GetMedicine(int id);
        public List<Pharmacy> searchMedicine(string medicineName, int medicineAmount);
        public Medicine GetMedicineByName(string name);

       
    }
}
