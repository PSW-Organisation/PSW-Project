using IntegrationLibrary.Statistics.Model;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Statistics.Service.ServiceImpl
{
    public interface IStatisticsService
    {
        public List<int> statisticPharmacyWinningsDefeat(string apiKey);
        public List<int> statisticPharmacyParticipation(String apiKey);
        public BarChartStatistic statisticPharmacyWinnerOffers(String apiKey);
        public BarChartStatistic statisticPharmacyAcitveTenderOffers(String apiKey);
        public BarChartTenderStatistic statisticTenderWinnerOffers(DateTime dateStart, DateTime dateEnd);
        public BarChartTenderStatistic statisticTenderPharmacyProfits(DateTime dateStart, DateTime dateEnd);
        public TwoBarChartStatistic statisticTenderWinningDefeat(DateTime dateStart, DateTime dateEnd);
        public TwoBarChartStatistic statisticTenderWinningParticipate(DateTime dateStart, DateTime dateEnd);
    }
}
