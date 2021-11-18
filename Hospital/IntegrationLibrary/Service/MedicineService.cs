using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
    public class MedicineService : IMedicineService
    {
        private MedicineRepository medicineRepository;
        
        public MedicineService(MedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        public void SetMedicine(Medicine medicine)
        {
            medicineRepository.Update(medicine);
        }

        public void AddMedicine(Medicine medicine)
        {
            medicine.Id = medicineRepository.GenerateId();
            medicineRepository.Save(medicine);
        }

        public void SetMedicineIngredients(Medicine medicine, List<MedicineIngredient> medicineIngredients)
        {
            foreach (MedicineIngredient ingredient in medicineIngredients)
            {
                medicine.AddMedicineIngredient(ingredient.Name);
            }
            //medicine.MedicineIngredient = medicineIngredients;
            medicineRepository.Update(medicine);
        }

        public List<Medicine> GetAllMedicine()
        {
            return medicineRepository.GetAll();
        }

        
        public void AddMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            medicine.MedicineIngredient.Add(medicineIngredient.Name);
            medicineRepository.Update(medicine);
        }

        public void RemoveMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            foreach(string mi in medicine.MedicineIngredient)
            {
                if (mi.Equals(medicineIngredient.Name))
                {
                    medicine.MedicineIngredient.Remove(mi);
                    break;
                }
            }
            medicineRepository.Update(medicine);
        }

        public void DeleteMedicine(Medicine medicine)
        {
            medicineRepository.Delete(medicine);
        }

        public Medicine GetMedicine(int id)
        {
            return medicineRepository.Get(id);
        }
    }
}
