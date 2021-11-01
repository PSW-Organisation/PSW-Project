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
    public partial class SecretaryNewAppointment : Window, INotifyPropertyChanged
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
        private Patient Patient { get; }
        private int mode;
        public SecretaryNewAppointment(int mode, Patient patient = null)
        {
            InitializeComponent();
            this.DataContext = this;
            Patient = patient;
            this.mode = mode;
            PatientService ps = new PatientService();
            List<Patient> patients = ps.GetAllPatients();
            PatientCB.ItemsSource = patients;
            if (patient != null)
            {
                PatientCB.Visibility = System.Windows.Visibility.Collapsed;
                PatientLabel.Content = patient.NameAndSurname;
            }
            else
                PatientLabel.Visibility = System.Windows.Visibility.Collapsed;
            DoctorService ds = new DoctorService();
            List<Doctor> doctors = ds.GetAllDoctors();
            Doctor.ItemsSource = doctors;
            RoomService rs = new RoomService();
            List<Room> rooms = rs.GetAllRooms();
            Room.ItemsSource = rooms;
            List<int> durations = new List<int> { 15, 30, 45, 60 };
            Duration.ItemsSource = durations;
            List<string> hours = new List<string> { "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };
            Hours.ItemsSource = hours;
            List<string> minutes = new List<string> { "00", "15", "30", "45" };
            Minutes.ItemsSource = minutes;
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateEntries() == false)
                return;
            DoctorService doctorService = new DoctorService();
            string docUnavailable = doctorService.GenerateDoctorIsUnavailableMessage(((Doctor)Doctor.SelectedItem).Jmbg, GetTime());
            if (docUnavailable != null)
            {
                SecretaryMessage m1 = new SecretaryMessage(docUnavailable);
                m1.ShowDialog();
                return;
            }
            AppointmentService appointmentService = new AppointmentService();
            Appointment newAppointment;
            if (Patient != null)
                newAppointment = new Appointment(0, Patient, (Doctor)Doctor.SelectedItem, (Room)Room.SelectedItem, GetTime(), (int)Duration.SelectedItem, Description.Text, null);
            else
                newAppointment = new Appointment(0, (Patient)PatientCB.SelectedItem, (Doctor)Doctor.SelectedItem, (Room)Room.SelectedItem, GetTime(), (int)Duration.SelectedItem, Description.Text, null);

            Boolean isSuccess = appointmentService.ScheduleAppointment(newAppointment);
            if (isSuccess)
            {
                if (mode == 1)
                    SecretaryPatientAppointments.Appointments.Add(newAppointment);
                if (mode == 0)
                    SecretaryAppointments.Appointments.Add(newAppointment);
                SecretaryMessage m1 = new SecretaryMessage("Termin je uspešno zakazan.");
                m1.ShowDialog();
                this.Close();
            }

        }

        //HCI deo
        private Boolean ValidateEntries()
        {
            if (PatientCB.SelectedItem == null && Patient == null)
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste uneli pacijenta.");
                m1.ShowDialog();
                return false;
            }
            if (Doctor.SelectedItem == null)
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste uneli lekara.");
                m1.ShowDialog();
                return false;
            }
            if (Room.SelectedItem == null)
            {
                MessageBox.Show("Niste uneli prostoriju!");
                return false;
            }
            if (Hours.SelectedItem == null || Minutes.SelectedItem == null)
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste izabrali vreme.");
                m1.ShowDialog();
                return false;
            }
            if (DateTime.Compare(GetTime(), DateTime.Now) < 0)
            {
                SecretaryMessage m1 = new SecretaryMessage("Izabrani datum je već prošao.");
                m1.ShowDialog();
                return false;
            }
            if (Duration.SelectedItem == null)
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste izabrali trajanje termina.");
                m1.ShowDialog();
                return false;
            }
            return true;
        }

        private DateTime GetTime()
        {
            DateTime selectedDate = new DateTime(1900, 1, 1);
            try
            {
                selectedDate = DateTime.ParseExact(Date.Text, "dd.MM.yyyy.", null);
            }
            catch
            {

            }
            string hours = (string)Hours.SelectedItem;
            string minutes = (string)Minutes.SelectedItem;
            String selectedTime = (Convert.ToString(hours) + ":" + Convert.ToString(minutes)).Trim();
            DateTime time;
            DateTime.TryParseExact(selectedTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time);
            DateTime startTime = selectedDate.Date.Add(time.TimeOfDay);
            return startTime;
        }
    }
}
