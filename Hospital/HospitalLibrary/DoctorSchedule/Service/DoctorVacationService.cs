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
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public DoctorVacationService(IDoctorVacationRepository doctorVacationRepository, IDoctorScheduleRepository doctorScheduleRepository)
        {
            _doctorVacationRepository = doctorVacationRepository;
            _doctorScheduleRepository = doctorScheduleRepository;
        }

        public DoctorVacation CreateDoctorVacation(DoctorVacation doctorVacation)
        {
            DoctorsSchedule doctorSchedule = _doctorScheduleRepository.GetDoctorsSchedule(doctorVacation.DoctorId);
            if (!doctorSchedule.AddDoctorVacation(doctorVacation))
                return null;
            _doctorScheduleRepository.Save(doctorSchedule);
            return doctorVacation;
        }

        public bool DeleteDoctorVacation(DoctorVacation doctorVacation)
        {
            DoctorsSchedule doctorSchedule = _doctorScheduleRepository.GetDoctorsSchedule(doctorVacation.DoctorId);
            doctorVacation.DoctorsScheduleId = doctorSchedule.Id;
            if (!doctorSchedule.DeleteDoctorVacation(doctorVacation))
                return false;
            _doctorScheduleRepository.Save(doctorSchedule);
            return true;
        }

        public IList<DoctorVacation> GetAllDoctorVacations()
        {
            return _doctorVacationRepository.GetAllDoctorVacations();
        }

        public List<DoctorVacation> GetDoctorVacations(string doctorId)
        {
            return _doctorVacationRepository.GetDoctorVacations(doctorId);
        }

        public DoctorVacation UpdateDoctorVacation(DoctorVacation doctorVacation)
        {
            DoctorsSchedule doctorSchedule = _doctorScheduleRepository.GetDoctorsSchedule(doctorVacation.DoctorId);
            if (!doctorSchedule.UpdateDoctorVacation(doctorVacation))
                return null;
            _doctorScheduleRepository.Save(doctorSchedule);
            return doctorVacation;
        }
    }
}
