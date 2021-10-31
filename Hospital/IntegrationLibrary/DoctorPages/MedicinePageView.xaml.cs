using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;
using vezba.Repository;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for MedicinePageView.xaml
    /// </summary>
    public partial class MedicinePageView : Page
    {
        public static ObservableCollection<Medicine> MedicineToApprove { get; set; }

        public static ObservableCollection<Medicine> ApprovedMedicine { get; set; }

        public static ObservableCollection<DeclinedMedicine> DeclinedMedicine { get; set; }

        private readonly DoctorView _doctorView;

        public MedicinePageView(DoctorView doctorView)
        {
            InitializeComponent();

            var medicineService = new MedicineService(new MedicineFileRepository());
            var medicineToApprove = medicineService.GetAwaiting();
            MedicineToApprove = new ObservableCollection<Medicine>(medicineToApprove);

            var approvedMedicine = medicineService.GetApproved();
            ApprovedMedicine = new ObservableCollection<Medicine>(approvedMedicine);

            var declinedMedicineService = new DeclinedMedicineService(new DeclinedMedicineFileRepository());
            var declinedMedicine = declinedMedicineService.GetAllDeclinedMedicine();
            DeclinedMedicine = new ObservableCollection<DeclinedMedicine>(declinedMedicine);

            DataContext = this;
            _doctorView = doctorView;
        }

        private void ViewClick(object sender, RoutedEventArgs e)
        {
            var medicine = (sender as Grid).DataContext as Medicine;
            _doctorView.Main.Content = new ViewMedicinePage(medicine, _doctorView, this);
        }

        private void RevisionClick(object sender, RoutedEventArgs e)
        {
            var medicine = (sender as Grid).DataContext as Medicine;
            _doctorView.Main.Content = new MedicineRevisionPage(medicine, _doctorView, this);
        }

        private void ViewDeclinedClick(object sender, RoutedEventArgs e)
        {
            var declinedMedicine = (sender as Grid).DataContext as DeclinedMedicine;
            _doctorView.Main.Content = new ViewDeclinedMedicine(declinedMedicine, _doctorView);
        }

        private void CreateReportClick(object sender, RoutedEventArgs e)
        {
            if (DpStartDate.SelectedDate == null || DpEndDate.SelectedDate == null)
                return;
            var medicineReportPreview = new MedicineReportPreview(DpStartDate.SelectedDate.Value, DpEndDate.SelectedDate.Value, _doctorView);
            medicineReportPreview.Show();
        }
    }
}
