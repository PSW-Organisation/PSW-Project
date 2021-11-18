using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public interface IHospitalService
    {
        public List<Hospital> Get();

        public Hospital Get(long id);

        public string Add(Hospital newHospital);

        public Boolean Delete(long id);

        public Boolean Update(Hospital hospital);
    }
}
