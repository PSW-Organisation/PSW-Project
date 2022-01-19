using PharmacyAPI.Model;
using PharmacyLibrary.Repository.ComplaintRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class ComplaintService : IComplaintService
    {

        private IComplaintRepository complaintRepository;

        public ComplaintService(IComplaintRepository complaintRepository)
        {
            this.complaintRepository = complaintRepository;
        }
        public bool Delete(long complaint)
        {
           return complaintRepository.Delete(complaint);
        }

        public Complaint Get(long id)
        {
            return complaintRepository.Get(id);
        }

        public List<Complaint> GetAll()
        {
            return complaintRepository.Get();
        }

        public bool Save(Complaint complaint, string hApi)
        {
            return complaintRepository.Add(complaint, hApi);
        }
    }
}
