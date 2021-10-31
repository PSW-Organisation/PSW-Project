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
    public partial class ChangeAppointmentPage : Page
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public ChangeAppointmentPage()
        {
            InitializeComponent();
            this.DataContext = this;
            AppointmentService = new AppointmentService();
            List<Appointment> appointments = AppointmentService.GetPatientFutureAppointments();
            Appointments = new ObservableCollection<Appointment>(appointments);
        }

        private void Select_Click(object sender, SelectionChangedEventArgs e)
        {
            if (appointmentsTable.SelectedItems.Count > 0)
            {
                Appointment selectedAppointment = (Appointment)appointmentsTable.SelectedItem;
                this.NavigationService.Navigate(new EditAppointmentPage(selectedAppointment));
            }
            else
            {
                PatientNotification noti = new PatientNotification("Niste selektovali pregled koji želite da promenite!");
                noti.ShowDialog();
            }
        }
    }
}
