using PharmacyLibrary.Tendering.Model;
using PharmacyLibrary.Tendering.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Service
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository tenderRepository;
        public TenderService (ITenderRepository tenderRepository)
        {
            this.tenderRepository = tenderRepository;
        }
        public bool Add(Tender newHospital)
        {
            return this.tenderRepository.Add(newHospital);
        }

        public bool Delete(int id)
        {
            return this.tenderRepository.Delete(id);
        }

        public List<Tender> Get()
        {
            return this.tenderRepository.GetAll();
        }

        public Tender Get(int id)
        {
            return this.tenderRepository.Get(id);
        }

        public bool Update(Tender tender)
        {
            return this.tenderRepository.Update(tender);
        }
    }
}
