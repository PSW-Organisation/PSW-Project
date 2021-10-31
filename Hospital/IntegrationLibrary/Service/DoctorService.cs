using Model;
using System;
using System.Collections.Generic;
using System.Windows;
using vezba.Factory;
using vezba.Repository;
using vezba.SecretaryGUI;

namespace Service
{
   public class DoctorService
    {
        private IDoctorRepository DoctorRepository { get; }

        private IRepositoryFactory RepositoryFactory { get; }

        public DoctorService()
        {
            RepositoryFactory = (ApplicationDataSource.GetInstance()).GetRepositoryFactory();
            DoctorRepository = RepositoryFactory.CreateDoctorRepository();
        }

        public Doctor GetDoctorByJmbg(string jmbg)
        {
            return DoctorRepository.GetOne(jmbg);
        }

        public List<Doctor> GetAllDoctors()
        {
            return DoctorRepository.GetAll();
        }

        public List<Doctor> GetDoctorsWithSpeciality(Speciality speciality)
        {
            return DoctorRepository.GetDoctorsWithSpeciality(speciality);
        }

        public Boolean EditDoctor(Doctor editedDoctor)
        {
            Doctor doctor = SortWorkingHoursForDoctor(editedDoctor);
            doctor = SortVacationDaysForDoctor(doctor);
            return DoctorRepository.Update(doctor);
        }

        public List<WorkingHours> GetFutureWorkingHoursForDoctor(string jmbg)
        {
            List<WorkingHours> futureWorkingHours = new List<WorkingHours>();
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            foreach (WorkingHours workingHours in doctor.WorkingSchedule)
            {
                if (workingHours.EndDate > DateTime.Now)
                    futureWorkingHours.Add(workingHours);
            }
            return futureWorkingHours;
        }

        public List<VacationDays> GetFutureVacationDaysForDoctor(string jmbg)
        {
            List<VacationDays> futureVacationDays = new List<VacationDays>();
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            foreach (VacationDays vacationDays in doctor.VacationDays)
            {
                if (vacationDays.EndDate > DateTime.Now)
                    futureVacationDays.Add(vacationDays);
            }
            return futureVacationDays;
        }

        private Doctor SortWorkingHoursForDoctor(Doctor doctor)
        {
            doctor.WorkingSchedule.Sort((wh1, wh2) => wh1.BeginningDate.CompareTo(wh2.BeginningDate));
            return doctor;
        }
        private Doctor SortVacationDaysForDoctor(Doctor doctor)
        {
            doctor.VacationDays.Sort((vd1, vd2) => vd1.StartDate.CompareTo(vd2.StartDate));
            return doctor;
        }

        public DateTime FindNextWorkingHoursBeginningDateForDoctor(string jmbg)
        {
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            DateTime nextStartDate = DateTime.Now;
            foreach (WorkingHours workingHours in doctor.WorkingSchedule)
            {
                if (workingHours.BeginningDate <= nextStartDate && workingHours.EndDate > nextStartDate)
                    nextStartDate = workingHours.EndDate.AddDays(1);
            }
            return nextStartDate;
        }

        public void AddWorkingHoursToDoctor(string jmbg, WorkingHours workingHours)
        {
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            doctor.WorkingSchedule.Add(workingHours);
            EditDoctor(doctor);
        }

        public Boolean AddVacationDaysToDoctor(string jmbg, VacationDays newVacationDays)
        {
            if (!VacationDaysOverlap(jmbg, newVacationDays))
            {
                Doctor doctor = DoctorRepository.GetOne(jmbg);
                doctor.VacationDays.Add(newVacationDays);
                EditDoctor(doctor);
                return true;
            }
            return false;
        }

        private Boolean VacationDaysOverlap(string jmbg, VacationDays newVacationDays)
        {
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            foreach (VacationDays vd in doctor.VacationDays)
            {
                if (!(vd.EndDate < newVacationDays.StartDate || newVacationDays.EndDate < vd.StartDate))
                {
                    SecretaryMessage m1 = new SecretaryMessage("Dolazi do preklapanja godisnjih odmora!");
                    m1.ShowDialog();
                    return true;
                }
            }
            return false;
        }

        public Boolean RemoveWorkingHoursFromDoctor(string jmbg, WorkingHours selectedWorkingHours)
        {
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            List<Appointment> scheduledAppointments = GetDoctorAppointmentsInWorkingHoursPeriod(jmbg, selectedWorkingHours);
            if (scheduledAppointments.Count > 0)
            {
                printUnavailableWorkingHoursRemovalMessage(scheduledAppointments);
                return false;
            }
            foreach (WorkingHours wh in doctor.WorkingSchedule)
            {
                if (wh.BeginningDate.ToString("dd.MM.yyyy.") == selectedWorkingHours.BeginningDate.ToString("dd.MM.yyyy."))
                {
                    doctor.WorkingSchedule.Remove(wh);
                    break;
                }
            }
            EditDoctor(doctor);
            return true;
        }

        private void printUnavailableWorkingHoursRemovalMessage(List<Appointment> appointments)
        {
            String text = "Ne možete da uklonite radno vreme. Lekar ima zakazano " + appointments.Count + " termina za dati period:";
            foreach(Appointment a in appointments)
            {
                text += "\n\t";
                text += a.StartTime.ToString("dd.MM.yyyy. HH:mm");
            }
            text += "\nKada otkažete ili odložite ove termine moći ćete da uklonite radno vreme.";
            SecretaryMessage m = new SecretaryMessage(text);
            m.ShowDialog();
        }

        private List<Appointment> GetDoctorAppointmentsInWorkingHoursPeriod(string jmbg, WorkingHours workingHours)
        {
            AppointmentService aps = new AppointmentService();
            List<Appointment> scheduledAppointments = aps.GetAllAppointments();
            List<Appointment> appointments = new List<Appointment>();
            foreach(Appointment a in scheduledAppointments)
            {
                if (a.Doctor.Jmbg.Equals(jmbg) && (a.StartTime.Date>=workingHours.BeginningDate.Date && a.EndTime.Date <= workingHours.EndDate))
                {
                    appointments.Add(a);
                }
            }
            return appointments;

        }

        public void RemoveVacationDaysFromDoctor(string jmbg, VacationDays selectedVacationDays)
        {
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            foreach (VacationDays vd in doctor.VacationDays)
            {
                if (vd.StartDate.ToString("dd.MM.yyyy.") == selectedVacationDays.StartDate.ToString("dd.MM.yyyy."))
                {
                    doctor.VacationDays.Remove(vd);
                    break;
                }
            }
            EditDoctor(doctor);
        }

        public string GenerateDoctorIsUnavailableMessage(string jmbg, DateTime time)
        {
            if (IsDoctorOnVacation(jmbg, time))
                return "Lekar je na godisnjem odmoru u izabranom datumu. Izaberite drugi datum.";
            if (!IsDoctorWorking(jmbg, time))
                return "Izabrano vreme je van radnog vremena lekara. ";
            return null;
        }

        public Boolean IsDoctorOnVacation(string jmbg, DateTime time)
        {
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            foreach (VacationDays vd in doctor.VacationDays)
            {
                if (vd.StartDate.Date <= time.Date && vd.EndDate.Date>=time.Date)
                    return true;
            }
            return false;
        }
        public Boolean IsDoctorWorking(string jmbg, DateTime time)
        {
            Doctor doctor = DoctorRepository.GetOne(jmbg);
            foreach (WorkingHours wh in doctor.WorkingSchedule)
            {
                if (wh.BeginningDate.Date <= time.Date && wh.EndDate.Date >= time.Date)
                {
                    if (wh.Shift == Shift.firstShift && time.Hour > 14)
                        return false;
                    else if ((wh.Shift == Shift.secondShift) && time.Hour < 14)
                        return false;
                    else 
                        return true;
                }
            }
            return true;
        }
        public Doctor LoadDoctor()
        {
            return DoctorRepository.GetOne("1708962324890");
        }
    }
}