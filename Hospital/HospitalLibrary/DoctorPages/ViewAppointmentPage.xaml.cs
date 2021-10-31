using System;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;
using vezba.Adapter;
using Calendar = vezba.DoctorPages.Calendar;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for ViewAppointmentPage.xaml
    /// </summary>
    public partial class ViewAppointmentPage : Page
    {

        private Appointment Appointment { get; set; }
        private readonly DoctorView _doctorView;
        private CalendarInterface calendarInterface;

        public ViewAppointmentPage(Appointment appointment, DoctorView doctorView, CalendarInterface calendarInterface)
        {
            InitializeComponent();
            DataContext = appointment;
            Appointment = appointment;
            _doctorView = doctorView;
            this.calendarInterface = calendarInterface;
            IsEmergencyTB.Text = (Appointment.IsEmergency) ? "Da" : "Ne";
        }

        private void MedicalRecordClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.Content = new MedicalRecordPage(Appointment.Patient, _doctorView);
        }

        private void NewAnamnesisClick(object sender, RoutedEventArgs e)
        {
            if (DateTime.Compare(DateTime.Now, Appointment.StartTime) >= 0)
            {
                _doctorView.Main.Content = new CreateAnamnesisPage(Appointment, _doctorView);
            }
            else
            {
                MessageBox.Show("Nije moguće kreirati izveštaj pre termina pregleda!");
            }
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.Content = new EditAppointmentPage(Appointment, _doctorView, calendarInterface);
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
                var appointmentService = new AppointmentService();
                appointmentService.DeleteAppointment(Appointment.AppointentId);
                calendarInterface.DeleteAppointment(Appointment);
                _doctorView.Main.GoBack();
        }

        private void AddPresetButton_Click(object sender, RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            if (addButton != null)
            {
                addButton.ContextMenu.IsOpen = true;
            }
        }
    }
}
