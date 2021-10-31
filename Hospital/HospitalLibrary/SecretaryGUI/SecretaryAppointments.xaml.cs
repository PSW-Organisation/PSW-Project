using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using vezba.Template;

namespace vezba.SecretaryGUI
{
    public partial class SecretaryAppointments : Page
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        public SecretaryAppointments()
        {
            InitializeComponent();
            this.DataContext = this;
            AppointmentService s = new AppointmentService();
            Appointments = new ObservableCollection<Appointment>(s.GetAllAppointments());
        }

        private void NewAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryNewAppointment w = new SecretaryNewAppointment(0);
            w.ShowDialog();
        }

        private void NewEmergencyAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryNewEmergencyAppointment w = new SecretaryNewEmergencyAppointment();
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
            //MessageBox.Show("Niste selektovali termin!");
            SecretaryMessage m = new SecretaryMessage("Niste selektovali termin.");
            m.ShowDialog();
        }

        private void RemoveEditMessage()
        {
            Thread.Sleep(1500);
            EditSuccMessage.Visibility = System.Windows.Visibility.Collapsed;
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
                SecretaryEditAppointment w = new SecretaryEditAppointment(selectedAppointment);
                w.ShowDialog();
                EditSuccMessage.Visibility = System.Windows.Visibility.Visible;
                RemoveEditMessage();
                return;
                //Thread.Sleep(1500);
                //EditSuccMessage.Visibility = System.Windows.Visibility.Collapsed;
            }
            //MessageBox.Show("Niste selektovali termin!");

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
            //MessageBox.Show("Niste selektovali termin!");
            SecretaryMessage m = new SecretaryMessage("Niste selektovali termin.");
            m.ShowDialog();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryAppointmentFilter w = new SecretaryAppointmentFilter();
            w.Show();
        }

        private void MakeReportButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryCreateReport w = new SecretaryCreateReport();
            w.Show();
        }


        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Appointments.Clear();
                AppointmentService appointmentService = new AppointmentService();
                List<Appointment> appointments = new List<Appointment>();
                String input = SearchBox.Text;
                if (input.Trim().Equals(""))
                {
                    foreach (Appointment a in appointmentService.GetAllAppointments())
                    {
                        Appointments.Add(a);
                    }
                    return;
                }
                appointments = DoSearch<Appointment>.GetSearchResult(new SearchAppointments(), input);
                //appointments = appointmentService.GetSearchResultAppointments(search);
                foreach (Appointment a in appointments)
                {
                    Appointments.Add(a);
                }
            }
        }

        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
                this.ViewAppointmentButton_Click(sender, e);
            else if (e.Key == Key.N)
                this.NewAppointmentButton_Click(sender, e);
            else if (e.Key == Key.H)
                this.NewEmergencyAppointmentButton_Click(sender, e);
            else if (e.Key == Key.E)
                this.EditAppointmentButton_Click(sender, e);
            else if (e.Key == Key.R)
                this.MakeReportButton_Click(sender, e);
            else if (e.Key == Key.F)
                this.FilterButton_Click(sender, e);
            else if (e.Key == Key.D)
                this.DeleteAppointmentButton_Click(sender, e);
        }

    }
}
