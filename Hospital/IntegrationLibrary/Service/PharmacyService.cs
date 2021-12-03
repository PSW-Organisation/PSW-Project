﻿using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service
{
    public class PharmacyService : IPharmacyService
    {
        private PharmacyRepository pharmacyRepository;

        public PharmacyService(PharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public void Delete(Pharmacy pharmacy)
        {
            this.pharmacyRepository.Delete(pharmacy);
        }

        public Pharmacy Get(int id)
        {
            return this.pharmacyRepository.Get(id);
        }

        public List<Pharmacy> GetAll()
        {
            return this.pharmacyRepository.GetAll();
        }

        public string Save(Pharmacy pharmacy)
        {
            pharmacy.Id = this.pharmacyRepository.GenerateId();

            pharmacy.PharmacyApiKey = this.GenerateApiKey();
            this.pharmacyRepository.Save(pharmacy);
            return pharmacy.PharmacyApiKey;
        }

        public void Update(Pharmacy pharmacy)
        {
            string[] separators = { "fakepath\\" };
            string[] pic = pharmacy.Picture.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
            pharmacy.Picture = pic[1];
            this.pharmacyRepository.Update(pharmacy);
        }

        public void UpdateHospitalApiKey(Pharmacy pharmacy, string updatedHospitalApiKey)
        {
            pharmacy.HospitalApiKey = updatedHospitalApiKey;
            this.pharmacyRepository.Update(pharmacy);
        }

        private string GenerateApiKey()
        {
            return System.Guid.NewGuid().ToString();
        }

        public Pharmacy getPharmacyByApiKey(string apiKey)
        {
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            foreach (Pharmacy pharmacy in GetAll())
            {
                if (pharmacy.HospitalApiKey.Equals(apiKey))
                    return pharmacy;
            }
            return null;
        }
    }
}
