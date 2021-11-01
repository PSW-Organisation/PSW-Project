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

namespace vezba.ManagerGUI
{
    public partial class MainManagerWindow : Window
    {
        public MainManagerWindow()
        {
            InitializeComponent();
            MainManagerView.Content = new MainManagerPage(this);
        }

        private void ButtonMainClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRoomsClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonInventoryClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMedicineClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
