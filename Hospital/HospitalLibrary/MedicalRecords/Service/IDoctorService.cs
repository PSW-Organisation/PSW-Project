using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public interface IDoctorService
    {
        public int FindLeastNumberOfPatient();
        public List<Doctor> GetLeastOccupiedDoctors(int minPatients);
        public List<Doctor> GetAllDoctors();
        public Doctor GetDoctorById(string id);

        public Doctor UpdateDoctor(Doctor doctor);
    }
}
