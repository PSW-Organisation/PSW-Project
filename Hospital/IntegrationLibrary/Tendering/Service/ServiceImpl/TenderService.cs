﻿using IntegrationLibrary.Tendering.Model;
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
        private readonly TenderItemRepository itemRepository;

        public TenderService(TenderRepository tenderRepository, TenderItemRepository itemRepository, ITenderPublishingService tenderPublishingService)
        {
            this.tenderRepository = tenderRepository;
            this.tenderPublishingService = tenderPublishingService;
            this.itemRepository = itemRepository;
        }
        public bool Add(Tender tender)
        {
            int itemId = itemRepository.GenerateId();
            for (int i = 0; i < tender.TenderItems.Count; i++)
            {
                tender.TenderItems[i].Id = itemId + i;
            }
            tender.Id = tenderRepository.GenerateId();
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
            return tenderRepository.GetAll();
        }

        public Tender Get(int id)
        {
            return tenderRepository.Get(id);
        }

        public bool Update(Tender t)
        {
            throw new NotImplementedException();
        }
    }
}
