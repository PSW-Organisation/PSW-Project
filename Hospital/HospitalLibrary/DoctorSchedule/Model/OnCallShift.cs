using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.Model;

namespace HospitalLibrary.DoctorSchedule.Model
{
    public class OnCallShift : EntityDb
    {
        public DateTime Date { get; set; }
        public string DoctorId { get; set; }

        public OnCallShift()
        {
        }

        public OnCallShift(DateTime date, string doctorId)
        {
            DoctorId = doctorId;
            Date = date;
        }
    }
}
