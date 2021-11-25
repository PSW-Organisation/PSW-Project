using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class MedicineBenefit
    {
        private int medicineBenefitId;
        private string medicineBenefitTitle;
        private string medicineBenefitContent;
        private DateTime medicineBenefitDueDate;
        private int medicineId;

        public int Id { get => medicineBenefitId; set => medicineBenefitId = value; }
        public string MedicineBenefitTitle { get => medicineBenefitTitle; set => medicineBenefitTitle = value; }

        public string MedicineBenefitContent { get => medicineBenefitContent; set => medicineBenefitContent = value; }
        public DateTime MedicineBenefitDueDate { get => medicineBenefitDueDate; set => medicineBenefitDueDate = value; }
        public int MedicineId { get => medicineId; set => medicineId = value; }
    }
}
