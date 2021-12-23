using PharmacyLibrary.Tendering.Model;
using PharmacyLibrary.Tendering.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Service
{
    public class TenderResponseService 
    {
        private readonly ITenderResponseRepository tenderResponseRepository;
        private readonly ITenderResponsePublishService responsePublishService;
       

       
        public bool Add(TenderResponse tenderResponse)
        {
            throw new NotImplementedException();

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TenderResponse> Get()
        {
            throw new NotImplementedException();
        }

        public TenderResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TenderResponse tenderResponse)
        {
            throw new NotImplementedException();
        }
    }
}
