using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository.HospitalRepository
{
    public interface IHospitalRepository
    {
        public List<Hospital> Get();

        public Hospital Get(long id);

        public Boolean Add(Hospital newHospital);

        public Boolean Delete(long id);

        public Boolean Update(Hospital hospital);
    }
}
