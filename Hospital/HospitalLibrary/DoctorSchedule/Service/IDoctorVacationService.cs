using System.Collections.Generic;
using HospitalLibrary.DoctorSchedule.Model;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public interface IDoctorVacationService
    {
        DoctorVacation CreateDoctorVacation(DoctorVacation doctorVacation);

        List<DoctorVacation> GetDoctorVacations(string doctorId);

        IList<DoctorVacation> GetAllDoctorVacations();

        DoctorVacation UpdateDoctorVacation(DoctorVacation doctorVacation);

        bool DeleteDoctorVacation(DoctorVacation doctorVacation);
    }
}
