using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.DoctorSchedule.Model;

namespace HospitalLibrary.DoctorSchedule.Service
{
    public interface IShiftService
    {
        List<Shift> GetAllShifts();
        Shift CreateShift(Shift shift);
        Shift GetShift(int shiftId);
        Shift UpdateShift(Shift shift, Shift updatedShift);
        Shift DeleteShift(Shift shift);
        void UpdateCurrentDoctorShift();
    }
}
