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
    /// <summary>
    /// Interaction logic for SecretaryAppointmentFilter.xaml
    /// </summary>
    public partial class SecretaryAppointmentFilter : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string date1Input;
        public string Date1Input
        {
            get { return date1Input; }
            set
            {
                if (value != date1Input)
                {
                    date1Input = value;
                    OnPropertyChanged("Date1Input");
                }
            }
        }

        private string date2Input;
        public string Date2Input
        {
            get { return date2Input; }
            set
            {
                if (value != date2Input)
                {
                    date2Input = value;
                    OnPropertyChanged("Date2Input");
                }
            }
        }

        public SecretaryAppointmentFilter()
        {
            InitializeComponent();
            AllConditions.IsChecked = true;
            this.DataContext = this;
            PatientService ps = new PatientService();
            List<Patient> patients = ps.GetAllPatients();
            Patient.ItemsSource = patients;
            DoctorService ds = new DoctorService();
            List<Doctor> doctors = ds.GetAllDoctors();
            Doctor.ItemsSource = doctors;
            RoomService rs = new RoomService();
            List<Room> rooms = rs.GetAllRooms();
            Room.ItemsSource = rooms;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? from = null;
            if (From.Text.Trim() != "")
            {
                try
                {
                    from = DateTime.ParseExact(From.Text, "dd.MM.yyyy.", null);
                }
                catch
                {
                    MessageBox.Show("Uneli ste nevalidan pocetni datum.");
                    return;
                }
            }

            DateTime? to = null;
            if (To.Text.Trim() != "")
            {
                try
                {
                    to = DateTime.ParseExact(To.Text, "dd.MM.yyyy.", null);
                }
                catch
                {
                    MessageBox.Show("Uneli ste nevalidan krajnji datum.");
                    return;
                }
            }

            Patient p = (Patient)Patient.SelectedItem;
            Doctor d = (Doctor)Doctor.SelectedItem;
            Room r = (Room)Room.SelectedItem;
            AppointmentService appointmentService = new AppointmentService();
            List<Appointment> appointments = new List<Appointment>();
            if (AllConditions.IsChecked == true)
            {
                appointments = appointmentService.GetAppointmentsWithAllConditions(from, to, p, d, r);
            }
            else
            {
                appointments = appointmentService.GetAppointmentsWithAnyCondition(from, to, p, d, r);
            }
            DoctorPages.AppointmentGrid.Appointments.Clear();
            foreach (Appointment a in appointments)
            {
                DoctorPages.AppointmentGrid.Appointments.Add(a);
            }
            this.Close();

        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}