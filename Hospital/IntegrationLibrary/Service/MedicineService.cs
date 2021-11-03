using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class MedicineService
    {
        private MedicineRepository medicineRepository;
        
        public MedicineService()
        {
            medicineRepository = new MedicineXMLRepository();
        }

        public void SetMedicine(Medicine medicine)
        {
            medicineRepository.Update(medicine);
        }

        public void AddMedicine(Medicine medicine)
        {
            medicineRepository.Save(medicine);
        }

        public void SetMedicineIngredients(Medicine medicine, List<MedicineIngredient> medicineIngredients)
        {
            medicine.MedicineIngredient = medicineIngredients;
            medicineRepository.Update(medicine);
        }

        public List<Medicine> GetAllMedicines()
        {
            return medicineRepository.GetAll();
        }

        
        public void AddMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            medicine.MedicineIngredient.Add(medicineIngredient);
            medicineRepository.Update(medicine);
        }

        public void RemoveMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            foreach(MedicineIngredient mi in medicine.MedicineIngredient)
            {
                if (mi.Equals(medicineIngredient))
                {
                    medicine.MedicineIngredient.Remove(mi);
                    break;
                }
            }
            medicineRepository.Update(medicine);
        }

        public void DeleteMedicine(string id)
        {
            medicineRepository.Delete(id);
        }
    }
}
