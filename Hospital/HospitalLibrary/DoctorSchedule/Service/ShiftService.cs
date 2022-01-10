using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalLibrary.DoctorSchedule.Model;
using HospitalLibrary.DoctorSchedule.Repository;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        public List<Shift> GetAllShifts()
        {
            return _shiftRepository.GetAll().ToList();
        }

        public Shift CreateShift(Shift shift)
        {
            shift.TimeInterval.StartTime = GetTime(shift.TimeInterval.StartTime);
            shift.TimeInterval.EndTime = GetTime(shift.TimeInterval.EndTime);
            shift.ShiftOrder = GetAllShifts().Count() + 1;
            _shiftRepository.Insert(shift);
            return shift;
        }

        private static DateTime GetTime(DateTime d)
        {
            return new DateTime(d.TimeOfDay.Ticks, d.Kind);
        }

        public Shift GetShift(int shiftId)
        {
            return _shiftRepository.Get(shiftId);
        }

        public Shift UpdateShift(Shift shift, Shift updatedShift)
        {
            shift.Name = updatedShift.Name;
            shift.TimeInterval = updatedShift.TimeInterval;
            return _shiftRepository.Update(shift);
        }
        
        public Shift DeleteShift(Shift shift)
        {
            _shiftRepository.Delete(shift);
            UpdateOrderByDeletedSift(shift.ShiftOrder);
            return shift;
        }

        private void UpdateOrderByDeletedSift(int deletedShiftOrder)
        {
            foreach (var shift in GetAllShifts())
            {
                if (shift.ShiftOrder > deletedShiftOrder)
                {
                    shift.ShiftOrder -= 1;
                    _shiftRepository.Update(shift);
                }
            }
        }

        public void UpdateCurrentDoctorShift()
        {
            var shifts = GetAllShifts();
            foreach (var shift in shifts)
            {
                shift.ShiftOrder -= 1;
                if (shift.ShiftOrder == 0) shift.ShiftOrder = shifts.Count();
                _shiftRepository.Update(shift);
            }
        }

    }
}
