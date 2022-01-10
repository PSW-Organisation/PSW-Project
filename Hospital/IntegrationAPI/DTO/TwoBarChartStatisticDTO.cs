using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class TwoBarChartStatisticDTO
    {
        public TwoBarChartStatisticDTO(List<string> x, List<int> y, List<int> z)
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
