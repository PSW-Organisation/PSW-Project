using PharmacyAPI;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Repository.ComplaintRepository
{
    public class ComplaintRepository : IComplaintRepository
    {

        private readonly PharmacyDbContext pharmacyDbContex;

        public ComplaintRepository(PharmacyDbContext dbContext)
        {
            pharmacyDbContex = dbContext;
        }
        public bool Add(Complaint complaint,string hospitalApiKey)
        {
            List<Hospital> result = new List<Hospital>();
            pharmacyDbContex.Hospitals.ToList().ForEach(hospital => result.Add(hospital));
          
            foreach (Hospital hospital in result)
            {
                if (hospital.HospitalApiKey == hospitalApiKey)
                {

                    long id = pharmacyDbContex.Complaints.ToList().Count > 0 ? pharmacyDbContex.Complaints.Max(complaint => complaint.ComplaintId) + 1 : 1;
                    complaint.ComplaintId = id;
                    complaint.HospitalId = hospital.HospitalId;
                    pharmacyDbContex.Complaints.Add(complaint);
                    pharmacyDbContex.SaveChanges();
                    return true;
                }
            }
            return false;

        }

        public bool Delete(long id)
        {
            Complaint complaint = pharmacyDbContex.Complaints.SingleOrDefault(complaint => complaint.ComplaintId == id);
            if (complaint == null) return false;
            else
            {

                pharmacyDbContex.Complaints.Remove(complaint);
                pharmacyDbContex.SaveChanges();
                return true;
            }
        }

        public List<Complaint> Get()
        {
            List<Complaint> allComplaints = new List<Complaint>();
            pharmacyDbContex.Complaints.ToList().ForEach(complaint => allComplaints.Add(complaint));
            return allComplaints;
        }

        public Complaint Get(long id)
        {
            Complaint complaint = pharmacyDbContex.Complaints.SingleOrDefault(complaint => complaint.ComplaintId == id);
            if (complaint == null) return null;
            else
            {
                return complaint;
            }
        }

        public bool Update(Complaint m)
        {
            throw new NotImplementedException();
        }
    }
}
