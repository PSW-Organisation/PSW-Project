using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Model
{
    public class MedicineAd
    {
        public long Id { get; set; }
        public long MedicineId { get; set; }
        public double PromotionPrice { get; set; }
        public MedicineAd() { }

        public MedicineAd(long id, long medicineId, double promotionPrice)
        {
            Id = id;
            MedicineId = medicineId;
            PromotionPrice = promotionPrice;
        }
    }
}
