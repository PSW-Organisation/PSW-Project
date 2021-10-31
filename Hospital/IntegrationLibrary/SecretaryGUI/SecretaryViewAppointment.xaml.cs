using Model;
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
using System.Windows.Shapes;
using vezba.SecretaryGUI.SecretaryViewModel;

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryViewAppointment.xaml
    /// </summary>
    public partial class SecretaryViewAppointment : Window
    {
        public SecretaryViewAppointment(Appointment appointment)
        {
            InitializeComponent();
            DataContext = new ViewAppointmentVM(appointment, this);
        }

        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.Close();
        }
    }
}
