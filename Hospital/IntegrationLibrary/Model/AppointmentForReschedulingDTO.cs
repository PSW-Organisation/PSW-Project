using System;
using System.Collections.Generic;

namespace Model
{
    public class AppointmentForReschedulingDTO
    {

        public DateTime StartTime { get; set; }
        public int DurationInMunutes { get; set; }
        public String AppointmentDescription { get; set; }
        public int AppointmentId { get; set; }
        public String DoctorName { get; set; }
        public String RoomNumber { get; set; }
        public String PatientName { get; set; }
        public DateTime SuggestedTime { get; set; }


        public AppointmentForReschedulingDTO(Appointment a)
        {
            AppointmentId = a.AppointentId;
            PatientName = a.PatientName;
            DoctorName = a.DoctorName;
            RoomNumber = a.RoomName;
            StartTime = a.StartTime;
            DurationInMunutes = a.DurationInMunutes;
            AppointmentDescription = a.ApointmentDescription;
            SuggestedTime = a.StartTime;
        }

        //public AppointmentForReschedulingDTO() { }
    }
}

