using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository.ComplaintRepository
{
   public interface IComplaintRepository
    {
        List<Complaint> Get();

        Complaint Get(long id);

        Boolean Add(Complaint newMedicine, string hospitalApi);

        Boolean Delete(long id);

        Boolean Update(Complaint m);

  

    }
}
