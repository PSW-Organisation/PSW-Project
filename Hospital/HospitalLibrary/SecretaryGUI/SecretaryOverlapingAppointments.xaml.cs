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
using System.Windows.Shapes;
using vezba.Repository;

namespace vezba.SecretaryGUI
{
    public partial class SecretaryOverlapingAppointments : Window
    {
        public ObservableCollection<AppointmentForReschedulingDTO> Appointments { get; set; }
        public SecretaryOverlapingAppointments(Appointment emergencyAppointment)
        {
            InitializeComponent();
            this.DataContext = this;
            Appointments = new ObservableCollection<AppointmentForReschedulingDTO>();

            Patient.Content = emergencyAppointment.PatientName;
            Speciality.Content = emergencyAppointment.Doctor.SpecialityName;
            Room.Content = emergencyAppointment.RoomName;
            Duration.Content = emergencyAppointment.DurationInMunutes;

            emergencyAppointment.StartTime = DateTime.Now;
            AppointmentService appointmentService = new AppointmentService();
            List<AppointmentForReschedulingDTO> appointmentsForRescheduling = appointmentService.CreateAppointmentsForRescheduling(emergencyAppointment);
            foreach (AppointmentForReschedulingDTO afr in appointmentsForRescheduling)
                Appointments.Add(afr);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void RescheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (overlapingAppointmentsTable.SelectedCells.Count > 0)
            {
                AppointmentForReschedulingDTO selectedAppointmentForRescheduling = (AppointmentForReschedulingDTO)overlapingAppointmentsTable.SelectedItem;
                AppointmentService appointmentService = new AppointmentService();
                appointmentService.RescheduleAppointmentForRescheduling(selectedAppointmentForRescheduling);

                SecretaryMessage m1 = new SecretaryMessage("Uspešno ste odložili termin.");
                m1.ShowDialog();
                Appointments.Remove(selectedAppointmentForRescheduling);
                return;
            }
            SecretaryMessage m2 = new SecretaryMessage("Niste selektovali termin.");
            m2.ShowDialog();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.E)
                this.RescheduleButton_Click(sender, e);
        }

    }
}
