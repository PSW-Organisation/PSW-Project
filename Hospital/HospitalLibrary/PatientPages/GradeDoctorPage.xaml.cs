using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using vezba.Repository;

namespace vezba.PatientPages
{
    public partial class GradeDoctorPage : Page
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        private AppointmentService AppointmentService { get; set; }

        public GradeDoctorPage()
        {
            InitializeComponent();
            this.DataContext = this;
            AppointmentService = new AppointmentService();
            List<Appointment> appointments = AppointmentService.GetPatientPastAppointments();
            Appointments = new ObservableCollection<Appointment>(appointments);
        }

        /*private void ButtonGradeDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (gradingTable.SelectedItems.Count > 0)
            {
                Appointment appointment = (Appointment)gradingTable.SelectedItem;
                Doctor selectedDoctor = appointment.Doctor;
                this.NavigationService.Navigate(new GradeSelectedDoctorPage(selectedDoctor));
            }
            else
            {
                var s = new TableNote();
                s.ShowDialog();
            }         
        }*/

        private void GradeDoctor_Click(object sender, SelectionChangedEventArgs e)
        {
            if (gradingTable.SelectedItems.Count > 0)
            {
                Appointment appointment = (Appointment)gradingTable.SelectedItem;
                Doctor selectedDoctor = appointment.Doctor;
                this.NavigationService.Navigate(new GradeSelectedDoctorPage(selectedDoctor));
            }
            else
            {
                var s = new TableNote();
                s.ShowDialog();
            }
        }

        /*private List<Appointment> AppointmentsToGradeDoctors()
        {
            List<Appointment> appointments = AppointmentService.GetPatientPastAppointments();
            Doctor firstTimeDoctor = appointments[0].Doctor;
            DateTime firstAppointmentDate = appointments[0].StartTime;
            foreach (Appointment appointment in appointments)
            {
                Doctor appointmentDoctor = appointment.Doctor;
                DateTime appointmentTime = appointment.StartTime;

                if (firstTimeDoctor == doctor)
                {

                }
            }

            return appointments;
        }*/
    }
}
