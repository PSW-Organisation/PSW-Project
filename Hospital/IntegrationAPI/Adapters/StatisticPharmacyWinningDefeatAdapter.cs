using IntegrationAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class StatisticPharmacyWinningDefeatAdapter
    {
        public static StatisticPharmacyWinningDefeatDTO ToStatisticPharmacyWinningDefeatDTO(List<int> statistic)
        {
            StatisticPharmacyWinningDefeatDTO dto = new StatisticPharmacyWinningDefeatDTO();
            dto.Statistic = statistic;
            return dto;
        }
    }
}
