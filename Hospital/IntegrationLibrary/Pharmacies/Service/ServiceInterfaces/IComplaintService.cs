using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Service.ServiceInterfaces
{
    public interface IComplaintService
    {
        public List<Complaint> GetAll();
        public Complaint Get(int id);
        public void Save(Complaint complaint);
        public void Delete(Complaint complaint);
    }
}
