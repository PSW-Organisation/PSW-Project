using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
    public class MedicineIngredientService
    {
        private MedicineIngredientRepository medIngRepository;

        public MedicineIngredientService()
        {
            medIngRepository = new MedicineIngredientRepository();
        }

        public MedicineIngredient GetMedicineIngredientById(String id)
        {
            return medIngRepository.GetMedicineIngredientById(id);
        }

        public List<MedicineIngredient> GetAllMedicineIngredients()
        {
            return medIngRepository.GetAllMedicineIngredients();
        }

        public void DeleteMedicineIngredient(MedicineIngredient MedicineIngredient)
        {
            medIngRepository.DeleteMedicineIngredient(MedicineIngredient);
        }
      


        public void CreateMedicineIngredient(MedicineIngredient MedicineIngredient)
        {
            medIngRepository.NewMedicineIngredient(MedicineIngredient);
        }

       


        public void SetMedicineIngredient(MedicineIngredient MedicineIngredient)
        {
            medIngRepository.SetMedicineIngredient(MedicineIngredient);
        }



    }
}