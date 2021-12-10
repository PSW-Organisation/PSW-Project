using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IHolidayService
    {
        public List<Holiday> GetHolidays(int doctorId);
        public void NewHoliday(Holiday newHoliday);
        public void NotifyPatientOfCancellation(List<Visit> cancelledVisits);
        public List<Visit> CancelVisitsInHolidayRange(Holiday newHoliday);
        public bool IsOverlapping(Holiday newHoliday);
        public bool CanUseHoliday(Holiday potentialHoliday);
    }
}
