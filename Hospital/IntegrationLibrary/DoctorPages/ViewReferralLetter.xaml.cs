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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Service;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for ViewReferralLetter.xaml
    /// </summary>
    public partial class ViewReferralLetter : Page
    {
        private readonly DoctorView _doctorView;
        private readonly MedicalRecordPage _medicalRecordPage;
        private readonly Patient _patient;
        private readonly ReferralLetter _referralLetter;

        public ViewReferralLetter(ReferralLetter referralLetter, DoctorView doctorView, Patient patient, MedicalRecordPage medicalRecordPage)
        {
            InitializeComponent();
            _doctorView = doctorView;
            _referralLetter = referralLetter;
            _patient = patient;
            _medicalRecordPage = medicalRecordPage;
            DataContext = _referralLetter;
        }

        private void ReturnButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var patientService = new PatientService();
            patientService.RemoveReferralLetterFromPatient(_patient, _referralLetter);
            _medicalRecordPage.ReferralLetterListView.Items.Refresh();

            _doctorView.Main.GoBack();
        }
    }
}
