using PharmacyAPI;
using PharmacyLibrary.Repository.PharmacyRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public bool Add(Pharmacy newPharmacy)
        {
            return pharmacyRepository.Add(newPharmacy);
        }

        public bool Delete(long id)
        {
            return pharmacyRepository.Delete(id);
        }

        public List<Pharmacy> Get()
        {
            return pharmacyRepository.Get();
        }

        public Pharmacy Get(long id)
        {
            return pharmacyRepository.Get(id);
        }

        public bool Update(Pharmacy p)
        {
            return pharmacyRepository.Update(p);
        }
    }
}
