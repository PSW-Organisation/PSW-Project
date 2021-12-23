using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
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

        private readonly TenderItemRepository itemRepository;
        private readonly IPharmacyService pharmacyService;

        public TenderService(TenderRepository tenderRepository, TenderItemRepository itemRepository, ITenderPublishingService tenderPublishingService, IPharmacyService pharmacyService)
        {
            this.tenderRepository = tenderRepository;
            this.tenderPublishingService = tenderPublishingService;
            this.itemRepository = itemRepository;
            this.pharmacyService = pharmacyService;
        }
        public bool Add(Tender tender)
        {
            foreach (TenderItem tenderItem in tender.TenderItems)
            {
                tenderItem.Id = itemRepository.GenerateId();
                itemRepository.Save(tenderItem);
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
            tenderRepository.Update(t);
            return true;
        }

        public List<int> statisticPharmacyWinningsDefeat(string apiKey)
        {
            List<int> ret = new List<int>();
            int winn = 0;
            int lose = 0;
            List<Tender> tenders = this.tenderRepository.GetAll();

            foreach (Tender tender in tenders)
            {
                if (tender.ApiKeyPharmacy.Equals(apiKey))
                {
                    winn += 1;
                }
                else
                {
                    lose += 1;
                }
            }
            ret.Add(winn);
            ret.Add(lose);
            return ret;
        }

        public List<int> statisticPharmacyParticipation(String apiKey)
        {
            List<int> ret = new List<int>();
            int participate = 0;
            int noParticipate = 0;
            List<Tender> tenders = this.tenderRepository.GetAll();
            foreach (Tender tender in tenders)
            {
                foreach (TenderResponse response in tender.TenderResponses)
                {
                    if (response.Pharmacy.HospitalApiKey.Equals(apiKey))
                    {
                        participate += 1;
                        break;
                    }
                }
            }
            noParticipate = tenders.Count - participate;
            ret.Add(participate);
            ret.Add(noParticipate);
            return ret;
        }

        public BarChartStatistic statisticPharmacyWinnerOffers(String apiKey)
        {
            BarChartStatistic ret = new BarChartStatistic();
            List<double> offerPrices = new List<double>();
            List<DateTime> offerDate = new List<DateTime>();
            List<Tender> tenders = this.tenderRepository.GetAll();
            foreach (Tender tender in tenders)
            {
                if (!tender.Open)
                {
                    foreach (TenderResponse response in tender.TenderResponses)
                    {
                        if (response.Pharmacy.HospitalApiKey.Equals(apiKey) && response.IsWinner == true)
                        {
                            offerPrices.Add(response.TotalPrice);
                            offerDate.Add(response.ResponseReceivedTime);
                            break;
                        }
                    }
                }
            }
            ret.X = offerDate;
            ret.Y = offerPrices;
            return ret;
        }

        public BarChartStatistic statisticPharmacyAcitveTenderOffers(String apiKey)
        {
            BarChartStatistic ret = new BarChartStatistic();
            List<double> offerPrices = new List<double>();
            List<DateTime> offerDate = new List<DateTime>();
            List<Tender> tenders = this.tenderRepository.GetAll();
            foreach (Tender tender in tenders)
            {
                if (tender.Open)
                {
                    foreach (TenderResponse response in tender.TenderResponses)
                    {
                        if (response.Pharmacy.HospitalApiKey.Equals(apiKey))
                        {
                            offerPrices.Add(response.TotalPrice);
                            offerDate.Add(response.ResponseReceivedTime);
                            break;
                        }
                    }
                }
            }
            ret.X = offerDate;
            ret.Y = offerPrices;
            return ret;
        }

        public BarChartTenderStatistic statisticTenderWinnerOffers(DateTime dateStart, DateTime dateEnd)
        {
            BarChartTenderStatistic ret = new BarChartTenderStatistic();
            List<double> offerPrices = new List<double>();
            List<String> tenderNames = new List<String>();
            List<Tender> tenders = this.tenderRepository.GetAll();
            foreach (Tender tender in tenders)
            {
                if (!tender.Open)
                {
                    foreach (TenderResponse response in tender.TenderResponses)
                    {
                        if (response.IsWinner == true && tender.TenderOpenDate >= dateStart && tender.TenderCloseDate <= dateEnd)
                        {
                            offerPrices.Add(response.TotalPrice);
                            tenderNames.Add("Tender " + tender.Id.ToString());
                            break;
                        }
                    }
                }
            }
            ret.X = tenderNames;
            ret.Y = offerPrices;
            return ret;
        }

        public BarChartTenderStatistic statisticTenderPharmacyProfits(DateTime dateStart, DateTime dateEnd)
        {
            BarChartTenderStatistic ret = new BarChartTenderStatistic();
            List<double> offerPrices = new List<double>();
            List<String> pharmacyNames = new List<String>();
            List<Tender> tenders = this.tenderRepository.GetAll();

            foreach (Pharmacy pharmacy in this.pharmacyService.GetAll())
            {
                pharmacyNames.Add(pharmacy.PharmacyName);
                double profit = 0;
                foreach (Tender tender in tenders)
                {
                    if (!tender.Open && tender.TenderOpenDate >= dateStart && tender.TenderCloseDate <= dateEnd)
                    {
                        foreach (TenderResponse response in tender.TenderResponses)
                        {
                            if (response.Pharmacy.HospitalApiKey.Equals(pharmacy.HospitalApiKey) && response.IsWinner == true)
                            {
                                profit += response.TotalPrice;
                                break;
                            }
                        }
                    }
                }
                offerPrices.Add(profit);
            }
            ret.X = pharmacyNames;
            ret.Y = offerPrices;
            return ret;
        }

        public TwoBarChartStatistic statisticTenderWinningDefeat(DateTime dateStart, DateTime dateEnd)
        {
            List<int> winns = new List<int>();
            List<int> defeats = new List<int>();
            List<String> pharmacyNames = new List<string>();
            List<Tender> tenders = this.tenderRepository.GetAll();

            foreach (Pharmacy pharmacy in this.pharmacyService.GetAll())
            {
                pharmacyNames.Add(pharmacy.PharmacyName);
                int winn = 0;
                int defeat = 0;
                foreach (Tender tender in tenders)
                {
                    if (tender.ApiKeyPharmacy.Equals(pharmacy.HospitalApiKey))
                    {
                        winn += 1;
                    }
                    else
                    {
                        defeat += 1;
                    }
                }
                winns.Add(winn);
                defeats.Add(defeat);
            }

            return new TwoBarChartStatistic(pharmacyNames, winns, defeats);
        }

        public TwoBarChartStatistic statisticTenderWinningParticipate(DateTime dateStart, DateTime dateEnd)
        {
            List<int> participations = new List<int>();
            List<int> participationsNot = new List<int>();
            List<String> pharmacyNames = new List<string>();
            List<Tender> tenders = this.tenderRepository.GetAll();

            foreach (Pharmacy pharmacy in this.pharmacyService.GetAll())
            {
                pharmacyNames.Add(pharmacy.PharmacyName);
                int participate = 0;
                foreach (Tender tender in tenders)
                {
                    foreach (TenderResponse response in tender.TenderResponses)
                    {
                        if (response.PharmacyId == pharmacy.Id)
                        {
                            participate += 1;
                        }
                        break;
                    }
                }
                participations.Add(participate);
                participationsNot.Add(tenders.Count - participate);
            }

            return new TwoBarChartStatistic(pharmacyNames, participations, participationsNot);
        }
    }
}
