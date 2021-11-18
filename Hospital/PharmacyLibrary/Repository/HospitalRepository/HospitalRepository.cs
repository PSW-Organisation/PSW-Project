using PharmacyAPI;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Repository.HospitalRepository
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly PharmacyDbContext pharmacyDbContext;
        public HospitalRepository(PharmacyDbContext pharmacyDbContext)
        {
            this.pharmacyDbContext = pharmacyDbContext;
        }
        public bool Add(Hospital newHospital)
        {
            long id = pharmacyDbContext.Hospitals.ToList().Count > 0 ? pharmacyDbContext.Hospitals.Max(hospital => hospital.HospitalId) + 1 : 1;
            newHospital.HospitalId = id;
            pharmacyDbContext.Hospitals.Add(newHospital);
            pharmacyDbContext.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            Hospital hospital = pharmacyDbContext.Hospitals.SingleOrDefault(hospital => hospital.HospitalId == id);
            if (hospital == null)
            {
                return false;

            }
            else
            {
                pharmacyDbContext.Hospitals.Remove(hospital);
                pharmacyDbContext.SaveChanges();
                return true;
            }
        }

        public List<Hospital> Get()
        {
            List<Hospital> result = new List<Hospital>();
            pharmacyDbContext.Hospitals.ToList().ForEach(hospital => result.Add(hospital));
            return result;
        }

        public Hospital Get(long id)
        {
            Hospital hospital = pharmacyDbContext.Hospitals.FirstOrDefault(hospital => hospital.HospitalId == id);
            if (hospital == null)
            {
                return null;
            }
            else
            {
                return hospital;
            }
        }

        public bool Update(Hospital updatedHospital)
        {
            Hospital hospital = pharmacyDbContext.Hospitals.FirstOrDefault(hospital => hospital.HospitalId == updatedHospital.HospitalId);

            if ((hospital == null) || (updatedHospital.HospitalName.Length <= 0) || (updatedHospital.HospitalAddress.Length <= 0))
            {
                return false;
            }

            pharmacyDbContext.Update(updatedHospital);
            pharmacyDbContext.SaveChanges();
            return true;
        }
    }
}
