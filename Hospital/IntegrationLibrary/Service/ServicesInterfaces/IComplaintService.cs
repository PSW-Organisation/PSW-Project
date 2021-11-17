using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IComplaintService
    {
        public List<Complaint> GetAll();
        public Complaint Get(int id);
        public void Save(Complaint complaint);
        public void Delete(Complaint complaint);
    }
}
