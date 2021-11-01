using Model;
using Service;
using System;
using System.Collections.Generic;
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
using vezba.Repository;

namespace vezba.SecretaryGUI
{
    public partial class SecretaryNewEmergencyAppointment : Window
    {
        public SecretaryNewEmergencyAppointment()
        {
            InitializeComponent();
            this.DataContext = this;
            PatientFileRepository ps = new PatientFileRepository();
            List<Patient> patients = ps.GetAll();
            Patient.ItemsSource = patients;
            List<Speciality> specialities = new List<Speciality>();
            specialities.Add(new Speciality("Kardiolog"));
            specialities.Add(new Speciality("Opsti"));
            specialities.Add(new Speciality("Stomatolog"));
            specialities.Add(new Speciality("Oftalmolog"));
            Speciality.ItemsSource = specialities;
            RoomFileRepository rs = new RoomFileRepository();
            List<Room> rooms = rs.GetAll();
            Room.ItemsSource = rooms;
            List<int> durations = new List<int> { 15, 30, 45, 60 };
            Duration.ItemsSource = durations;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void RegisterPatientButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryNewPatient s = new SecretaryNewPatient();
            s.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)Patient.SelectedItem;
            Speciality speciality = (Speciality)Speciality.SelectedItem;
            Room room = (Room)Room.SelectedItem;
            int duration = (int)Duration.SelectedItem;
            string description = Description.Text;

            Appointment modelAppointment = new Appointment(0, patient, null, room, DateTime.Now, duration, description, null, true);
            AppointmentService appointmentService = new AppointmentService();

            Appointment emergencyAppointment = appointmentService.FindEarliestEmergencyAppointment(modelAppointment, speciality);
            Boolean isSuccess = appointmentService.ScheduleEmergencyAppointment(emergencyAppointment);
            if (isSuccess)
            {
                SecretaryAppointments.Appointments.Add(emergencyAppointment);
                SecretaryMessage m1 = new SecretaryMessage("Zakazan je hitan termin za " + emergencyAppointment.StartTime.ToString("dd.MM.yyyy. HH:mm") + " kod lekara " + emergencyAppointment.DoctorName);
                m1.ShowDialog();
                this.Close();

            }
            else
            {
                SecretaryNearestAvailableEmergencyAppointment w = new SecretaryNearestAvailableEmergencyAppointment(emergencyAppointment);
                w.ShowDialog();
            }

            return;

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
