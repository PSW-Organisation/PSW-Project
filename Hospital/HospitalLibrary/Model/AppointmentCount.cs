using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Model
{
    public class AppointmentCount
    {
        public int[] YearlySum { get; set; }
        public int[] MonthlySum { get; set; }
        public int[] WeeklySum { get; set; }
        public int[] DailySum { get; set; }

        public AppointmentCount()
        {
            YearlySum = new int[4];
            MonthlySum = new int[12];
            WeeklySum = new int[4];
            DailySum = new int[31];
        }
    }
}
