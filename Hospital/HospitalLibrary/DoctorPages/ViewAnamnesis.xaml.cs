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
    /// Interaction logic for ViewAnamnesis.xaml
    /// </summary>
    public partial class ViewAnamnesis : Page
    {
        private readonly DoctorView _doctorView;
        private readonly Patient _patient;
        private readonly Anamnesis _anamnesis;
        private readonly MedicalRecordPage _medicalRecordPage;

        public ViewAnamnesis(Anamnesis anamnesis, DoctorView doctorView, Patient patient, MedicalRecordPage medicalRecordPage)
        {
            InitializeComponent();
            _doctorView = doctorView;
            _patient = patient;
            _anamnesis = anamnesis;
            _medicalRecordPage = medicalRecordPage;
            DataContext = _anamnesis;
        }

        private void ReturnButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            var patientService = new PatientService();
            patientService.RemoveAnamnesisFromPatient(_patient, _anamnesis);
            _medicalRecordPage.AnamnesisListView.Items.Refresh();
            _doctorView.Main.GoBack();
        }
    }
}
