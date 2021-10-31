using System.Windows;
using System.Windows.Controls;
using Model;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for ViewMedicinePage.xaml
    /// </summary>
    public partial class ViewMedicinePage : Page
    {

        private readonly DoctorView _doctorView;

        public Medicine Medicine { get; set; }

        private readonly MedicinePageView _medicinePageView;

        public ViewMedicinePage(Medicine medicine, DoctorView doctorView, MedicinePageView medicinePageView)
        {
            InitializeComponent();
            DataContext = medicine;
            _doctorView = doctorView;
            _medicinePageView = medicinePageView;
            Medicine = medicine;
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.Content = new EditMedicinePage(Medicine, _doctorView, _medicinePageView);
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }
    }
}
