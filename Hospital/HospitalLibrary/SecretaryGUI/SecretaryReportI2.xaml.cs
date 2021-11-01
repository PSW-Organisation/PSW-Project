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
using System.Windows.Shapes;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;

namespace vezba.SecretaryGUI
{
    public partial class SecretaryReportI2 : Window
    {
        public ObservableCollection<Appointment> Appointments { get; set; }
        public SecretaryReportI2(DateTime from, DateTime to)
        {
            InitializeComponent();
            ForPeriod.Content = "Za period od " + from.ToString("dd.MM.yyyy.") + " do " + to.ToString("dd.MM.yyyy.");
            Date.Content = DateTime.Now.ToString("dd.MM.yyyy.");
            this.DataContext = this;
            AppointmentService s = new AppointmentService();
            Appointments = new ObservableCollection<Appointment>(s.GetAppointmentsWithAllConditions(from, to.AddDays(1), null, null, null));
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateButton.Visibility = System.Windows.Visibility.Collapsed;
            try
            {
                this.IsEnabled = false;
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == true)
                {
                    pd.PrintVisual(print, "report");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }


        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.GenerateButton_Click(sender, e);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}