using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Service.ServiceImpl
{
    public class TenderResponseService : ITenderResponseService
    {
        private readonly TenderResponseRepository tenderResponseRepository;

        public TenderResponseService(TenderResponseRepository tenderResponseRepository)
        {
            this.tenderResponseRepository = tenderResponseRepository;
        }

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
            return tenderResponseRepository.Get(id);
        }

        public bool Update(TenderResponse tenderResponse)
        {
            this.tenderResponseRepository.Update(tenderResponse);
            return true;
        }
    }
}
