using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
   public  interface IComplaintService
    {
        public List<Complaint> GetAll();
        public Complaint Get(long id);
        public bool Save(Complaint complaint, string api);
        public bool Delete(long id);
    }
}
