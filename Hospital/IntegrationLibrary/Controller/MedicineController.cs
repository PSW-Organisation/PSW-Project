﻿using ehealthcare.Model;
using ehealthcare.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class MedicineController
	{
		private IMedicineService medicineService;

		public MedicineController(IMedicineService medicineService)
		{
            this.medicineService = medicineService;
		}

        public void SetMedicine(Medicine medicine)
        {
            medicineService.SetMedicine(medicine);
        }

        public void AddMedicine(Medicine medicine)
        {
            medicineService.AddMedicine(medicine);
        }

        public void SetMedicineIngredients(Medicine medicine, List<MedicineIngredient> medicineIngredients)
        {
            medicineService.SetMedicineIngredients(medicine, medicineIngredients);
        }

        public List<Medicine> GetAllMedicines()
        {
            return medicineService.GetAllMedicines();
        }

        public void AddMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            medicineService.AddMedicineIngredient(medicine, medicineIngredient);
        }

        public void RemoveMedicineIngredient(Medicine medicine, MedicineIngredient medicineIngredient)
        {
            medicineService.RemoveMedicineIngredient(medicine, medicineIngredient);
        }
    }
}
