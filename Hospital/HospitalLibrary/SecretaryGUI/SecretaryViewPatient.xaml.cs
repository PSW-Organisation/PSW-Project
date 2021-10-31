using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace vezba.SecretaryGUI
{

    public partial class SecretaryViewPatient : Window
    {
        public ObservableCollection<Ingridient> Allergens { get; set; }
        private Patient Patient { get; }
        public SecretaryViewPatient(Patient selectedPatient)
        {
            InitializeComponent();
            Patient = selectedPatient;
            Allergens = new ObservableCollection<Ingridient>();
            this.DataContext = this;

            if (Patient.IsBlocked == false)
                UnblockButton.Visibility = System.Windows.Visibility.Collapsed;


            NameSurname.Content = Patient.Name + " " + Patient.Surname;
            if (Patient.IsGuest)
                NameSurname.Content += " (gost)";
            if (Patient.IsBlocked)
                NameSurname.Content += " - blokiran";
            Jmbg.Content = Patient.Jmbg;
            DateOfBirth.Content = Patient.DateOfBirth.ToString("dd.MM.yyyy.");

            if (Patient.Sex == Model.Sex.male)
                Sex.Content = "Muški";
            else
                Sex.Content = "Ženski";
            PhoneNumber.Content = Patient.PhoneNumber;
            IdNumber.Content = Patient.IdCard;
            Adress.Content = Patient.Adress;
            Email.Content = Patient.Email;
            EmergencyContact.Content = Patient.EmergencyContact;
            if (Patient.MedicalRecord != null)
            {
                HealthEnsuranceNumber.Content = Patient.MedicalRecord.HealthInsuranceNumber;
                MedicalIdNumber.Content = Patient.MedicalRecord.MedicalIdNumber;
                if (Patient.MedicalRecord.Allergen != null)
                {
                    foreach (Ingridient allergen in Patient.MedicalRecord.Allergen)
                    {
                        Allergens.Add(allergen);
                    }

                }

            }

            Username.Content = Patient.Username;
            Password.Content = Patient.Password;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }

        private void UnblockButton_Click(object sender, RoutedEventArgs e)
        {
            PatientService patientService = new PatientService();
            patientService.UnblockPatient(Patient.Jmbg);
            Patient.IsBlocked = false;
            var previousPatient = SecretaryPatients.Patients.FirstOrDefault(p => p.Jmbg.Equals(Patient.Jmbg));
            if (previousPatient != null)
            {
                SecretaryPatients.Patients[SecretaryPatients.Patients.IndexOf(previousPatient)] = Patient;
            }
            UnblockButton.Visibility = System.Windows.Visibility.Collapsed;
            NameSurname.Content = Patient.Name + " " + Patient.Surname;
            if (Patient.IsGuest)
                NameSurname.Content += " (gost)";
        }

        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.Close();
        }
    }


}
