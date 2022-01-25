using ehealthcare.Model;
using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System.Collections.Generic;

namespace HospitalLibrary.DoctorSchedule.Model
{
    public class DoctorsSchedule : EntityDb
    {
        public virtual List<DoctorVacation> DoctorVacations { get; private set; }
        public virtual List<OnCallShift> OnCallShifts { get; private set; }
        public string DoctorId { get; set; }

        public DoctorsSchedule(List<DoctorVacation> doctorVacations, List<OnCallShift> onCallShifts, string doctorId)
        {
            this.DoctorVacations = doctorVacations;
            this.OnCallShifts = onCallShifts;
            DoctorId = doctorId;
        }

        public DoctorsSchedule()
        {
        }

        public bool AddDoctorVacation(DoctorVacation doctorVacation)
        {
            foreach (DoctorVacation dv in DoctorVacations)
                if (doctorVacation.DateSpecification.IsOverlapping(dv.DateSpecification))
                    return false;

            foreach (OnCallShift onCallShift in OnCallShifts)
                if (doctorVacation.DateSpecification.IsOverlapping(onCallShift.Date))
                    return false;

            DoctorVacations.Add(doctorVacation);
            return true;
        }

        public bool UpdateDoctorVacation(DoctorVacation doctorVacation)
        {
            List<DoctorVacation> doctorVacations = new List<DoctorVacation>(DoctorVacations);
            DoctorVacation oldDoctorVacation = DoctorVacations.Find(d => d.Id == doctorVacation.Id);
            doctorVacations.Remove(oldDoctorVacation);

            foreach (DoctorVacation dv in doctorVacations)
                if (doctorVacation.DateSpecification.IsOverlapping(dv.DateSpecification))
                    return false;

            foreach (OnCallShift onCallShift in OnCallShifts)
                if (doctorVacation.DateSpecification.IsOverlapping(onCallShift.Date))
                    return false;

            DoctorVacations.Remove(oldDoctorVacation);
            DoctorVacations.Add(doctorVacation);
            return true;
        }

        public bool DeleteDoctorVacation(DoctorVacation doctorVacation)
        {
            DoctorVacation doctorVacationDelete = DoctorVacations.Find(d => d.Id == doctorVacation.Id);
            DoctorVacations.Remove(doctorVacationDelete);
            return true;
        }

        public bool AddOnCallShift(OnCallShift onCallShift)
        {
            foreach (OnCallShift onCall in OnCallShifts)
                if (onCallShift.Date == onCall.Date)
                    return false;

            foreach (DoctorVacation dv in DoctorVacations)
                if (dv.DateSpecification.IsOverlapping(onCallShift.Date))
                    return false;

            OnCallShifts.Add(onCallShift);
            return true;
        }

        public bool UpdateOnCallShift(OnCallShift onCallShift)
        {
            List<OnCallShift> onCallShifts = new List<OnCallShift>(OnCallShifts);
            OnCallShift oldOnCallShift = OnCallShifts.Find(o => o.Id == onCallShift.Id);
            onCallShifts.Remove(oldOnCallShift);

            foreach (DoctorVacation dv in DoctorVacations)
                if (dv.DateSpecification.IsOverlapping(onCallShift.Date))
                    return false;

            foreach (OnCallShift onCall in onCallShifts)
                if (onCallShift.Date == onCall.Date)
                    return false;

            
            OnCallShifts.Remove(oldOnCallShift);
            OnCallShifts.Add(onCallShift);
            return true;
        }

        public bool DeleteOnCallShift(OnCallShift onCallShift)
        {
            OnCallShift onCallShiftDelete = OnCallShifts.Find(d => d.Id == onCallShift.Id);
            OnCallShifts.Remove(onCallShiftDelete);
            return true;
        }
    }
}
