using System;

namespace Model
{
   public class ReferralLetter
   {

        public ReferralLetter(DateTime StartDate, int DurationPeriodInDays, Doctor Doctor) {
            this.StartDate = StartDate;
            this.DurationPeriodInDays = DurationPeriodInDays;
            this.Doctor = Doctor;
        }

        public DateTime StartDate { get; set; }
        public int DurationPeriodInDays { get; set; }

        public Doctor Doctor { get; set; }
    }
}