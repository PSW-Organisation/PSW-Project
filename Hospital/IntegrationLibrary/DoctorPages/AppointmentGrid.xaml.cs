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
using vezba.Adapter;
using vezba.SecretaryGUI;
using vezba.Template;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for AppointmentGrid.xaml
    /// </summary>
    public partial class AppointmentGrid : Page
    {

        public static ObservableCollection<Appointment> Appointments { get; set; }

        private readonly DoctorView _doctorView;
        public AppointmentGrid(DoctorView doctorView)
        {
            InitializeComponent();
            this.DataContext = this;
            AppointmentService s = new AppointmentService();
            Appointments = new ObservableCollection<Appointment>(s.GetAllAppointments());
            _doctorView = doctorView;
        }

        private void NewAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.Content = new CreateAppointment(_doctorView, new GridAdapter(), _doctorView.DoctorUser);
        }


        private void ViewAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (appointmentsTable.SelectedCells.Count > 0)
            {
                Appointment selectedAppointment = (Appointment)appointmentsTable.SelectedItem;
                _doctorView.Main.Content = new ViewAppointmentPage(selectedAppointment, _doctorView, new GridAdapter());
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryAppointmentFilter w = new SecretaryAppointmentFilter();
            w.Show();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Appointments.Clear();
                AppointmentService appointmentService = new AppointmentService();
                List<Appointment> appointments = new List<Appointment>();
                String search = SearchBox.Text;
                if (search.Trim().Equals(""))
                {
                    foreach (Appointment a in appointmentService.GetAllAppointments())
                    {
                        Appointments.Add(a);
                    }
                    return;
                }
                appointments = (new SearchAppointments()).SearchTemplate(search);
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
        }
    }
}
