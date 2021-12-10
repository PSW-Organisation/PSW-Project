using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Medicines.Model
{
    public class Medicine : EntityDb
    {
        public String medicineName { get; set; }
        public MedicineStatus medicineStatus { get; set; }
        public int medicineAmount { get; set; }
        public List<String> medicineIngredient { get; set; }
        public Medicine() { }

        public Medicine(int id, String medicineName, MedicineStatus medicineStatus, int medicineAmount, List<String> medicineIngredient)
        {
            this.Id = id;
            this.medicineName = medicineName;
            this.medicineStatus = medicineStatus;
            this.medicineAmount = medicineAmount;
            this.medicineIngredient = medicineIngredient;
        }
    }
}
