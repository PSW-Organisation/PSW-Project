using IntegrationAPI.DTO;
using IntegrationLibrary.Tendering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class TwoBarChartStatisticAdapter
    {
        public static TwoBarChartStatistic BarChartStatisticDTOToBarChartStatistic(TwoBarChartStatisticDTO dto)
        {
            TwoBarChartStatistic barChartStatistic = new TwoBarChartStatistic();
            barChartStatistic.X = dto.X;
            barChartStatistic.Y = dto.Y;
            barChartStatistic.Z = dto.Z;
            return barChartStatistic;
        }

        public static TwoBarChartStatisticDTO BarChartStatisticToBarChartStatisticDTO(TwoBarChartStatistic barChartStatistic)
        {
            TwoBarChartStatisticDTO dto = new TwoBarChartStatisticDTO();
            dto.X = barChartStatistic.X;
            dto.Y = barChartStatistic.Y;
            dto.Z = barChartStatistic.Z;
            return dto;
        }
    }
}
