using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
    public partial class CalendarPage : Page
    {
        public ObservableCollection<Appointment> Appointments { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public CalendarPage()
        {
            InitializeComponent();
            this.DataContext = this;
            AppointmentService = new AppointmentService();
            List<Appointment> tempToday = AppointmentService.GetPatientTodayAppointments();
            Appointments = new ObservableCollection<Appointment>(tempToday);           
        }

        private void TodayClick(object sender, RoutedEventArgs e)
        {
            GridCursor.Margin = new Thickness(10 + (135 * 0), 0, 0, 0);
            Appointments.Clear();
            AppointmentService.GetTodaysAppointments(Appointments);
        }

        private void WeekClick(object sender, RoutedEventArgs e)
        {
            GridCursor.Margin = new Thickness(10 + (135 * 1), 0, 0, 0);
            Appointments.Clear();
            AppointmentService.GetThisWeeksAppointments(Appointments);
        }

        private void MonthClick(object sender, RoutedEventArgs e)
        {
            GridCursor.Margin = new Thickness(10 + (135 * 2), 0, 0, 0);
            Appointments.Clear();
            AppointmentService.GetThisMonthsAppointments(Appointments);
        }
    }
}
