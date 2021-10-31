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
using System.Windows.Navigation;
using System.Windows.Shapes;
using vezba.ViewModel.PatientViewModel;

namespace vezba.PatientPages
{
    public partial class DoctorOrTimePage : Page
    {
        public DoctorOrTimePage()
        {
            InitializeComponent();
        }

        private void OrderDoctorAppointment(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OrderDoctorAppointment(new OrderDoctorAppointmentViewModel(this.NavigationService)));
        }

        private void OrderTimeAppointment(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OrderTimeAppointment(new OrderTimeAppointmentViewModel(this.NavigationService)));
        }
    }
}
