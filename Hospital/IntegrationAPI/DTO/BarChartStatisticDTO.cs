using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class BarChartStatisticDTO
    {
        public BarChartStatisticDTO(List<DateTime> x, List<double> y)
        {
            X = x;
            Y = y;
        }

        public List<DateTime> X { get; set; }
        public List<double> Y { get; set; }
    }
}
