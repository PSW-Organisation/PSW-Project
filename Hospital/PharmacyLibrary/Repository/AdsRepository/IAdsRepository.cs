using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository.AdsRepository
{
    public interface IAdsRepository
    {
        public List<Ad> GetAll();
        public void AddAd(Ad ad);
        public void DeleteAd(long adId);
        public Ad GetById(long adId);
    }
}
