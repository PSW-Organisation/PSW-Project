using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class StatisticsDTO
    {
        public StatisticsDTO(DateTime dateStart, DateTime dateEnd)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
