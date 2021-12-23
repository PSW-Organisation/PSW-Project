using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Model
{
    public class TwoBarChartStatistic
    {
        public TwoBarChartStatistic(List<string> x, List<int> y, List<int> z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public List<String> X { get; set; }
        public List<int> Y { get; set; }
        public List<int> Z { get; set; }
    }
}
