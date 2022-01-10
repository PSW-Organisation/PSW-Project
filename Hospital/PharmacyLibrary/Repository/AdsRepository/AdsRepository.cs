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
        private readonly PharmacyDbContext pharmacyDbContext;

        public AdsRepository(PharmacyDbContext pharmacyDbContext)
        {
            this.pharmacyDbContext = pharmacyDbContext;
        }


        public void AddAd(Ad ad)
        {
            Ad newAd = pharmacyDbContext.Ads.ToList().FirstOrDefault(a => a.Id == ad.Id);
            if (newAd != null)
            {
                return;
            }
            foreach (MedicineAd medicineAd in ad.MedicinesOnPromotion)
            {
                pharmacyDbContext.MedicineAds.Add(medicineAd);
            }
            pharmacyDbContext.Ads.Add(ad);
            pharmacyDbContext.SaveChanges();
        }

        public void DeleteAd(long adId)
        {
            Ad adToDelete = pharmacyDbContext.Ads.ToList().FirstOrDefault(ad => ad.Id == adId);
            foreach (MedicineAd medicineAd in adToDelete.MedicinesOnPromotion)
            {
                pharmacyDbContext.MedicineAds.Remove(medicineAd);
            }
            pharmacyDbContext.Ads.Remove(adToDelete);
            pharmacyDbContext.SaveChanges();
        }

        public List<Ad> GetAll()
        {
            List<Ad> ads = new List<Ad>();
            pharmacyDbContext.Ads.ToList().ForEach(ad => ads.Add(ad));
            return ads;
        }

        public Ad GetById(long adId)
        {
            return pharmacyDbContext.Ads.ToList().FirstOrDefault(ad => ad.Id == adId);
        }
    }
}
