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
    public partial class MorePage : Page
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        public static int currentAppointments = 0;
        private AppointmentService AppointmentService { get; set; }

        public MorePage()
        {
            InitializeComponent();
            AppointmentService = new AppointmentService();
            List<Appointment> appointments = AppointmentService.GetPatientPastAppointments();
            Appointments = new ObservableCollection<Appointment>(appointments);
            currentAppointments = Appointments.Count();
        }

        private void BtnZahtev_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationRequest());
        }

        private void BtnOcenaLekara_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GradeDoctorPage());
        }

        private void BtnOcenaBolnice_Click(object sender, RoutedEventArgs e)
        {
            if (currentAppointments % 5 == 0)
            {
                this.NavigationService.Navigate(new GradeHospitalPage(new ViewModel.PatientViewModel.GradeHospitalViewModel(this.NavigationService)));
            }
            else
            {
                var s = new GradePopup();
                s.Show();
            }
        }

        private void BtnStatistika_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Statistics());
        }

        private void BtnMojLekar_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MyDoctor());
        }

        private void BtnPlacanje_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Payment());
        }

        private void BtnIzvestaj_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReportPage());
        }
    }
}
