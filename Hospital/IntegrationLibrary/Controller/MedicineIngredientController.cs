using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class MedicineIngredientController
    {
        private MedicineIngredientService MedicineIngredientService;

        public MedicineIngredientController()
        {
            MedicineIngredientService = new MedicineIngredientService();
        }

        public MedicineIngredient GetMedicineIngredientById(String id)
        {
            return MedicineIngredientService.GetMedicineIngredientById(id);
        }

        public List<MedicineIngredient> GetAllMedicineIngredients()
        {
            return MedicineIngredientService.GetAllMedicineIngredients();
        }

        public void DeleteMedicineIngredient(MedicineIngredient MedicineIngredient)
        {
            MedicineIngredientService.DeleteMedicineIngredient(MedicineIngredient);
        }
        

        public void CreateMedicineIngredient(MedicineIngredient MedicineIngredient)
        {
            MedicineIngredientService.CreateMedicineIngredient(MedicineIngredient);
        }

        public void SetMedicineIngredient(MedicineIngredient MedicineIngredient)
        {
            MedicineIngredientService.SetMedicineIngredient(MedicineIngredient);
        }

      

    }
}
