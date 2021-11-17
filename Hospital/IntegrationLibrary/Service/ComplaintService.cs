using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service
{
    public class ComplaintService : IComplaintService
    {
        private ComplaintRepository complaintRepository;

        public ComplaintService(ComplaintRepository complaintRepository)
        {
            this.complaintRepository = complaintRepository;
        }

        public void Delete(Complaint complaint)
        {
            this.complaintRepository.Delete(complaint);
        }

        public Complaint Get(int id)
        {
            return this.complaintRepository.Get(id);
        }

        public List<Complaint> GetAll()
        {
            return this.complaintRepository.GetAll();
        }

        public void Save(Complaint complaint)
        {
            complaint.Id = this.complaintRepository.GenerateId();
            this.complaintRepository.Save(complaint);
        }
    }
}
