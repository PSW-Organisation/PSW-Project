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
    /// Interaction logic for ViewPrescription.xaml
    /// </summary>
    public partial class ViewPrescription : Page
    {
        private readonly DoctorView _doctorView;
        private readonly Patient _patient;
        private  readonly Prescription _prescription;
        private readonly MedicalRecordPage _medicalRecordPage;

        public ViewPrescription(Prescription prescription, DoctorView doctorView, Patient patient, MedicalRecordPage medicalRecordPage)
        {
            InitializeComponent();
            _doctorView = doctorView;
            _patient = patient;
            _prescription = prescription;
            _medicalRecordPage = medicalRecordPage;
            DataContext = _prescription;
        }

        private void ReturnButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var patientService = new PatientService();
            patientService.RemovePrescriptionFromPatient(_patient, _prescription);
            _medicalRecordPage.PrescriptionListView.Items.Refresh();

            _doctorView.Main.GoBack();
        }
    }
}
