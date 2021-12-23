using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Service.ServiceImpl
{
    public class TenderService : ITenderService
    {
        private readonly TenderRepository tenderRepository;
        private readonly ITenderPublishingService tenderPublishingService;

        public TenderService(TenderRepository tenderRepository, ITenderPublishingService tenderPublishingService)
        {
            this.tenderRepository = tenderRepository;
            this.tenderPublishingService = tenderPublishingService;
        }
        public bool Add(Tender tender)
        {
            tenderPublishingService.AnnounceTender(tender, "tenders");
            tenderRepository.Save(tender);
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tender> Get()
        {
            throw new NotImplementedException();
        }

        public Tender Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tender t)
        {
            throw new NotImplementedException();
        }
    }
}
