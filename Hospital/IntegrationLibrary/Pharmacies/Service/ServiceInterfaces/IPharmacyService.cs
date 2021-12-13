using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Service.ServiceInterfaces
{
    public interface IPharmacyService
    {
        public List<Pharmacy> GetAll();
        public Pharmacy Get(int id);
        public string Save(Pharmacy pharmacy);
        public void Delete(Pharmacy pharmacy);  
        public Pharmacy Update(Pharmacy pharmacy);
        public void UpdateHospitalApiKey(Pharmacy pharmacy, string updatedHospitalApiKey);
        public Pharmacy getPharmacyByApiKey(string apiKey);
    }
}
