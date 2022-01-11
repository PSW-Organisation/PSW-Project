using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Repository;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public class DoctorVacationService : IDoctorVacationService
    {
        private readonly IDoctorVacationRepository _doctorVacationRepository;

        public DoctorVacationService(IDoctorVacationRepository doctorVacationRepository)
        {
            _doctorVacationRepository = doctorVacationRepository;
        }

        public DoctorVacation CreateDoctorVacation(DoctorVacation doctorVacation)
        {
            if (GetDoctorVacations(doctorVacation.DoctorId).Any(dv =>
                    doctorVacation.DateSpecification.StartTime > dv.DateSpecification.StartTime &&
                    doctorVacation.DateSpecification.StartTime < dv.DateSpecification.EndTime ||
                    doctorVacation.DateSpecification.EndTime > dv.DateSpecification.StartTime &&
                    doctorVacation.DateSpecification.EndTime < dv.DateSpecification.EndTime)) return null;
            doctorVacation.Id = _doctorVacationRepository.GetNewId();
            _doctorVacationRepository.Insert(doctorVacation);
            return doctorVacation;
        }

        public bool DeleteDoctorVacation(DoctorVacation doctorVacation)
        {
            _doctorVacationRepository.Delete(doctorVacation);
            return true;
        }

        public IList<DoctorVacation> GetAllDoctorVacations()
        {
            return _doctorVacationRepository.GetAll();
        }

        public List<DoctorVacation> GetDoctorVacations(string doctorId)
        {
            return _doctorVacationRepository.GetDoctorVacations(doctorId);
        }

        public DoctorVacation UpdateDoctorVacation(DoctorVacation doctorVacation)
        {
            List<DoctorVacation> doctorVacations = GetDoctorVacations(doctorVacation.DoctorId);
            foreach (var dv in doctorVacations.Where(dv => dv.Id.Equals(doctorVacation.Id)))
            {
                doctorVacations.Remove(dv);
                break;
            }

            return doctorVacations.Any(dv =>
                doctorVacation.DateSpecification.StartTime > dv.DateSpecification.StartTime &&
                doctorVacation.DateSpecification.StartTime < dv.DateSpecification.EndTime ||
                doctorVacation.DateSpecification.EndTime > dv.DateSpecification.StartTime &&
                doctorVacation.DateSpecification.EndTime < dv.DateSpecification.EndTime) ? null : _doctorVacationRepository.Update(doctorVacation);
        }
    }
}
