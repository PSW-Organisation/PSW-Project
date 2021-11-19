using PharmacyAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public interface IPharmacyService
    {
       public List<Pharmacy> Get();

        public Pharmacy Get(long id);

        public Boolean Add(Pharmacy newPharmacy);

        public Boolean Delete(long id);

        public Boolean Update(Pharmacy p);

    }
}
