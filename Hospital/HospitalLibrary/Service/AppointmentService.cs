using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using vezba;
using vezba.PatientPages;
using vezba.Repository;
using vezba.SecretaryGUI;

namespace Service
{
    public class AppointmentService
    {
        private IAppointmentRepository AppointmentRepository { get; }
        private Appointment ChangingAppointment { get; set; }
        private EventsLogService EventsLogService { get; set; }

        public AppointmentService()
        {
            AppointmentRepository = new AppointmentFileRepository();



            EventsLogService = new EventsLogService();
            ChangingAppointment = new Appointment();
        }
        // Sekretar*******************************************************************************

        public Appointment GetAppointmentById(int id)
        {
            return AppointmentRepository.GetOne(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return AppointmentRepository.GetAll();
        }

        public Boolean SaveAppointment(Appointment newAppointment)
        {
            return AppointmentRepository.Save(newAppointment);
        }

        public Boolean EditAppointment(Appointment editedAppointment)
        {
            return AppointmentRepository.Update(editedAppointment);
        }

        public List<Appointment> GetAppointmentsForPatient(string jmbg)
        {
            List<Appointment> patientAppointents = new List<Appointment>();
            List<Appointment> allAppointments = AppointmentRepository.GetAll();
            foreach (Appointment a in allAppointments)
            {
                if (a.Patient.Jmbg == jmbg)
                    patientAppointents.Add(a);
            }
            return patientAppointents;
        }

        public List<Appointment> GetAppointmentsWithAllConditions(DateTime? from, DateTime? to, Patient patient, Doctor doctor, Room room)
        {
            List<Appointment> allAppointments = GetAllAppointments();//AppointmentRepository.GetAll();
            List<Appointment> appointments = new List<Appointment>();
            Boolean flag = true;
            foreach (Appointment a in allAppointments)
            {
                flag = true;
                if (from != null && a.StartTime < from)
                    flag = false;
                if (to != null && a.StartTime > to)
                    flag = false;
                if (patient != null && patient.Jmbg != a.Patient.Jmbg)
                    flag = false;
                if (doctor != null && doctor.Jmbg != a.Doctor.Jmbg)
                    flag = false;
                if (room != null && room.RoomNumber != a.Room.RoomNumber)
                    flag = false;
                if (flag == true)
                    appointments.Add(a);
            }
            return appointments;
        }
        public List<Appointment> GetAppointmentsWithAnyCondition(DateTime? from, DateTime? to, Patient patient, Doctor doctor, Room room)
        {
            List<Appointment> allAppointments = GetAllAppointments();//AppointmentRepository.GetAll();
            List<Appointment> appointments = new List<Appointment>();
            Boolean flag = false;
            foreach (Appointment a in allAppointments)
            {
                flag = false;
                if (from != null && (a.StartTime > from || a.StartTime == from))
                    flag = true;
                if (to != null && a.StartTime <= to)
                    flag = true;
                if (patient != null && patient.Jmbg == a.Patient.Jmbg)
                    flag = true;
                if (doctor != null && doctor.Jmbg == a.Doctor.Jmbg)
                    flag = true;
                if (room != null && room.RoomNumber == a.Room.RoomNumber)
                    flag = true;
                if (flag == true)
                    appointments.Add(a);
            }
            return appointments;
        }


        public Boolean ScheduleAppointment(Appointment newAppointment)
        {
            if (GetOverlapingAppointments(newAppointment).Count == 0)
            {
                return AppointmentRepository.Save(newAppointment);
            }
            else
            {
                String message = "Termin je zauzet! Izaberite drugo vreme.\n Prvi sledeci dostupan termin za unete kriterijume je " + FindNextFreeAppointmentStartTime(newAppointment).ToString("dd.MM.yyyy. HH:mm");
                SecretaryMessage m = new SecretaryMessage(message);
                m.ShowDialog();
                return false;
            }
        }

        public Boolean RescheduleAppointment(Appointment editedAppointment)
        {
            if (GetOverlapingAppointments(editedAppointment).Count == 0)
                return AppointmentRepository.Update(editedAppointment);
            else
            {
                String message = "Termin je zauzet! Izaberite drugo vreme.\n Prvi sledeci dostupan termin za unete kriterijume je " + FindNextFreeAppointmentStartTime(editedAppointment).ToString("dd.MM.yyyy. HH:mm");
                SecretaryMessage m = new SecretaryMessage(message);
                m.ShowDialog();
                return false;
            }
        }

        public Boolean DeleteAppointment(int id)
        {
            return AppointmentRepository.Delete(id);
        }

        public List<Appointment> GetOverlapingAppointments(Appointment appointment)
        {
            AppointmentFileRepository appointmentFileRepository = new AppointmentFileRepository();
            List<Appointment> scheduledAppointments = appointmentFileRepository.GetAll();
            List<Appointment> overlapingAppointments = new List<Appointment>();
            for (int i = 0; i < scheduledAppointments.Count; i++)
            {
                if (this.AppointmentsOverlap(appointment, scheduledAppointments[i]))
                {
                    overlapingAppointments.Add(scheduledAppointments[i]);
                }
            }

            return overlapingAppointments;
        }

        private Boolean AppointmentsOverlap(Appointment appointment1, Appointment appointment2)
        {
            if (AppointmentsShareDoctor(appointment1, appointment2) ||
                AppointmentsSharePatient(appointment1, appointment2) ||
                AppointmentsShareRoom(appointment1, appointment2))
            {
                if (DateTime.Compare(appointment2.EndTime, appointment1.StartTime) <= 0) //drugi zavrsava pre pocetka prvog
                    return false;
                else if (DateTime.Compare(appointment1.EndTime, appointment2.StartTime) <= 0) //prvi zavrsava pre pocetka drugog
                    return false;
                else
                    return true;
            }

            return false;
        }

        private Boolean AppointmentsSharePatient(Appointment appointment1, Appointment appointment2)
        {
            return appointment1.Patient.Jmbg.Equals(appointment2.Patient.Jmbg);
        }

        private Boolean AppointmentsShareDoctor(Appointment appointment1, Appointment appointment2)
        {
            return appointment1.Doctor.Jmbg.Equals(appointment2.Doctor.Jmbg);
        }

        private Boolean AppointmentsShareDoctorSpeciality(Appointment appointment1, Appointment appointment2)
        {
            return appointment1.Doctor.Speciality.Name.Equals(appointment2.Doctor.Speciality.Name);
        }

        private Boolean AppointmentsShareRoom(Appointment appointment1, Appointment appointment2)
        {
            return appointment1.Room.RoomNumber == appointment2.Room.RoomNumber;
        }

        public DateTime FindNextFreeAppointmentStartTime(Appointment appointment)
        {
            AppointmentFileRepository appointmentFileRepository = new AppointmentFileRepository();
            List<Appointment> scheduledAppointments = appointmentFileRepository.GetAll();
            Boolean newTimeFound = false;
            while (!newTimeFound)
            {
                newTimeFound = true;
                foreach (Appointment a in scheduledAppointments)
                {
                    if (AppointmentsOverlap(a, appointment))
                    {
                        appointment.StartTime = CalculateNewStartTime(a.EndTime);
                        newTimeFound = false;
                        break;
                    }
                }
            }

            return appointment.StartTime;
        }

        private DateTime CalculateNewStartTime(DateTime overlapingAppointmentEndTime)
        {
            DateTime newStartTime = overlapingAppointmentEndTime;
            if (IsAfterWorkingHours(newStartTime))
            {
                newStartTime = new DateTime(newStartTime.Year, newStartTime.Month, newStartTime.Day, 8, 0, 0);
                newStartTime = newStartTime.AddDays(1);
            }

            return newStartTime;
        }

        private Boolean IsAfterWorkingHours(DateTime time)
        {
            DateTime endOfDay = new DateTime(time.Year, time.Month, time.Day, 19, 45, 0);
            if (time >= endOfDay)
                return true;

            return false;
        }

        public Boolean ScheduleEmergencyAppointment(Appointment emergencyAppointment)
        {
            if (emergencyAppointment == null)
                return false;

            if (emergencyAppointment.StartTime <= DateTime.Now.AddMinutes(15))
            {
                AppointmentFileRepository appointmentFileRepository = new AppointmentFileRepository();
                return appointmentFileRepository.Save(emergencyAppointment);
            }

            return false;
        }

        public Appointment FindEarliestEmergencyAppointment(Appointment modelAppointment, Speciality speciality)
        {
            DoctorFileRepository doctorFileRepository = new DoctorFileRepository();
            List<Doctor> doctors = doctorFileRepository.GetDoctorsWithSpeciality(speciality);

            List<Appointment> appointments = new List<Appointment>();
            foreach (Doctor d in doctors)
            {
                Appointment emergencyAppointment = new Appointment(0, modelAppointment.Patient, d,
                    modelAppointment.Room, DateTime.Now, modelAppointment.DurationInMunutes,
                    modelAppointment.ApointmentDescription, null, true);

                emergencyAppointment.StartTime = FindNextFreeAppointmentStartTime(emergencyAppointment);
                appointments.Add(emergencyAppointment);
            }

            return FindEarliestOfAppointments(appointments);
        }

        private Appointment FindEarliestOfAppointments(List<Appointment> appointments)
        {
            if (appointments.Count == 0)
                return null;
            Appointment earliestAppoinment = appointments[0];
            foreach (Appointment a in appointments)
            {
                if (a.StartTime < earliestAppoinment.StartTime)
                    earliestAppoinment = a;
            }

            return earliestAppoinment;
        }

        //******************************************
        private List<Appointment> SortAppointmentsByStartTime(List<Appointment> appointments)
        {
            appointments.Sort((a1, a2) => a1.StartTime.CompareTo(a2.StartTime));
            return appointments;
        }

        private List<Appointment> GetEmergencyOverlapingAppointments(Appointment appointment)
        {
            AppointmentFileRepository appointmentFileRepository = new AppointmentFileRepository();
            List<Appointment> scheduledAppointments = appointmentFileRepository.GetAll();
            List<Appointment> overlapingAppointments = new List<Appointment>();
            for (int i = 0; i < scheduledAppointments.Count; i++)
            {
                if (this.EmergencyAppointmentsOverlap(appointment, scheduledAppointments[i]))
                    overlapingAppointments.Add(scheduledAppointments[i]);
            }
            return overlapingAppointments;
        }

        private DateTime FindNextFreeAppointmentStartTimeInAppointments(Appointment appointment,
            List<Appointment> scheduledAppointments)
        {
            Boolean newTimeFound = false;
            while (!newTimeFound)
            {
                newTimeFound = true;
                foreach (Appointment a in scheduledAppointments)
                {
                    if (EmergencyAppointmentsOverlap(a, appointment))
                    {
                        appointment.StartTime = CalculateNewStartTime(a.EndTime);
                        newTimeFound = false;
                        break;
                    }
                }
            }

            return appointment.StartTime;
        }

        private Boolean EmergencyAppointmentsOverlap(Appointment appointment1, Appointment appointment2)
        {
            if (AppointmentsShareDoctorSpeciality(appointment1, appointment2) ||
                AppointmentsSharePatient(appointment1, appointment2) ||
                AppointmentsShareRoom(appointment1, appointment2))
            {
                if (DateTime.Compare(appointment2.EndTime, appointment1.StartTime) <=
                    0) //drugi zavrsava pre pocetka prvog
                    return false;
                else if (DateTime.Compare(appointment1.EndTime, appointment2.StartTime) <=
                         0) //prvi zavrsava pre pocetka drugog
                    return false;
                else
                    return true;
            }

            return false;
        }

        public List<AppointmentForReschedulingDTO> CreateAppointmentsForRescheduling(Appointment emergencyAppointment)
        {
            List<Appointment> overlapingAppointments = GetEmergencyOverlapingAppointments(emergencyAppointment);
            AppointmentFileRepository appointmentFileRepository = new AppointmentFileRepository();
            List<Appointment> scheduledAppointments = appointmentFileRepository.GetAll();
            scheduledAppointments.Add(emergencyAppointment);
            RemoveAppointmentsFromAppointentList(overlapingAppointments, scheduledAppointments);
            overlapingAppointments = SortAppointmentsByStartTime(overlapingAppointments);
            return TransformAppointmentsInAppointmentsForRescheduling(overlapingAppointments, scheduledAppointments);

        }

        private List<AppointmentForReschedulingDTO> TransformAppointmentsInAppointmentsForRescheduling(
            List<Appointment> overlapingAppointments, List<Appointment> scheduledAppointments)
        {
            List<AppointmentForReschedulingDTO> appointmentsForRescheduling = new List<AppointmentForReschedulingDTO>();
            foreach (Appointment appointment in overlapingAppointments)
            {
                AppointmentForReschedulingDTO ad = new AppointmentForReschedulingDTO(appointment);
                ad.SuggestedTime = FindNextFreeAppointmentStartTimeInAppointments(appointment, scheduledAppointments);
                appointment.StartTime = ad.SuggestedTime;
                scheduledAppointments.Add(appointment);
                appointmentsForRescheduling.Add(ad);
            }

            return appointmentsForRescheduling;
        }

        private void RemoveAppointmentsFromAppointentList(List<Appointment> appointmentsForRemoval,
            List<Appointment> appointments)
        {
            foreach (Appointment oAppointment in appointmentsForRemoval)
            {
                var appointment = appointments.FirstOrDefault(a => a.AppointentId.Equals(oAppointment.AppointentId));
                if (appointment != null)
                    appointments.Remove(appointment);
            }
        }

        public void RescheduleAppointmentForRescheduling(AppointmentForReschedulingDTO appointmentForRescheduling)
        {
            List<Appointment> scheduledAppointments = GetAllAppointments();
            Appointment rescheduledAppointment = scheduledAppointments.FirstOrDefault(a => a.AppointentId.Equals(appointmentForRescheduling.AppointmentId));
            if (rescheduledAppointment != null)
            {
                rescheduledAppointment.StartTime = appointmentForRescheduling.SuggestedTime;
                EditAppointment(rescheduledAppointment);
                Appointment previousAppointment = vezba.SecretaryGUI.SecretaryAppointments.Appointments.FirstOrDefault(a => a.AppointentId.Equals(rescheduledAppointment.AppointentId));
                if (previousAppointment != null)
                    vezba.SecretaryGUI.SecretaryAppointments.Appointments[vezba.SecretaryGUI.SecretaryAppointments.Appointments.IndexOf(previousAppointment)] = rescheduledAppointment;
            }
        }

        // SekretarKraj***************************************************************************

        // Pacijent*******************************************************************************
        public Boolean MoveableAppointment(DateTime initDate, DateTime pickedDate)
        {
            int diff = (pickedDate - initDate).Days;
            if (!(diff > 2))
                return false;

            return true;
        }

        public void ChangeAppointment(Appointment initAppointment, DateTime pickedDate, String pickedTime)
        {
            int id = initAppointment.AppointentId;
            pickedDate.ToString("MM/dd/yyyy");
            Doctor initDoctor = initAppointment.Doctor;
            DateTime parsedTime = DateTime.ParseExact(pickedTime, "HH:mm", CultureInfo.InvariantCulture);
            DateTime movedDate = pickedDate.Date.Add(parsedTime.TimeOfDay);

            Appointment changedAppointment = new Appointment(initDoctor, movedDate, PatientView.Patient);
            changedAppointment.AppointentId = id;
            EditAppointment(changedAppointment);

            Appointment idAppointment =
                ChangeAppointmentPage.Appointments.FirstOrDefault(a => a.AppointentId.Equals(id));
            if (idAppointment != null)
            {
                ChangeAppointmentPage.Appointments[ChangeAppointmentPage.Appointments.IndexOf(idAppointment)] =
                    changedAppointment;
            }
        }

        public Boolean PatientCanScheduleAppointment(Appointment newAppointment)
        {
            if (GetOverlapingAppointments(newAppointment).Count == 0)
            {
                EventsLogService.AddLog();
                PatientNotification noti = new PatientNotification("Uspesno ste zakazali pregled.");
                noti.ShowDialog();
                return AppointmentRepository.Save(newAppointment);
            }
            else
            {
                PatientNotification noti = new PatientNotification("Termin je zauzet! Izaberite drugo vreme.");
                noti.ShowDialog();
                return false;
            }
        }

        public DateTime ParseTime(DateTime selectedDate, String selectedTime)
        {
            selectedDate.ToString("MM/dd/yyyy");
            DateTime dateTime = DateTime.ParseExact(selectedTime, "HH:mm", CultureInfo.InvariantCulture);
            DateTime dateTimeFinal = selectedDate.Date.Add(dateTime.TimeOfDay);
            return dateTimeFinal;
        }

        public Boolean CanSchedule(DateTime selectedDate)
        {
            int diff = (selectedDate - DateTime.Now.Date).Days;
            if (diff <= 0)
                return false;
            return true;
        }

        public List<Appointment> GetPatientFutureAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllAppointments())
            {
                if (appointment.StartTime.Date > DateTime.Today &&
                    appointment.Patient.Jmbg.Equals(PatientView.Patient.Jmbg))
                {
                    appointments.Add(appointment);
                }
            }

            appointments.Sort((x, y) => y.StartTime.CompareTo(x.StartTime));
            appointments.Reverse();
            return appointments;
        }

        public List<Appointment> GetPatientPastAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllAppointments())
            {
                if (appointment.StartTime.Date < DateTime.Now &&
                    appointment.Patient.Jmbg.Equals(PatientView.Patient.Jmbg))
                {
                    appointments.Add(appointment);
                }
            }

            appointments.Sort((x, y) => y.StartTime.CompareTo(x.StartTime));
            appointments.Reverse();
            return appointments;
        }

        public List<Appointment> GetPatientTodayAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in GetAllAppointments())
            {
                if (appointment.StartTime.Date == DateTime.Today &&
                    appointment.Patient.Jmbg.Equals(PatientView.Patient.Jmbg))
                {
                    appointments.Add(appointment);
                }
            }

            appointments.Sort((x, y) => y.StartTime.CompareTo(x.StartTime));
            appointments.Reverse();
            return appointments;
        }

        public void GetTodaysAppointments(ObservableCollection<Appointment> appointments)
        {
            foreach (Appointment appointment in GetAllAppointments())
            {
                if (appointment.StartTime.Date == DateTime.Today && appointment.Patient.Jmbg.Equals(PatientView.Patient.Jmbg))
                {
                    appointments.Add(appointment);
                }
            }
        }

        public void GetThisWeeksAppointments(ObservableCollection<Appointment> appointments)
        {
            DateTime startOfWeek = DateTime.Today.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            foreach (Appointment appointment in GetAllAppointments())
            {
                if (appointment.StartTime.Date >= DateTime.Today && appointment.StartTime.Date <= endOfWeek && appointment.Patient.Jmbg.Equals(PatientView.Patient.Jmbg))
                {
                    appointments.Add(appointment);
                }
            }
        }

        public void GetThisMonthsAppointments(ObservableCollection<Appointment> appointments)
        {
            foreach (Appointment appointment in GetAllAppointments())
            {
                if (appointment.StartTime.Date >= DateTime.Today && appointment.StartTime.Month == DateTime.Now.Month && appointment.Patient.Jmbg.Equals(PatientView.Patient.Jmbg))
                {
                    appointments.Add(appointment);
                }
            }
        }


        public void NoteNotification()
        {
            while (true)
            {
                foreach (Appointment a in GetPatientPastAppointments())
                {
                    GenerateNotification(a);
                }          
            }
        }

        private List<DateTime> AddTimeToSpan(Appointment appointment)
        {
            DateTime it = new DateTime();
            it = appointment.Note.StartDate;
            DateTime start = appointment.Note.StartDate;
            DateTime end = appointment.Note.EndDate;
            String time = appointment.Note.Time.ToString("HH:mm");
            List<DateTime> notifications = new List<DateTime>();

            while(it.Date <= end)
            {
                notifications.Add(DateTime.ParseExact(it.Date.ToString("dd/MM/yy") + " " + time, "dd/MM/yy hh:mm", CultureInfo.InvariantCulture));
            }
            it = it.AddDays(1);

            return notifications;
        }

        public List<DateTime> GenerateNotification(Appointment appointment)
        {
            List<DateTime> notifications = AddTimeToSpan(appointment);
            foreach (DateTime dt in notifications)
            {              
                PatientNotification noti = new PatientNotification(appointment.Note.NoteContent);
                noti.Show();
            }
            return notifications;
        }

        // PacijentKraj***************************************************************************

        // Lekar**********************************************************************************
        public Boolean DoctorRescheduleAppointment(Appointment editedAppointment)
        {
            List<Appointment> overlappingAppointments = GetOverlapingAppointments(editedAppointment);
            RemoveAppointment(editedAppointment, overlappingAppointments);
            if (overlappingAppointments.Count == 0)
                return AppointmentRepository.Update(editedAppointment);
            else
            {
                MessageBox.Show(
                    "Termin je zauzet! Izaberite drugo vreme.\nPrvi sledeci dostupan termin za unete kriterijume je " +
                    FindNextFreeAppointmentStartTime(editedAppointment).ToString("dd.MM.yyyy. HH:mm"));
                return false;
            }
        }

        private static void RemoveAppointment(Appointment appointmentToRemove, List<Appointment> appointments)
        {
            foreach (var appointment in appointments)
            {
                if (appointment.AppointentId == appointmentToRemove.AppointentId)
                {
                    appointments.Remove(appointment);
                    break;
                }
            }
        }

        public TimeSpan GetEarliestTime(List<Appointment> appointments)
        {
            var earliestTime = appointments[0].StartTime.TimeOfDay;
            foreach (var appointment in appointments)
            {
                if (TimeSpan.Compare(appointment.StartTime.TimeOfDay, earliestTime) < 0)
                {
                    earliestTime = appointment.StartTime.TimeOfDay;
                }
            }

            return earliestTime;
        }

        public List<Appointment> GenerateAppointmentsForWeekAndDoctor(DateTime startOfWeek, DateTime endOfWeek,
            Doctor selectedDoctor)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<Appointment> allAppointments = GetAllAppointments();

            foreach (var appointment in allAppointments)
            {
                if (appointment.Doctor == null)
                    continue;
                if (IsAppointmentInCurrentView(appointment, startOfWeek, endOfWeek, selectedDoctor))
                {
                    appointments.Add(appointment);
                }
            }

            return appointments;
        }

        public Boolean IsAppointmentInCurrentView(Appointment appointment, DateTime startOfWeek, DateTime endOfWeek,
            Doctor selectedDoctor)
        {
            return DateTime.Compare(appointment.StartTime, startOfWeek) > 0 &&
                   DateTime.Compare(appointment.StartTime, endOfWeek) < 0 &&
                   appointment.Doctor.Jmbg.Equals(selectedDoctor.Jmbg);
        }

        // LekarKraj******************************************************************************

        // Upravnik*******************************************************************************

        public Boolean Overlap(int number, DateTime StartTime, DateTime EndTime)
        {
            var has_appointment = false;
            
            List<Appointment> appointments = GetAllAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Room != null)
                {
                    if (appointment.Room.RoomNumber == number)
                    {
                        DateTime appointmentStart = appointment.StartTime;
                        if (DateTime.Compare(appointmentStart, StartTime) > 0 &&
                            DateTime.Compare(appointmentStart, EndTime) < 0)
                        {
                            MessageBox.Show("Datum renovacije se poklapa sa već zakazanim pregledima");
                            has_appointment = true;
                        }
                    }
                }
            }
        return has_appointment;
        }


        public Boolean HasFutureAppointments(int number, DateTime StartTime, DateTime EndTime)
        {
            var has_appointment = false;

            List<Appointment> appointments = GetAllAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Room != null)
                {
                    if (appointment.Room.RoomNumber == number)
                    {
                        DateTime appointmentStart = appointment.StartTime;

                        if (DateTime.Compare(appointmentStart, EndTime) > 0)
                        {
                            MessageBox.Show("Postoje termini u sobi koju nameravate podeliti zakazani nakon renoviranja");
                            has_appointment = true;
                        }
                    }
                }
            }
            return has_appointment;
        }
        // UpravnikKraj***************************************************************************
    }
}

