using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class AppointmentCountDTO
    {
        public int[] YearlySum { get; set; }
        public int[] MonthlySum { get; set; }
        public int[] WeeklySum { get;set; }
        public int[] DailySum { get; set; }
    }
}
