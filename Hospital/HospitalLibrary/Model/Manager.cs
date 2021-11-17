using System;
using System.Collections.Generic;

namespace ehealthcare.Model
{
    public class Manager : Employee
    {
        public List<Employee> TeamMembers { get; set; }
        public string ManagedDepartment { get; set; }

        public Manager(string id) : base(id)
        {

        }

    }

    public interface IFullTimeEmployee
    {
        public Workday Workday { get; set; }
        public void SetWorkHours(DateTime startTime, DateTime endTime);
        public string HealthInsurance { get; set; }
        public bool CheckHealthInsurance();
    }
}
