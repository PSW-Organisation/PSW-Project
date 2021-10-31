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
    public partial class AppointmentHistoryPage : Page
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public AppointmentHistoryPage()
        {
            InitializeComponent();
            AppointmentService = new AppointmentService();
            this.DataContext = this;
            List<Appointment> appointments = AppointmentService.GetPatientPastAppointments();
            Appointments = new ObservableCollection<Appointment>(appointments);
        }

        private void LeaveNote_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)historyTable.SelectedItem;
            this.NavigationService.Navigate(new AppointmentDetails(appointment));
        }
    }
}
