using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class BarChartStatistic
    {
        private List<DateTime> x;
        private List<double> y;

        public List<DateTime> X { get => x; set => x = value; }
        public List<double> Y { get => y; set => y = value; }
    }
}
