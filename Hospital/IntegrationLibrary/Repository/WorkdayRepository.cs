using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegrationLibrary.Repository
{
    public interface WorkdayRepository : GenericRepository<Workday>
    {
        public Workday UpdateWorkHours(Workday workday, DateTime startTime, DateTime endTime);

        public void RemoveWorkdays(Holiday holiday);

        public void RemoveVisitTimes(Workday workday, List<VisitTime> visitTimes);

        public void NewVisitTime(VisitTime visitTime, int doctorId);

        public Workday GetWorkday(int doctorId, DateTime date);

        public List<Workday> GetWorkdaysForDoctor(int doctorId);
        public List<Workday> GetWorkdaysAfter(DateTime date, int doctorId);

        public List<Workday> GetWorkdays(int month, int doctorId);
        public bool IsWorkday(int doctorId, DateTime date);

        public void DeleteVisitTime(Workday workday, VisitTime visitTime);

        public void UpdateVisitTime(Workday workday, VisitTime oldVisitTime, VisitTime updatedVisitTime);

        public List<VisitTime> GetVisitTimesInHolidayRange(Holiday holiday);
    }
}
