using PharmacyAPI;
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Repository.AdsRepository
{
    public class AdsRepository : IAdsRepository
    {
        private PharmacyDbContext dbContext = new PharmacyDbContext();
        public void AddAd(Ad ad)
        {
            Ad newAd = dbContext.Ads.ToList().FirstOrDefault(a => a.Id == ad.Id);
            if (newAd != null)
            {
                return;
            }
            foreach (MedicineAd medicineAd in ad.MedicinesOnPromotion)
            {
                dbContext.MedicineAds.Add(medicineAd);
            }
            dbContext.Ads.Add(ad);
            dbContext.SaveChanges();
        }

        public void DeleteAd(long adId)
        {
            Ad adToDelete = dbContext.Ads.ToList().FirstOrDefault(ad => ad.Id == adId);
            foreach (MedicineAd medicineAd in adToDelete.MedicinesOnPromotion)
            {
                dbContext.MedicineAds.Remove(medicineAd);
            }
            dbContext.Ads.Remove(adToDelete);
            dbContext.SaveChanges();
        }

        public List<Ad> GetAll()
        {
            List<Ad> ads = new List<Ad>();
            dbContext.Ads.ToList().ForEach(ad => ads.Add(ad));
            return ads;
        }

        public Ad GetById(long adId)
        {
            return dbContext.Ads.ToList().FirstOrDefault(ad => ad.Id == adId);
        }
    }
}
