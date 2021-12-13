using IntegrationLibrary.Model;
using IntegrationLibrary.SharedModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Parnership.Model
{
    public class MedicineBenefit : Entity
    {
        private string medicineBenefitTitle;
        private string medicineBenefitContent;
        private DateTime medicineBenefitDueDate;
        private int medicineId;
        private bool published;

        public MedicineBenefit() :base(-1) { }
        public string MedicineBenefitTitle { get => medicineBenefitTitle; set => medicineBenefitTitle = value; }

        public string MedicineBenefitContent { get => medicineBenefitContent; set => medicineBenefitContent = value; }
        public DateTime MedicineBenefitDueDate { get => medicineBenefitDueDate; set => medicineBenefitDueDate = value; }
        public int MedicineId { get => medicineId; set => medicineId = value; }
        public bool Published { get => published; set => published = value; }
    }
}
