using ehealthcare.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecord.Repository
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        public int FindLeastNumberOfPatient();
        List<Doctor> GetLeastOccupiedDoctors(int minPatients);
    }
}
