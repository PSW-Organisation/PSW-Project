using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace vezba.PatientPages
{
    public partial class AppointmentsPage : Page
    {
        public static Patient Patient { get; set; }
        public List<EventsLog> Logs { get; set; }
        private EventsLogService EventsLogService { get; set; }
        private PatientService PatientService { get; set; }
        public AppointmentsPage()
        {
            InitializeComponent();
            EventsLogService = new EventsLogService();
            PatientService = new PatientService();
        }

        private void ButtonOrderAppointment_Click(object sender, RoutedEventArgs e)
        {
            CheckPatientBlockage();
            if (Patient.IsBlocked)
            {
                PatientNotification noti = new PatientNotification("Trenutno ne mozete da zakažete pregled!");
                noti.ShowDialog();
            }
            else
            {
                this.NavigationService.Navigate(new DoctorOrTimePage());
            }
        }

        private void ButtonChangeAppointment_Click(object sender, RoutedEventArgs e)
        {
            CheckPatientBlockage();
            if (Patient.IsBlocked)
            {
                PatientNotification noti = new PatientNotification("Trenutno ne mozete da izmenite pregled!");
                noti.ShowDialog();
            }
            else
            {
                this.NavigationService.Navigate(new ChangeAppointmentPage());
            }
        }

        private void CheckPatientBlockage()
        {
            Logs = EventsLogService.GetAllLogs();
            Patient = PatientView.Patient;
            for (int i = 0; i < Logs.Count; i++)//kroz pacijente
            {
                if (Logs[i].PatientJmbg.Equals(Patient.Jmbg))
                {
                    if (!Patient.IsBlocked)
                    {
                        EventsLog log = Logs[i];
                        List<DateTime> events = log.EventDates;
                        DateTime reff = DateTime.Now.Date.AddDays(-5);
                        int count = 0;
                        foreach (DateTime event1 in events)
                        {
                            if (event1.Date >= reff)
                            {
                                count++;
                            }
                        }
                        if (count == 10)
                        {
                            Patient.IsBlocked = true;
                            PatientService.EditPatient(Patient);
                            events.Clear();
                            EventsLogService.EditLog(log);
                        }
                    }
                }
            }
        }

        private void ButtonCancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CancelAppointmentPage());
        }

        private void ButtonHistoryAppointment_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AppointmentHistoryPage());
        }
    }
}
