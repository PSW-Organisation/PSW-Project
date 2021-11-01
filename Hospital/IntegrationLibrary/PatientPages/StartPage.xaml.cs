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
    public partial class StartPage : Page
    {
        public static ObservableCollection<Appointment> Appointments { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public Patient Patient { get; set; }
        public StartPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Patient = PatientView.Patient;
            AppointmentService = new AppointmentService();
            List<Appointment> tempToday = AppointmentService.GetPatientTodayAppointments();
            Appointments = new ObservableCollection<Appointment>(tempToday);
        }
    }
}
