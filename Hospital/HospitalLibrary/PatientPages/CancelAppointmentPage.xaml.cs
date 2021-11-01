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

namespace vezba.PatientPages
{
    public partial class CancelAppointmentPage : Page
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public CancelAppointmentPage()
        {
            InitializeComponent();
            AppointmentService = new AppointmentService();
            this.DataContext = this;
            List<Appointment> appointments = AppointmentService.GetPatientFutureAppointments();
            Appointments = new ObservableCollection<Appointment>(appointments);
        }

        private void ButtonCancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (cancelTable.SelectedItems.Count > 0)
            {
                Appointment a = (Appointment)cancelTable.SelectedItem;
                Boolean deleted = AppointmentService.DeleteAppointment(a.AppointentId);
                Appointments.Remove(a);
                if (deleted)
                {
                    PatientNotification noti = new PatientNotification("Uspešno ste otkazali pregled.");
                    noti.ShowDialog();
                }
            }
            else
            {
                PatientNotification noti = new PatientNotification("Niste izabrali pregled!");
                noti.ShowDialog();
            }
        }
    }
}
