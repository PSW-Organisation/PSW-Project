using HospitalLibrary.DoctorSchedule.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public interface IDoctorScheduleService
    {
        DoctorsSchedule CreateDoctorSchedule(DoctorsSchedule doctorSchedule);

        DoctorsSchedule GetDoctorSchedule(int doctorScheduleId);

        DoctorsSchedule GetDoctorsSchedule(string doctorId);

        IList<DoctorsSchedule> GetAllDoctorSchedules();

        DoctorsSchedule UpdateDoctorSchedule(DoctorsSchedule doctorSchedule);

        bool DeleteDoctorSchedule(DoctorsSchedule doctorSchedule);

        OnCallShift AddOnCallShift(OnCallShift onCallShift);
    }
}
