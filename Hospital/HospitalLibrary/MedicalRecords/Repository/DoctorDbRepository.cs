using ehealthcare.Model;
using HospitalLibrary.MedicalRecord.Repository;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Repository
{
    public class DoctorDbRepository : GenericSTRINGIDRepository<Doctor>, IDoctorRepository
    {

        private HospitalDbContext _dbContext;

        public DoctorDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public int FindLeastNumberOfPatient()
        {
            var doctors = _dbContext.Set<Doctor>().Where(d => d.Specialization.Equals(Specialization.none)).ToList();
            if (doctors.Count == 0) return 0;
            return doctors.Select(d => d.Patients.Count).Min();
        }

        public List<Doctor> GetLeastOccupiedDoctors(int minPatients)
        {
            return _dbContext.Set<Doctor>().Where(d => d.Specialization.Equals(Specialization.none))
                  .Where(d => d.Patients.Count >= minPatients && d.Patients.Count <= minPatients + 2).ToList();
        }
    }
}
