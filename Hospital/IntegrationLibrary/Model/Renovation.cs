using System;

namespace Model
{
   public class Renovation
   {
        public Renovation(DateTime startTime, int durationInDays, int renovationID)
        {
            this.StartTime = startTime;
            this.DurationInDays = durationInDays;
            this.RenovationID = renovationID;
        }

        public DateTime StartTime { get; set; }
        public int DurationInDays { get; set; }
        public int RenovationID { get; set; }
    }
}