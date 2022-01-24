using IntegrationAPI.DTO;
using IntegrationLibrary.Statistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class BarChartStatisticAdapter { 

        public static BarChartStatistic BarChartStatisticDTOToBarChartStatistic(BarChartStatisticDTO dto)
        {
            BarChartStatistic barChartStatistic = new BarChartStatistic();
            barChartStatistic.X = dto.X;
            barChartStatistic.Y = dto.Y;
            return barChartStatistic;
        }

        public static BarChartStatisticDTO BarChartStatisticToBarChartStatisticDTO(BarChartStatistic barChartStatistic)
        {
            BarChartStatisticDTO dto = new BarChartStatisticDTO();
            dto.X = barChartStatistic.X;
            dto.Y = barChartStatistic.Y;
            return dto;
        }
    }
}
