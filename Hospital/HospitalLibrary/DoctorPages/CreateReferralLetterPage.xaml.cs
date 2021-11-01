using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for CreateReferralLetterPage.xaml
    /// </summary>
    public partial class CreateReferralLetterPage : Page, INotifyPropertyChanged
    {
        public List<Doctor> Doctors { get; set; }

        public Patient Patient { get; set; }

        private readonly DoctorView _doctorView;

        private MedicalRecordPage medicalRecordPage;

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
        public CreateReferralLetterPage(Patient patient, DoctorView doctorView, MedicalRecordPage medicalRecordPage)
        {
            InitializeComponent();
            DataContext = this;

            var doctorService = new DoctorService();
            Doctors = doctorService.GetAllDoctors();

            cmbDoctors.DataContext = this;
            cmbDoctors.SelectedIndex = 0;
            Patient = patient;
            
            _doctorView = doctorView;
            this.medicalRecordPage = medicalRecordPage;

            DpStartDate.SelectedDate = DateTime.Now.Date;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        { 
            if(!ValidateEntries())
                return;
            var newReferralLetter = NewReferralLetter();

            var patientService = new PatientService();
            patientService.AddReferralLetterToPatient(Patient, newReferralLetter);
            medicalRecordPage.ReferralLetterListView.Items.Refresh();

            _doctorView.Main.GoBack();
        }

        private ReferralLetter NewReferralLetter()
        {
            var startDate = (DateTime) DpStartDate.SelectedDate;
            var durationPeriodInDays = int.Parse(Duration);
            var doctor = (Doctor) cmbDoctors.SelectedItem;
            var newReferralLetter = new ReferralLetter(startDate, durationPeriodInDays, doctor);
            return newReferralLetter;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private Boolean ValidateEntries()
        {

            TbDuration.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(TbDuration))
                return false;
            return true;
        }
    }
}
