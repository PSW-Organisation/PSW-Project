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

namespace vezba.SecretaryGUI
{
    public partial class SecretaryPatientAppointments : Window
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        private Patient Patient { get; }
        public SecretaryPatientAppointments(Patient selectedPatient)
        {
            InitializeComponent();
            Patient = selectedPatient;
            this.DataContext = this;
            AppointmentService s = new AppointmentService();
            Appointments = new ObservableCollection<Appointment>(s.GetAppointmentsForPatient(selectedPatient.Jmbg));
        }

        private void NewAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryNewAppointment w = new SecretaryNewAppointment(1, Patient);
            w.ShowDialog();
        }

        private void ViewAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsTable.SelectedCells.Count > 0)
            {
                Appointment selectedAppointment = (Appointment)appointmentsTable.SelectedItem;
                SecretaryViewAppointment w = new SecretaryViewAppointment(selectedAppointment);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m = new SecretaryMessage("Niste selektovali termin.");
            m.ShowDialog();
        }

        private void EditAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsTable.SelectedCells.Count > 0)
            {
                Appointment selectedAppointment = (Appointment)appointmentsTable.SelectedItem;
                if (selectedAppointment.StartTime < DateTime.Now)
                {
                    SecretaryMessage m1 = new SecretaryMessage("Ne možete da izmenite termin koji je već prošao.");
                    m1.ShowDialog();
                    return;
                }
                SecretaryEditAppointment w = new SecretaryEditAppointment(selectedAppointment, 1);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m = new SecretaryMessage("Niste selektovali termin.");
            m.ShowDialog();
        }

        private void DeleteAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsTable.SelectedCells.Count > 0)
            {
                Appointment selectedAppointment = (Appointment)appointmentsTable.SelectedItem;

                SecretaryDeleteConfirmation dc = new SecretaryDeleteConfirmation(selectedAppointment);
                Boolean ic = false;
                dc.ShowDialog();
                ic = dc.isConfirmed;
                if (!ic)
                    return;
                AppointmentService appointmentService = new AppointmentService();
                appointmentService.DeleteAppointment(selectedAppointment.AppointentId);
                Appointments.Remove(selectedAppointment);
                return;
            }
            SecretaryMessage m = new SecretaryMessage("Niste selektovali termin.");
            m.ShowDialog();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
                this.ViewAppointmentButton_Click(sender, e);
            else if (e.Key == Key.N)
                this.NewAppointmentButton_Click(sender, e);
            else if (e.Key == Key.E)
                this.EditAppointmentButton_Click(sender, e);
            else if (e.Key == Key.D)
                this.DeleteAppointmentButton_Click(sender, e);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}