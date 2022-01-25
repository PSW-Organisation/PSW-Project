using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public DoctorScheduleService(IDoctorScheduleRepository doctorScheduleRepository)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
        }

        public OnCallShift AddOnCallShift(OnCallShift onCallShift)
        {
            DoctorsSchedule doctorSchedule = _doctorScheduleRepository.GetDoctorsSchedule(onCallShift.DoctorId);
            if (!doctorSchedule.AddOnCallShift(onCallShift))
                return null;
            _doctorScheduleRepository.Save(doctorSchedule);
            return onCallShift;
        }

        public DoctorsSchedule CreateDoctorSchedule(DoctorsSchedule doctorSchedule)
        {
            _doctorScheduleRepository.Insert(doctorSchedule);
            return doctorSchedule;
        }

        public bool DeleteDoctorSchedule(DoctorsSchedule doctorSchedule)
        {
            _doctorScheduleRepository.Delete(doctorSchedule);
            return true;
        }

        public IList<DoctorsSchedule> GetAllDoctorSchedules()
        {
            return _doctorScheduleRepository.GetAll();
        }

        public DoctorsSchedule GetDoctorSchedule(int doctorScheduleId)
        {
            return _doctorScheduleRepository.Get(doctorScheduleId);
        }


        public DoctorsSchedule GetDoctorsSchedule(string doctorId)
        {
            return _doctorScheduleRepository.GetDoctorsSchedule(doctorId);
        }
       

        public DoctorsSchedule UpdateDoctorSchedule(DoctorsSchedule doctorSchedule)
        {
            return _doctorScheduleRepository.Update(doctorSchedule);
        }

    }
}
