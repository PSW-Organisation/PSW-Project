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

namespace vezba
{
    public partial class PatientNotification : Window
    {
        public String NotificationContent { get; set; }
        public PatientNotification(String content)
        {
            InitializeComponent();
            this.DataContext = this;
            NotificationContent = content;
            Topmost = true;
            Focus();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
