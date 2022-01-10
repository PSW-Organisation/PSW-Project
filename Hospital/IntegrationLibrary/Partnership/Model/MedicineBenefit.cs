using Castle.Core.Internal;
using IntegrationLibrary.Model;
using IntegrationLibrary.SharedModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Parnership.Model
{
    public class MedicineBenefit : Entity
    {
        public string MedicineBenefitTitle { get;  set; }
        public string MedicineBenefitContent { get;  set; }
        public DateTime MedicineBenefitDueDate { get;  set; }
        public int MedicineId { get;  set; }
        public bool Published { get; private set; }

        public MedicineBenefit() :base(-1) { }
        public MedicineBenefit(int id, string title, string content, DateTime date, int medicineId, bool published) : base(id)
        {
            ValidateOffer(content, title);
            Id = id;
            MedicineBenefitTitle = title;
            MedicineBenefitContent = content;
            MedicineBenefitDueDate = date;
            MedicineId = medicineId;
            Published = published;

        }
        public void PublishBenefit()
        {
            Published = true;
        }

        public void UnpublishBenefit()
        {
            Published = false;
        }


        private static void ValidateOffer(string content, string title)
        {
            if (content.IsNullOrEmpty()) throw new ArgumentException("Benefit content must be defined");
            if (title.IsNullOrEmpty()) throw new ArgumentException("Benefit title must be defined");

        }
    }
}
