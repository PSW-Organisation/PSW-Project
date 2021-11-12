
using PharmacyAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository.PharmacyRepository
{
    public interface IPharmacyRepository
    {
       List<Pharmacy> Get();

       Pharmacy Get(long id);

       Boolean Add(Pharmacy newPharmacy);

       Boolean Delete(long id);
        Boolean Update(Pharmacy p);


    }
}
