using PharmacyAPI.Model;
using PharmacyLibrary.Repository.HospitalRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository hospitalRepository;
        public HospitalService(IHospitalRepository hospitalRepository)
        {
            this.hospitalRepository = hospitalRepository;
        }
        private string GenerateApiKey()
        {
            return System.Guid.NewGuid().ToString();
        }

        public string Add(Hospital newHospital)
        {
            string apiKey = GenerateApiKey();
            newHospital.HospitalApiKey = apiKey;
            hospitalRepository.Add(newHospital);
            return apiKey;
        }

        public bool Delete(long id)
        {
            return hospitalRepository.Delete(id);
        }

        public List<Hospital> Get()
        {
            return hospitalRepository.Get();
        }

        public Hospital Get(long id)
        {
            return hospitalRepository.Get(id);
        }

        public bool Update(Hospital hospital)
        {
            return hospitalRepository.Update(hospital);
        }
    }
}
