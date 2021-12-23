using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class BarChartTenderStatistic
    {
        public BarChartTenderStatistic()
        {
        }

        public BarChartTenderStatistic(List<String> x, List<double> y)
        {
            X = x;
            Y = y;
        }

        public List<String> X { get; set; }
        public List<double> Y { get; set; }
    }
}
