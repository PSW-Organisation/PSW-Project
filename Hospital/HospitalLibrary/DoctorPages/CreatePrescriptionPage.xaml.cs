using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreatePrescriptionPage.xaml
    /// </summary>
    public partial class CreatePrescriptionPage : Page, INotifyPropertyChanged
    {
        private readonly Patient _patient;
        private readonly DoctorView _doctorView;
        public List<Medicine> ValidMedicine { get; set; }

        private readonly MedicalRecordPage _medicalRecordPage;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _duration;
        public String Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }

        private String _number;
        public String Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value != _number)
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        public CreatePrescriptionPage(Patient patient, DoctorView doctorView, MedicalRecordPage medicalRecordPage)
        {
            InitializeComponent();
            _patient = patient;
            _doctorView = doctorView;
            DataContext = this;
            var validMedicineGenerator = new ValidMedicineGenerator(new MedicineFileRepository());
            ValidMedicine = validMedicineGenerator.GenerateValidMedicineForPatient(_patient.MedicalRecord);
            _medicalRecordPage = medicalRecordPage;
            DpStartDate.SelectedDate = DateTime.Now.Date;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if(!ValidateEntries())
                return;
            var newPrescription = NewPrescription();

            var patientService = new PatientService();
            patientService.AddPrescriptionToPatient(_patient, newPrescription);
            _medicalRecordPage.PrescriptionListView.Items.Refresh();

            _doctorView.Main.GoBack();
        }
        private Prescription NewPrescription()
        {
            var startDate = (DateTime) DpStartDate.SelectedDate;
            var durationInDays = int.Parse(Duration);
            var referencePeriod = (CmbPeriod.SelectedIndex == 0) ? Period.daily : Period.weekly;
            var number = int.Parse(Number);
            var selectedMedicine = (Medicine) CmbMedicine.SelectedItem;
            return new Prescription(startDate, durationInDays, referencePeriod, number, 0, true, selectedMedicine);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private Boolean ValidateEntries()
        {
            Boolean ret = true;
            TbDuration.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(TbDuration))
                ret = false;
            TbNumber.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(TbNumber))
                ret = false;
            return ret;
        }
    }
}
