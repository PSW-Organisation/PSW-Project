using System;

namespace IntegrationLibrary.Model
{
    public class Employee : User
    {
        public int UsedOffDays { get; set; }
        public int HoursPerWeek { get; set; }
        public double HourlyWage { get; set; }
        public Workday Workday { get; set; }
        public string HealthInsurance { get; set; }

        public virtual double CalculateSalary()
        {
            return HoursPerWeek * HourlyWage * 52;
        }

        public virtual void SetWorkHours(DateTime startTime, DateTime endTime)
        {
            Workday.StartTime = startTime;
            Workday.EndTime = endTime;
        }


        public virtual bool CheckHealthInsurance()
        {
            if (HealthInsurance == "000102393")
            {
                return true;
            }

            return false;
        }
    }
}
