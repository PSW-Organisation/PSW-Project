using PharmacyAPI;
using PharmacyLibrary.Tendering.Model;
using PharmacyLibrary.Tendering.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Tendering.Repository.RepoImpl
{
    public class TenderResponseRepository : ITenderResponseRepository
    {
        private readonly PharmacyDbContext pharmacyDbContext;

        private TenderResponseRepository(PharmacyDbContext pharmacyDbContext)
        {
            this.pharmacyDbContext = pharmacyDbContext;
        }
        public bool Add(TenderResponse tender)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TenderResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TenderResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(TenderResponse tender)
        {
            throw new NotImplementedException();
        }
    }
}
