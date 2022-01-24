using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Service.ServiceInterfaces;
using IntegrationLibrary.Statistics.Model;
using IntegrationLibrary.Statistics.Service.ServiceImpl;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Statistics.Service.ServiceInterfaces
{
    public class StatisticsService : IStatisticsService
    {
        private readonly TenderRepository tenderRepository;
        private readonly IPharmacyService pharmacyService;

        public StatisticsService(TenderRepository tenderRepository, IPharmacyService pharmacyService)
        {
            this.tenderRepository = tenderRepository;
            this.pharmacyService = pharmacyService;
        }

        public List<int> statisticPharmacyParticipation(String apiKey)
        {
            List<int> ret = new List<int>();
            List<Tender> tenders = this.tenderRepository.GetAll();
            int participate = 0;
            foreach (Tender tender in tenders)
            {
                participate = checkParticipationInResponses(apiKey, participate, tender);
            }
            ret.Add(participate);
            ret.Add(tenders.Count - participate);
            return ret;
        }

        private static int checkParticipationInResponses(string apiKey, int participate, Tender tender)
        {
            foreach (TenderResponse response in tender.TenderResponses)
            {
                if (response.Pharmacy.HospitalApiKey.Equals(apiKey))
                {
                    participate += 1;
                    break;
                }
            }
            return participate;
        }

        public BarChartStatistic statisticPharmacyWinnerOffers(String apiKey)
        {
            List<double> offerPrices = new List<double>();
            List<DateTime> offerDate = new List<DateTime>();
            foreach (Tender tender in this.tenderRepository.GetAll())
            {
                if (!tender.Open)
                {
                    checkPharmacyWinnerPerResponse(apiKey, offerPrices, offerDate, tender);
                }
            }
            return new BarChartStatistic(offerDate, offerPrices);
        }

        private static void checkPharmacyWinnerPerResponse(string apiKey, List<double> offerPrices, List<DateTime> offerDate, Tender tender)
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

        public BarChartStatistic statisticPharmacyAcitveTenderOffers(String apiKey)
        {
            List<double> offerPrices = new List<double>();
            List<DateTime> offerDate = new List<DateTime>();
            foreach (Tender tender in this.tenderRepository.GetAll())
            {
                if (tender.Open)
                {
                    checkActiveTenderOffers(apiKey, offerPrices, offerDate, tender);
                }
            }
            return new BarChartStatistic(offerDate, offerPrices);
        }

        private static void checkActiveTenderOffers(string apiKey, List<double> offerPrices, List<DateTime> offerDate, Tender tender)
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

        public BarChartTenderStatistic statisticTenderWinnerOffers(DateTime dateStart, DateTime dateEnd)
        {
            List<double> offerPrices = new List<double>();
            List<String> tenderNames = new List<String>();
            foreach (Tender tender in this.tenderRepository.GetAll())
            {
                if (!tender.Open)
                {
                    checkWinnerOffers(dateStart, dateEnd, offerPrices, tenderNames, tender);
                }
            }
            return new BarChartTenderStatistic(tenderNames, offerPrices);
        }

        private static void checkWinnerOffers(DateTime dateStart, DateTime dateEnd, List<double> offerPrices, List<string> tenderNames, Tender tender)
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

        public BarChartTenderStatistic statisticTenderPharmacyProfits(DateTime dateStart, DateTime dateEnd)
        {
            List<double> offerPrices = new List<double>();
            List<String> pharmacyNames = new List<String>();
            foreach (Pharmacy pharmacy in this.pharmacyService.GetAll())
            {
                pharmacyNames.Add(pharmacy.PharmacyName);
                double profit = 0;
                profit = checkPharmacyProfits(dateStart, dateEnd, pharmacy, profit);
                offerPrices.Add(profit);
            }
            return new BarChartTenderStatistic(pharmacyNames, offerPrices);
        }

        private double checkPharmacyProfits(DateTime dateStart, DateTime dateEnd, Pharmacy pharmacy, double profit)
        {
            foreach (Tender tender in this.tenderRepository.GetAll())
            {
                if (!tender.Open && tender.TenderOpenDate >= dateStart && tender.TenderCloseDate <= dateEnd)
                {
                    profit = checkProfitsInResponses(pharmacy, profit, tender);
                }
            }
            return profit;
        }

        private static double checkProfitsInResponses(Pharmacy pharmacy, double profit, Tender tender)
        {
            foreach (TenderResponse response in tender.TenderResponses)
            {
                if (response.Pharmacy.HospitalApiKey.Equals(pharmacy.HospitalApiKey) && response.IsWinner == true)
                {
                    profit += response.TotalPrice;
                    break;
                }
            }
            return profit;
        }

        public List<int> statisticPharmacyWinningsDefeat(string apiKey)
        {
            List<int> ret = new List<int>();
            int winn = 0;
            int lose = 0;

            foreach (Tender tender in this.tenderRepository.GetAll())
            {
                checkWinnOrLose(apiKey, ref winn, ref lose, tender);
            }
            ret.Add(winn);
            ret.Add(lose);
            return ret;
        }

        private static void checkWinnOrLose(string apiKey, ref int winn, ref int lose, Tender tender)
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

        public TwoBarChartStatistic statisticTenderWinningDefeat(DateTime dateStart, DateTime dateEnd)
        {
            List<int> winns = new List<int>();
            List<int> defeats = new List<int>();
            List<String> pharmacyNames = new List<string>();

            foreach (Pharmacy pharmacy in this.pharmacyService.GetAll())
            {
                checkWinningDefeatForPharmacy(winns, defeats, pharmacyNames, pharmacy);
            }

            return new TwoBarChartStatistic(pharmacyNames, winns, defeats);
        }

        private void checkWinningDefeatForPharmacy(List<int> winns, List<int> defeats, List<string> pharmacyNames, Pharmacy pharmacy)
        {
            pharmacyNames.Add(pharmacy.PharmacyName);
            int winn = 0;
            int defeat = 0;
            foreach (Tender tender in this.tenderRepository.GetAll())
            {
                checkWinnOrLose(pharmacy.HospitalApiKey, ref winn, ref defeat, tender);
            }
            winns.Add(winn);
            defeats.Add(defeat);
        }

        public TwoBarChartStatistic statisticTenderWinningParticipate(DateTime dateStart, DateTime dateEnd)
        {
            List<int> participations = new List<int>();
            List<int> participationsNot = new List<int>();
            List<String> pharmacyNames = new List<string>();
            List<Tender> tenders = this.tenderRepository.GetAll();

            foreach (Pharmacy pharmacy in this.pharmacyService.GetAll())
            {
                checkWinningParticipationForPharmacy(participations, participationsNot, pharmacyNames, tenders, pharmacy);
            }

            return new TwoBarChartStatistic(pharmacyNames, participations, participationsNot);
        }

        private static void checkWinningParticipationForPharmacy(List<int> participations, List<int> participationsNot, List<string> pharmacyNames, List<Tender> tenders, Pharmacy pharmacy)
        {
            pharmacyNames.Add(pharmacy.PharmacyName);
            int participate = 0;
            foreach (Tender tender in tenders)
            {
                checkParticipationInResponses(pharmacy.HospitalApiKey, participate, tender);
            }
            participations.Add(participate);
            participationsNot.Add(tenders.Count - participate);
        }
    }
}
