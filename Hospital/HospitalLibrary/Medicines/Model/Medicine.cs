using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Medicines.Model
{
    public class Medicine : EntityDb
    {
        private String medicineName;
        private MedicineStatus medicineStatus;
        private int medicineAmount;
        private List<String> medicineIngredient;
        public Medicine() { }

        public Medicine(int id, String medicineName, MedicineStatus medicineStatus, int medicineAmount, List<String> medicineIngredient)
        {
            this.Id = id;
            this.medicineName = medicineName;
            this.medicineStatus = medicineStatus;
            this.medicineAmount = medicineAmount;
            this.medicineIngredient = medicineIngredient;
        }

        public string MedicineName { get => medicineName; set => medicineName = value; }
        public MedicineStatus MedicineStatus { get => medicineStatus; set => medicineStatus = value; }
        public int MedicineAmount { get => medicineAmount; set => medicineAmount = value; }
        public List<string> MedicineIngredient { get => medicineIngredient; set => medicineIngredient = value; }
    }
}
