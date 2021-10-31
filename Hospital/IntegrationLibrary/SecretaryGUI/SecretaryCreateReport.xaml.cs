using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for SecretaryCreateReport.xaml
    /// </summary>
    public partial class SecretaryCreateReport : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string dateInputt;
        public string DateInputt
        {
            get { return dateInputt; }
            set
            {
                if (value != dateInputt)
                {
                    dateInputt = value;
                    OnPropertyChanged("DateInputt");
                }
            }
        }

        private string dateInput;
        public string DateInput
        {
            get { return dateInput; }
            set
            {
                if (value != dateInput)
                {
                    dateInput = value;
                    OnPropertyChanged("DateInput");
                }
            }
        }

        public SecretaryCreateReport()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (To.Text.Trim().Equals("") || From.Text.Trim().Equals(""))
            {
                SecretaryMessage m3 = new SecretaryMessage("Niste popunili sva polja!");
                m3.ShowDialog();
                return;
            }
            DateTime from = new DateTime(1900, 1, 1);
            if (From.Text.Trim() == "")
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste uneli početni datum.");
                m1.ShowDialog();
                return;
            }
            try
            {
                from = DateTime.ParseExact(From.Text, "dd.MM.yyyy.", null);
            }
            catch
            {
            }

            DateTime to = new DateTime(1900, 1, 1);
            if (To.Text.Trim() == "")
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste uneli krajnji datum.");
                m1.ShowDialog();
                return;
            }
            try
            {
                to = DateTime.ParseExact(To.Text, "dd.MM.yyyy.", null);
            }
            catch
            {
            }
            /*if(dateInputt == null || dateInput == null)
            {
                SecretaryMessage m2 = new SecretaryMessage("Niste popunili sva polja.");
                m2.ShowDialog();
                return;
            }*/

            SecretaryReportI2 i2 = new SecretaryReportI2(from, to);
            i2.ShowDialog();

            /*AppointmentService appointmentService = new AppointmentService();
            List<Appointment> appointments = new List<Appointment>();
            appointments = appointmentService.GetAppointmentsWithAllConditions(from, to, null, null, null);
            SecretaryGUI.SecretaryAppointments.Appointments.Clear();
            foreach (Appointment a in appointments)
            {
                SecretaryGUI.SecretaryAppointments.Appointments.Add(a);
            }*/
            this.Close();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
