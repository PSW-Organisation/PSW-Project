using PharmacyLibrary.Model;
using PharmacyLibrary.Repository.AdsRepository;
using PharmacyLibrary.Repository.MedicineRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class AdsService : IAdsService
    {
        IAdsRepository adsRepository;

        public AdsService(IAdsRepository repository)
        {
            this.adsRepository = repository;
        }
        public List<Ad> GetAll()
        {
            return adsRepository.GetAll();
        }
        public void Add(Ad ad)
        {
            adsRepository.AddAd(ad);
        }
        public void Delete(long adId)
        {
            adsRepository.DeleteAd(adId);
        }
        public Ad GetById(long adId)
        {
            return adsRepository.GetById(adId);
        }

    }
}
