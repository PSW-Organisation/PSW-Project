using PharmacyLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Service
{
    public interface ITenderService
    {
        public List<Tender> Get();

        public Tender Get(int id);

        public bool Add(Tender newHospital);

        public Boolean Delete(int id);

        public Boolean Update(Tender tender);
    }
}
