using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public interface IAdsService
    {
        public List<Ad> GetAll();

        public Ad GetById(long id);

        public void Add(Ad newAd);

        public void Delete(long id);

       
    }
}
