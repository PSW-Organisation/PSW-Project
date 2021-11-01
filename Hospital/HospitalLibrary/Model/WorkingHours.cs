// File:    WorkingHours.cs
// Author:  graho
// Created: ponedeljak, 17. maj 2021. 08.09.07
// Purpose: Definition of Class WorkingHours

using System;

namespace Model
{
    public class WorkingHours
    {
        public DateTime BeginningDate { get; }
        public DateTime EndDate { get; }
        public Shift Shift { get; set; }

        public WorkingHours(DateTime beginningDate, Shift shift)
        {
            BeginningDate = beginningDate;
            EndDate = beginningDate.AddDays(6);
            Shift = shift;
        }

        public string FormatedBeginnigDate
        {
            get
            {
                return BeginningDate.ToString("dd.MM.yyyy.");
            }
        }
        public string FormatedEndDate
        {
            get
            {
                return EndDate.ToString("dd.MM.yyyy.");
            }
        }

        public string FormatedShift
        {
            get
            {
                if (Shift == Shift.firstShift)
                    return "07:00 - 14:00";
                if (Shift == Shift.secondShift)
                    return "14:00 - 21:00";
                return "";
            }
        }


    }
}