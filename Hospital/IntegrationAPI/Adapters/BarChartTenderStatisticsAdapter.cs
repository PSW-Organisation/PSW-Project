using IntegrationAPI.DTO;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class BarChartTenderStatisticsAdapter
    {
        public static BarChartTenderStatistic BarChartStatisticDTOToBarChartStatistic(BarChartTenderStatisticsDTO dto)
        {
            BarChartTenderStatistic barChartStatistic = new BarChartTenderStatistic();
            barChartStatistic.X = dto.X;
            barChartStatistic.Y = dto.Y;
            return barChartStatistic;
        }

        public static BarChartTenderStatisticsDTO BarChartStatisticToBarChartStatisticDTO(BarChartTenderStatistic barChartStatistic)
        {
            BarChartTenderStatisticsDTO dto = new BarChartTenderStatisticsDTO();
            dto.X = barChartStatistic.X;
            dto.Y = barChartStatistic.Y;
            return dto;
        }
    }
}
