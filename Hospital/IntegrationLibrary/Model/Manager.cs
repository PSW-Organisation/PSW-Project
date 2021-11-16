﻿using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Model
{
    public class Manager : Employee
    {
        public List<Employee> TeamMembers { get; set; }
        public string ManagedDepartment { get; set; }
    }

    public interface IFullTimeEmployee
    {
        public Workday Workday { get; set; }
        public void SetWorkHours(DateTime startTime, DateTime endTime);
        public string HealthInsurance { get; set; }
        public bool CheckHealthInsurance();
    }
}
