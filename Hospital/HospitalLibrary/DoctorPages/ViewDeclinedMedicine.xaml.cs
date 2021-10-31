using System.Windows;
using System.Windows.Controls;
using Model;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for ViewDeclinedMedicine.xaml
    /// </summary>
    public partial class ViewDeclinedMedicine : Page
    {
        private readonly DoctorView _doctorView;

        public DeclinedMedicine DeclinedMedicine { get; set; }

        public ViewDeclinedMedicine(DeclinedMedicine declinedMedicine, DoctorView doctorView)
        {
            InitializeComponent();
            DeclinedMedicine = declinedMedicine;
            _doctorView = doctorView;
            DataContext = declinedMedicine;
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }
    }
}
