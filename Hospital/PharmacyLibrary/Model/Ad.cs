using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class Ad
    {
        public long Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? PromotionEndTime { get; set; }
        public virtual ICollection<MedicineAd> MedicinesOnPromotion { get; set; }

        public Ad() { }

        public Ad(long id, string title, string content, DateTime creationDate, DateTime promotionEndTime, ICollection<MedicineAd> medicinesOnPromotion)
        {
            Id = id;
            Title = title;
            Content = content;
            CreationDate = creationDate;
            PromotionEndTime = promotionEndTime;
            MedicinesOnPromotion = medicinesOnPromotion;
        }
    }
}
