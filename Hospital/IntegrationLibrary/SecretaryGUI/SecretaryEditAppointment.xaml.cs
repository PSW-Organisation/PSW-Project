using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace vezba.SecretaryGUI
{
    public partial class SecretaryEditAppointment : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string dateInput;
        public string DateInput
        {
            get { return dateInput; }
            set
            {
                if (value != dateInput)
                {
                    dateInput = value;
                    OnPropertyChanged("DateInput");
                }
            }
        }

        private Appointment appointment;
        private int mode;
        public SecretaryEditAppointment(Appointment a, int mode = 0)
        {
            InitializeComponent();
            this.mode = mode;
            appointment = a;
            Patient.Content = appointment.PatientName;
            Doctor.Content = appointment.DoctorName;
            Room.Content = appointment.RoomName;
            Duration.Content = appointment.DurationInMunutes;
            Description.Text = appointment.ApointmentDescription;

            List<string> hours = new List<string> { "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };
            Hours.ItemsSource = hours;
            string h = appointment.StartTime.ToString("HH");
            Hours.SelectedItem = h;
            List<string> minutes = new List<string> { "00", "15", "30", "45" };
            Minutes.ItemsSource = minutes;
            string m = appointment.StartTime.ToString("mm");
            Minutes.SelectedItem = m;
            Date.Text = appointment.StartTime.ToString("dd.MM.yyyy.");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startTime = GetTime();
            this.appointment.StartTime = startTime;
            if (ValidateTime() == false)
            {
                SecretaryMessage m1 = new SecretaryMessage("Izabrani datum je već prošao.");
                m1.ShowDialog();
            }

            Appointment newAppointment = new Appointment(appointment.AppointentId, appointment.Patient, appointment.Doctor, appointment.Room, startTime, appointment.DurationInMunutes, appointment.ApointmentDescription, null);

            AppointmentService appointmentService = new AppointmentService();
            Boolean success = appointmentService.RescheduleAppointment(newAppointment);
            if (success)
            {
                if (mode == 0)
                {
                    var previousAppointment = SecretaryAppointments.Appointments.FirstOrDefault(a => a.AppointentId.Equals(this.appointment.AppointentId));
                    if (previousAppointment != null)
                        SecretaryAppointments.Appointments[SecretaryAppointments.Appointments.IndexOf(previousAppointment)] = newAppointment;
                }
                else
                {
                    var previousAppointment = SecretaryPatientAppointments.Appointments.FirstOrDefault(a => a.AppointentId.Equals(this.appointment.AppointentId));
                    if (previousAppointment != null)
                        SecretaryPatientAppointments.Appointments[SecretaryPatientAppointments.Appointments.IndexOf(previousAppointment)] = newAppointment;
                }

                SecretaryMessage m1 = new SecretaryMessage("Termin je uspešno zakazan.");
                m1.ShowDialog();
                this.Close();
            }

        }



        private Boolean ValidateTime()
        {
            if (DateTime.Compare(GetTime(), DateTime.Now) < 0)
                return false;
            else
                return true;
        }

        private DateTime GetTime()
        {
            DateTime selectedDate = new DateTime(1900, 1, 1);
            /*try
            {
                selectedDate = Date.SelectedDate.Value.Date;
            }
            */
            try
            {
                selectedDate = DateTime.ParseExact(Date.Text, "dd.MM.yyyy.", null);
            }
            catch
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste izabrali datum.");
                m1.ShowDialog();
                return selectedDate;
            }
            string hours = (string)Hours.SelectedItem;
            string minutes = (string)Minutes.SelectedItem;
            String selectedTime = (Convert.ToString(hours) + ":" + Convert.ToString(minutes)).Trim();
            DateTime time;
            DateTime.TryParseExact(selectedTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time);
            DateTime startTime = selectedDate.Date.Add(time.TimeOfDay);
            return startTime;
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();

            else if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
    }
}
