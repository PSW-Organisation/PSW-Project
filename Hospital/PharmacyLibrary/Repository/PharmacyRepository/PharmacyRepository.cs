using PharmacyAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Repository.PharmacyRepository
{
    public class PharmacyRepository:IPharmacyRepository
    {
        private readonly PharmacyDbContext pharmacyDbContext;

        public PharmacyRepository(PharmacyDbContext pharmacyDbContext)
        {
            this.pharmacyDbContext = pharmacyDbContext;
        }

        public List<Pharmacy> Get()
        {
            List<Pharmacy> result = new List<Pharmacy>();
            pharmacyDbContext.Pharmacies.ToList().ForEach(pharmacy => result.Add(pharmacy));
            return result;
        }

        public Pharmacy Get(long id)
        {
            Pharmacy pharmacy = pharmacyDbContext.Pharmacies.FirstOrDefault(pharmacy => pharmacy.PharmacyId == id);
            if (pharmacy == null)
            {
                return null;
            }
            else
            {
                return pharmacy;
            }
        }
        
        public Boolean Add(Pharmacy newPharmacy)
        {
            if (newPharmacy.PharmacyName.Length <= 0 || newPharmacy.PharmacyUrl.Length <= 0 || newPharmacy.PharmacyAddress.Length <= 0)
            {
                return false;
            }
            long id = pharmacyDbContext.Pharmacies.ToList().Count > 0 ? pharmacyDbContext.Pharmacies.Max(pharmacy => pharmacy.PharmacyId) + 1 : 1;

            Pharmacy pharmacy = newPharmacy;
            pharmacy.PharmacyId = id;
            string apiKey = GenerateApiKey();
            pharmacy.PharmacyApiKey = apiKey;
            pharmacyDbContext.Pharmacies.Add(pharmacy);
            pharmacyDbContext.SaveChanges();
            return true;
        }

        public Boolean Delete(long id)
        {
            Pharmacy pharmacy = pharmacyDbContext.Pharmacies.SingleOrDefault(pharmacy => pharmacy.PharmacyId == id);
            if (pharmacy == null)
            {
                return false;

            }
            else
            {
                pharmacyDbContext.Pharmacies.Remove(pharmacy);
                pharmacyDbContext.SaveChanges();
                return true;
            }
        }

        public Boolean Update(Pharmacy p)
        {
            Pharmacy pharmacy = pharmacyDbContext.Pharmacies.FirstOrDefault(pharmacy => pharmacy.PharmacyId == p.PharmacyId);
            if ( (pharmacy == null) || (p.PharmacyName.Length <= 0 && p.PharmacyUrl.Length <= 0 && p.PharmacyAddress.Length <= 0 && p.PharmacyApiKey.Length <= 0) )
            {
                return false;
            }

            if (p.PharmacyName.Length > 0)
            {
                pharmacy.PharmacyName = p.PharmacyName;
            }
            else if (p.PharmacyUrl.Length > 0)
            {
                pharmacy.PharmacyUrl = p.PharmacyUrl;
            }
            else if (p.PharmacyAddress.Length > 0)
            {
                pharmacy.PharmacyAddress = p.PharmacyAddress;
            }
            else
            {
                pharmacy.PharmacyApiKey = p.PharmacyApiKey;
            }

            pharmacyDbContext.Update(pharmacy);
            pharmacyDbContext.SaveChanges();
            return true;
        }


        private string GenerateApiKey()
        {
            return System.Guid.NewGuid().ToString();
        }
    }
}
