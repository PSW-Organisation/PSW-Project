using System;
using System.Collections.Generic;

namespace Model
{
   public class EventsLog
   {
        public String PatientJmbg { get; set; }
        public List<DateTime> EventDates { get; set; }

        public EventsLog(String jmbg, List<DateTime> list)
        {
            this.PatientJmbg = jmbg;
            this.EventDates = list;
        }

    }
}