using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IWorkdayService
    {
        public void UpdateWorkHours(Workday workday, DateTime startTime, DateTime endTime);
        public List<Workday> GetWorkdaysForDoctor(int doctorId);
        public bool IsWorkday(int doctorId, DateTime date);
        public Workday GetWorkday(DateTime date, int doctorId);
        public List<Workday> GetWorkdaysAfter(DateTime date, int doctorId);
        public List<Workday> GetWorkdays(int month, int doctorId);
        public void NewWorkday(Workday workday);
    }
}
