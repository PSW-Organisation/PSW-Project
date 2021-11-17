using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class WorkdayDbRepository : GenericDatabaseRepository<Workday>, WorkdayRepository
    {
        public WorkdayDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

        public void DeleteVisitTime(Workday workday, VisitTime visitTime)
        {
            int indexOfWorkday = GetIndex(workday);
            int indexOfVisitTime = GetIndex(visitTime);

            if (indexOfWorkday != -1 && indexOfVisitTime != -1)
            {
                List<VisitTime> visitTimes = base.GetAll().ElementAt(indexOfWorkday).VisitTimes;
                visitTimes.RemoveAt(indexOfVisitTime);

                UpdateWorkdaysVisitTimes(base.GetAll().ElementAt(indexOfWorkday), visitTimes);
            }
        }

        public List<VisitTime> GetVisitTimesInHolidayRange(Holiday holiday)
        {
            List<VisitTime> visitsForCanceling = new List<VisitTime>();
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].DoctorId == holiday.DoctorId)
                {
                    if (InRange(base.GetAll()[i], holiday))
                    {
                        visitsForCanceling.AddRange(base.GetAll()[i].VisitTimes);
                    }
                }
            }

            return visitsForCanceling;
        }

        public Workday GetWorkday(int doctorId, DateTime date)
        {
            foreach (Workday workday in base.GetAll())
            {
                if (workday.DoctorId == doctorId && workday.StartTime.Date == date.Date)
                {
                    return workday;
                }
            }

            return null;
        }

        public List<Workday> GetWorkdays(int month, int doctorId)
        {
            List<Workday> doctorsWorkdays = GetWorkdaysForDoctor(doctorId);
            List<Workday> workdays = new List<Workday>();
            foreach (Workday workday in doctorsWorkdays)
            {
                if (workday.StartTime.Month == month)
                {
                    workdays.Add(workday);
                }
            }

            return workdays;
        }

        public List<Workday> GetWorkdaysAfter(DateTime date, int doctorId)
        {
            List<Workday> doctorsWorkdays = GetWorkdaysForDoctor(doctorId);
            List<Workday> workdaysAfterDate = new List<Workday>();
            foreach (Workday workday in doctorsWorkdays)
            {
                if (workday.StartTime >= date)
                {
                    workdaysAfterDate.Add(workday);
                }
            }

            return workdaysAfterDate;
        }

        public List<Workday> GetWorkdaysForDoctor(int doctorId)
        {
            List<Workday> filteredWorkdays = new List<Workday>();
            foreach (Workday workday in base.GetAll())
            {
                if (workday.DoctorId == doctorId)
                {
                    filteredWorkdays.Add(workday);
                }
            }

            return filteredWorkdays;
        }

        public bool IsWorkday(int doctorId, DateTime date)
        {
            List<Workday> doctorsWorkdays = GetWorkdaysForDoctor(doctorId);
            foreach (Workday workday in doctorsWorkdays)
            {
                if (workday.StartTime.Date == date.Date)
                {
                    return true;
                }
            }

            return false;
        }

        public void NewVisitTime(VisitTime visitTime, int doctorId)
        {
            Workday workday = GetWorkday(doctorId, visitTime.StartTime);
            int index = GetIndex(workday);
            base.GetAll().ElementAt(index).VisitTimes.Add(visitTime);
            SaveAll();
        }

        public void RemoveVisitTimes(Workday workday, List<VisitTime> visitTimes)
        {
            int index = GetIndex(workday);
            foreach (var visitTime in visitTimes)
            {
                for (var i = 0; i < base.GetAll()[index].VisitTimes.Count; i++)
                {
                    if (!Equals(visitTime, base.GetAll()[index].VisitTimes[i])) continue;
                    base.GetAll()[index].VisitTimes.RemoveAt(i);
                    break;
                }
            }

            SaveAll();
        }

        public void RemoveWorkdays(Holiday holiday)
        {
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].DoctorId == holiday.DoctorId)
                {
                    if (InRange(base.GetAll()[i], holiday))
                    {
                        base.GetAll().RemoveAt(i);
                    }
                }
            }

            base.SaveAll();
        }

        public void UpdateVisitTime(Workday workday, VisitTime oldVisitTime, VisitTime updatedVisitTime)
        {
            int indexOfWorkday = GetIndex(workday);
            int indexOfVisitTime = GetIndex(oldVisitTime);
            Workday newWorkday = GetWorkday(workday.DoctorId, updatedVisitTime.StartTime);
            int indexOfNewWorkday = GetIndex(newWorkday);

            if (updatedVisitTime.StartTime.Date == workday.StartTime.Date)
            {
                UpdateSameWorkday(updatedVisitTime, indexOfWorkday, indexOfVisitTime);
            }
            else
            {
                UpdateDifferentWorkday(updatedVisitTime, indexOfWorkday, indexOfVisitTime, indexOfNewWorkday);
            }

            SaveAll();
        }
        private void UpdateDifferentWorkday(VisitTime updatedVisitTime, int indexOfWorkday, int indexOfVisitTime,
            int indexOfNewWorkday)
        {
            base.GetAll().ElementAt(indexOfNewWorkday).VisitTimes.Add(updatedVisitTime);
            base.GetAll().ElementAt(indexOfWorkday).VisitTimes.RemoveAt(indexOfVisitTime);
        }

        private void UpdateSameWorkday(VisitTime updatedVisitTime, int indexOfWorkday, int indexOfVisitTime)
        {
            if (indexOfWorkday != -1 && indexOfVisitTime != -1)
            {
                List<VisitTime> visitTimes = base.GetAll().ElementAt(indexOfWorkday).VisitTimes;
                visitTimes.ElementAt(indexOfVisitTime).StartTime = updatedVisitTime.StartTime;
                visitTimes.ElementAt(indexOfVisitTime).EndTime = updatedVisitTime.EndTime;

                UpdateWorkdaysVisitTimes(base.GetAll().ElementAt(indexOfWorkday), visitTimes);
            }
        }

        public Workday UpdateWorkHours(Workday workday, DateTime startTime, DateTime endTime)
        {
            int index = GetIndex(workday);
            if (index != -1)
            {
                base.GetAll().ElementAt(index).StartTime = startTime;
                base.GetAll().ElementAt(index).EndTime = endTime;
                base.SaveAll();
                return base.GetAll().ElementAt(index);
            }

            return null;
        }
        private int GetIndex(Workday workday)
        {
            foreach (Workday workdayFromStorage in base.GetAll())
            {
                if (Equals(workday, workdayFromStorage))
                {
                    return base.GetAll().IndexOf(workdayFromStorage);
                }
            }

            return -1;
        }

        private bool Equals(Workday workday, Workday workdayFromStorage)
        {
            return workdayFromStorage.StartTime.Equals(workday.StartTime) &&
                   workdayFromStorage.EndTime.Equals(workday.EndTime) &&
                   workdayFromStorage.DoctorId.Equals(workday.DoctorId);
        }

        private int GetIndex(VisitTime visitTime)
        {
            foreach (Workday workday in base.GetAll())
            {
                foreach (VisitTime workdayVisitTime in workday.VisitTimes)
                {
                    if (Equals(visitTime, workdayVisitTime))
                    {
                        return workday.VisitTimes.IndexOf(workdayVisitTime);
                    }
                }
            }

            return -1;
        }
        private bool InRange(Workday workday, Holiday holiday)
        {
            return workday.StartTime.Date >= holiday.StartDate.Date && workday.StartTime.Date <= holiday.EndDate.Date;
        }

        private void UpdateWorkdaysVisitTimes(Workday workday, List<VisitTime> visitTimes)
        {
            int index = GetIndex(workday);
            if (index != -1)
            {
                base.GetAll().ElementAt(index).VisitTimes = visitTimes;
            }

            SaveAll();
        }

        private bool Equals(VisitTime visitTime, VisitTime workdayVisitTime)
        {
            return workdayVisitTime.StartTime.Equals(visitTime.StartTime) &&
                   workdayVisitTime.EndTime.Equals(visitTime.EndTime);
        }
    }

}
