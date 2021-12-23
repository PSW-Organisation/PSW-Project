using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Service.ServiceInterfaces
{
    public interface ITenderService
    {
        public List<Tender> Get();

        public Tender Get(int id);

        public Boolean Add(Tender tender);

        public Boolean Delete(int id);

        public Boolean Update(Tender t);

        public List<int> statisticPharmacyWinningsDefeat(String apiKey);

        public List<int> statisticPharmacyParticipation(String apiKey);

        public BarChartStatistic statisticPharmacyWinnerOffers(String apiKey);

        public BarChartStatistic statisticPharmacyAcitveTenderOffers(String apiKey);
        public BarChartTenderStatistic statisticTenderWinnerOffers(DateTime dateStart, DateTime dateEnd);
        public BarChartTenderStatistic statisticTenderPharmacyProfits(DateTime dateStart, DateTime dateEnd);
        public TwoBarChartStatistic statisticTenderWinningDefeat(DateTime dateStart, DateTime dateEnd);
        public TwoBarChartStatistic statisticTenderWinningParticipate(DateTime dateStart, DateTime dateEnd);
    }
}
