// File:    VacationDays.cs
// Author:  graho
// Created: ponedeljak, 17. maj 2021. 08.17.58
// Purpose: Definition of Class VacationDays

using System;

namespace Model
{
    public class VacationDays
    {
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationDays(DateTime start, DateTime end)
        {
            StartDate = start;
            EndDate = end;
        }
        public string FormatedStartDate
        {
            get
            {
                return StartDate.ToString("dd.MM.yyyy.");
            }
        }
        public string FormatedEndDate
        {
            get
            {
                return EndDate.ToString("dd.MM.yyyy.");
            }
        }

    }
}