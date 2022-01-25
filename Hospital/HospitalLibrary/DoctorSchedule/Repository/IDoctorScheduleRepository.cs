using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public interface IDoctorScheduleRepository : IGenericRepository<DoctorsSchedule>
    {
        DoctorsSchedule GetDoctorsSchedule(string doctorId);
    }
}
