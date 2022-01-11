using ehealthcare.Model;
using HospitalLibrary.MedicalRecord.Repository;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
           
        }

        public int FindLeastNumberOfPatient()
        {
            return _doctorRepository.FindLeastNumberOfPatient();
        }

        public List<Doctor> GetLeastOccupiedDoctors(int minPatients)
        {
            return _doctorRepository.GetLeastOccupiedDoctors(minPatients);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }

        public Doctor GetDoctorById(string id)
        {
            return _doctorRepository.Get(id);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }
    }
}
