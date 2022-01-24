using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class BarChartTenderStatisticsDTO
    {
        public BarChartTenderStatisticsDTO()
        {
        }

        public BarChartTenderStatisticsDTO(List<String> x, List<double> y)
        {
            X = x;
            Y = y;
        }

        public List<String> X { get; set; }
        public List<double> Y { get; set; }
    }
}

