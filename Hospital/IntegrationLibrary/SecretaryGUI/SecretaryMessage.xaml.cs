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

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryMessage.xaml
    /// </summary>
    public partial class SecretaryMessage : Window
    {
        public SecretaryMessage(String message)
        {
            InitializeComponent();
            TextBlock.Text = message;
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            if (e.Key == Key.Enter)
                this.Close();
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
