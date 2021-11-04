using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class WorkdayController
    {
        private WorkdayService workdayService;

        public WorkdayController()
        {
            workdayService = new WorkdayService();
        }

        public void NewWorkday(Workday workday)
        {
            workdayService.NewWorkday(workday);
        }

        public void UpdateWorkHours(Workday workday, DateTime startTime, DateTime endTime)
        {
            workdayService.UpdateWorkHours(workday, startTime, endTime);
        }

        public List<Workday> GetWorkdaysForDoctor(String doctorId)
        {
            return workdayService.GetWorkdaysForDoctor(doctorId);
        }

        public bool IsWorkday(String doctorId, DateTime date)
        {
            return workdayService.IsWorkday(doctorId, date);
        }

        public Workday GetWorkday(DateTime date, String doctorId)
        {
            return workdayService.GetWorkday(date, doctorId);
        }

        public List<Workday> GetWorkdaysAfter(DateTime date, String doctorId)
        {
            return workdayService.GetWorkdaysAfter(date, doctorId);
        }

        public List<Workday> GetWorkdays(int month, String doctorId)
        {
            return workdayService.GetWorkdays(month, doctorId);
        }
    }
}
