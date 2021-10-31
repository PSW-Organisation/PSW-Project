using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;
using vezba.Repository;
using vezba.Service;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for DeclineMedicinePage.xaml
    /// </summary>
    public partial class DeclineMedicinePage : Page, INotifyPropertyChanged
    {
        public Medicine Medicine { get; set; }

        private readonly DoctorView _doctorView;

        private readonly MedicinePageView _medicinePageView;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _description;
        public String Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public DeclineMedicinePage(Medicine medicine, DoctorView doctorView, MedicinePageView medicinePageView)
        {
            InitializeComponent();
            Medicine = medicine;
            DataContext = this;
            _doctorView = doctorView;
            _medicinePageView = medicinePageView;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if(!ValidateEntries())
                return;
            var medicineTransferService = new MedicineTransferService(new MedicineFileRepository(), new DeclinedMedicineFileRepository());

            var description = DescriptionTB.Text;
            var declinedMedicine = medicineTransferService.DeclineMedicine(Medicine, description);

            UpdateMedicineView(declinedMedicine);
            _doctorView.Main.GoBack();
            _doctorView.Main.GoBack();
        }

        private void UpdateMedicineView(DeclinedMedicine declinedMedicine)
        {
            MedicinePageView.MedicineToApprove.Remove(Medicine);
            MedicinePageView.DeclinedMedicine.Add(declinedMedicine);
            _medicinePageView.RevisionListView.Items.Refresh();
            _medicinePageView.DeclinedMedicineListView.Items.Refresh();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private Boolean ValidateEntries()
        {
            DescriptionTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(DescriptionTB))
                return false;
            return true;
        }
    }
}
