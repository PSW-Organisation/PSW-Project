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
using System.Windows.Navigation;
using System.Windows.Shapes;
using vezba.Template;

namespace vezba.SecretaryGUI
{
    public partial class SecretaryPatients : Page
    {
        public static ObservableCollection<Patient> Patients { get; set; }
        public SecretaryPatients()
        {
            InitializeComponent();
            this.DataContext = this;
            PatientService ps = new PatientService();
            Patients = new ObservableCollection<Patient>(ps.GetAllPatients());
        }

        private void NewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryNewPatient w = new SecretaryNewPatient();
            w.ShowDialog();
        }

        private void ViewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (patientsTable.SelectedCells.Count > 0)
            {
                Patient selectedPatient = (Patient)patientsTable.SelectedItem;
                SecretaryViewPatient w = new SecretaryViewPatient(selectedPatient);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m2 = new SecretaryMessage("Niste selektovali pacijenta.");
            m2.ShowDialog();
        }

        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (patientsTable.SelectedCells.Count > 0)
            {
                Patient selectedPatient = (Patient)patientsTable.SelectedItem;
                SecretaryEditPatient w = new SecretaryEditPatient(selectedPatient);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m2 = new SecretaryMessage("Niste selektovali pacijenta.");
            m2.ShowDialog();
        }

        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (patientsTable.SelectedCells.Count > 0)
            {
                Patient selectedPatient = (Patient)patientsTable.SelectedItem;
                SecretaryDeleteConfirmation dc = new SecretaryDeleteConfirmation(selectedPatient);
                Boolean ic = false;
                dc.ShowDialog();
                ic = dc.isConfirmed;
                if (!ic)
                    return;
                PatientService ps = new PatientService();
                ps.DeletePatient(selectedPatient.Jmbg);
                Patients.Remove(selectedPatient);
                SecretaryMessage m1 = new SecretaryMessage("Pacijent je obrisan.");
                m1.ShowDialog();
                return;

            }
            SecretaryMessage m2 = new SecretaryMessage("Niste selektovali pacijenta.");
            m2.ShowDialog();
        }

        private void AllAppointments_Click(object sender, RoutedEventArgs e)
        {
            if (patientsTable.SelectedCells.Count > 0)
            {
                Patient selectedPatient = (Patient)patientsTable.SelectedItem;
                SecretaryPatientAppointments w = new SecretaryPatientAppointments(selectedPatient);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m2 = new SecretaryMessage("Niste selektovali pacijenta.");
            m2.ShowDialog();
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (patientsTable.SelectedCells.Count > 0)
            {
                Patient selectedPatient = (Patient)patientsTable.SelectedItem;
                SecretaryNewAppointment w = new SecretaryNewAppointment(2, selectedPatient);

                w.ShowDialog();
            }
            else
            {
                SecretaryNewAppointment w = new SecretaryNewAppointment(2);
                w.ShowDialog();
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Patients.Clear();
                PatientService patientService = new PatientService();
                List<Patient> patients = new List<Patient>();
                String input = SearchBox.Text;
                if (input.Trim().Equals(""))
                {
                    foreach (Patient p in patientService.GetAllPatients())
                    {
                        Patients.Add(p);
                    }
                    return;
                }
                patients = DoSearch<Patient>.GetSearchResult(new SearchPatients(), input);
                //patients = patientService.GetSearchResultPatients(search);
                foreach (Patient p in patients)
                {
                    Patients.Add(p);
                }
            }
        }

        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                this.ViewPatientButton_Click(sender, e);
            else if (e.Key == Key.N)
                this.NewPatientButton_Click(sender, e);
            else if (e.Key == Key.E)
                this.EditPatientButton_Click(sender, e);
            else if (e.Key == Key.D)
                this.DeletePatientButton_Click(sender, e);
            else if (e.Key == Key.A)
                this.AllAppointments_Click(sender, e);
            else if (e.Key == Key.T)
                this.NewAppointment_Click(sender, e);
        }
    }
}
