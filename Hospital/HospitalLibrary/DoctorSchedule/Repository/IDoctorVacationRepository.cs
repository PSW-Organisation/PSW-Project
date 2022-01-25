using System.Collections.Generic;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.Repository;

namespace HospitalLibrary.DoctorSchedule.Repository
{
    public interface IDoctorVacationRepository : IGenericRepository<DoctorVacation>
    {
        List<DoctorVacation> GetDoctorVacations(string doctorId);

        public int GetNewId();

        public List<DoctorVacation> GetAllDoctorVacations();
    }
}
