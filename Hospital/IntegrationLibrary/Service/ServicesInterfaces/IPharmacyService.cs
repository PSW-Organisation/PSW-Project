using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IPharmacyService
    {
        public List<Pharmacy> GetAll();
        public Pharmacy Get(int id);
        public string Save(Pharmacy pharmacy);
        public void Delete(Pharmacy pharmacy);  
        public void Update(Pharmacy pharmacy);
        public void UpdateHospitalApiKey(Pharmacy pharmacy, string updatedHospitalApiKey);
      
    }
}
