using System;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Repository;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public class DoctorVacationService : IDoctorVacationService
    {
        private readonly IDoctorVacationRepository _doctorVacationRepository;

        public DoctorVacationService(IDoctorVacationRepository doctorVacationRepository)
        {
            _doctorVacationRepository = doctorVacationRepository;
        }

        private bool CheckIfDatesConflict(DateTime date1Start, DateTime date1End, DateTime date2Start, DateTime date2End)
        {
            return date1Start > date2Start &&
                   date1Start < date2End ||
                   date1End > date2Start &&
                   date1End < date2End ||
                   date2Start > date1Start &&
                   date2Start < date1End ||
                   date2End > date1Start &&
                   date2End < date1End;
        }

        public DoctorVacation CreateDoctorVacation(DoctorVacation doctorVacation)
        {
            if (GetDoctorVacations(doctorVacation.DoctorId).Any(dv =>
                    CheckIfDatesConflict(doctorVacation.DateSpecification.StartTime,
                        doctorVacation.DateSpecification.EndTime, dv.DateSpecification.StartTime,
                        dv.DateSpecification.EndTime))) return null;
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

            if (doctorVacations.Any(dv =>
                    CheckIfDatesConflict(doctorVacation.DateSpecification.StartTime,
                        doctorVacation.DateSpecification.EndTime, dv.DateSpecification.StartTime,
                        dv.DateSpecification.EndTime))) return null;
            _doctorVacationRepository.Update(doctorVacation);
            return doctorVacation;
        }
    }
}
