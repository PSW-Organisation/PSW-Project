using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Statistics.Model
{
    public class BarChartStatistic
    {
        private List<DateTime> x;
        private List<double> y;
        private List<DateTime> offerDate;
        private List<double> offerPrices;

        public BarChartStatistic()
        {
        }

        public BarChartStatistic(List<DateTime> offerDate, List<double> offerPrices)
        {
            this.offerDate = offerDate;
            this.offerPrices = offerPrices;
        }

        public List<DateTime> X { get => x; set => x = value; }
        public List<double> Y { get => y; set => y = value; }
    }
}
