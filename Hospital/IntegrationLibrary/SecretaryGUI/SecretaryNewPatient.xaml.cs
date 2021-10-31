using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using vezba.Repository;

namespace vezba.SecretaryGUI
{
    public partial class SecretaryNewPatient : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string dateInput;
        public string DateInput
        {
            get { return dateInput; }
            set
            {
                if (value != dateInput)
                {
                    dateInput = value;
                    OnPropertyChanged("DateInput");
                }
            }
        }

        private string jmbgInput;
        public string JmbgInput
        {
            get { return jmbgInput; }
            set
            {
                if (value != jmbgInput)
                {
                    jmbgInput = value;
                    OnPropertyChanged("JmbgInput");
                }
            }
        }

        private string emailInput;
        public string EmailInput
        {
            get { return emailInput; }
            set
            {
                if (value != emailInput)
                {
                    emailInput = value;
                    OnPropertyChanged("EmailInput");
                }
            }
        }
        private string phoneInput;
        public string PhoneInput
        {
            get { return phoneInput; }
            set
            {
                if (value != phoneInput)
                {
                    phoneInput = value;
                    OnPropertyChanged("PhoneInput");
                }
            }
        }

        private string idInput;
        public string IdInput
        {
            get { return idInput; }
            set
            {
                if (value != idInput)
                {
                    idInput = value;
                    OnPropertyChanged("IdInput");
                }
            }
        }



        private string addressInput;
        public string AddressInput
        {
            get { return addressInput; }
            set
            {
                if (value != addressInput)
                {
                    addressInput = value;
                    OnPropertyChanged("AddressInput");
                }
            }
        }

        private string usernameInput;
        public string UsernameInput
        {
            get { return usernameInput; }
            set
            {
                if (value != usernameInput)
                {
                    usernameInput = value;
                    OnPropertyChanged("UsernameInput");
                }
            }
        }

        private string surnameInput;
        public string SurnameInput
        {
            get { return surnameInput; }
            set
            {
                if (value != surnameInput)
                {
                    surnameInput = value;
                    OnPropertyChanged("SurnameInput");
                }
            }
        }

        private string nameInput;
        public string NameInput
        {
            get { return nameInput; }
            set
            {
                if (value != nameInput)
                {
                    nameInput = value;
                    OnPropertyChanged("NameInput");
                }
            }
        }

        private string passwordInput;
        public string PasswordInput
        {
            get { return passwordInput; }
            set
            {
                if (value != passwordInput)
                {
                    passwordInput = value;
                    OnPropertyChanged("PasswordInput");
                }
            }
        }


        public static ObservableCollection<Ingridient> Allergens { get; set; }
        public SecretaryNewPatient()
        {
            InitializeComponent();
            Allergens = new ObservableCollection<Ingridient>();
            this.DataContext = this;
            List<string> sexes = new List<string>();
            sexes.Add("Muško");
            sexes.Add("Žensko");
            Sex.ItemsSource = sexes;
            Sex.SelectedIndex = 0;
        }

        private void NewAlergenButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryNewAllergen s = new SecretaryNewAllergen(0);
            s.Show();
        }

        private void DeleteAllergenButton_Click(object sender, RoutedEventArgs e)
        {
            if (allergensTable.SelectedCells.Count > 0)
            {
                Ingridient a = (Ingridient)allergensTable.SelectedItem;
                SecretaryDeleteConfirmation dc = new SecretaryDeleteConfirmation(a);
                Boolean ic = false;
                dc.ShowDialog();
                ic = dc.isConfirmed;
                if (!ic)
                    return;
                Allergens.Remove(a);
            }
            else
            {
                SecretaryMessage m1 = new SecretaryMessage("Niste selektovali alergen.");
                m1.ShowDialog();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Boolean isGuest = Convert.ToBoolean(IsGuest.IsChecked);
            if (isGuest == false && (((Name.Text).Trim().Equals("")) || ((Surname.Text).Trim().Equals("")) || ((Jmbg.Text).Trim().Equals("")) || ((PhoneNumber.Text).Trim().Equals("")) || ((Adress.Text).Trim().Equals("")) || ((Email.Text).Trim().Equals("")) || ((Username.Text).Trim().Equals("")) || ((Password.Text).Trim().Equals("")) || ((IdNumber.Text).Trim().Equals(""))))
            {
                SecretaryMessage m3 = new SecretaryMessage("Nalog nije gostujući. Morate popuniti sva polja označena sa *.");
                m3.ShowDialog();
                return;
            }
            else if (isGuest == false && (nameInput == null || surnameInput == null || jmbgInput == null || addressInput == null || dateInput == null || usernameInput == null || passwordInput == null || idInput == null))
            {
                SecretaryMessage m3 = new SecretaryMessage("Nalog nije gostujući. Morate popuniti sva polja označena sa *.");
                m3.ShowDialog();
                return;
            }
            else if (isGuest == true && (jmbgInput == null || (Jmbg.Text).Trim().Equals("")))
            {
                SecretaryMessage m3 = new SecretaryMessage("JMBG pacijenta je obavezno polje.");
                m3.ShowDialog();
                return;
            }

            string mid = MedicalIdNumber.Text;
            string hin = HealthEnsuranceNumber.Text;
            MedicalRecord medRecord = new MedicalRecord(hin, mid);

            foreach (Ingridient allergen in Allergens)
            {
                medRecord.AddAllergen(allergen);
            }

            string name = Name.Text;
            string surname = Surname.Text;
            string jmbg = Jmbg.Text;
            DateTime selectedDate = new DateTime(1900, 1, 1);
            try
            {
                selectedDate = DateTime.ParseExact(DateOfBirth.Text, "dd.MM.yyyy.", null);
            }
            catch { }

            Sex sex = Model.Sex.male;
            if (Sex.SelectedIndex == 1)
            {
                sex = Model.Sex.female;
            }

            string phoneNumber = PhoneNumber.Text;
            string adress = Adress.Text;
            string email = Email.Text;
            string idNum = IdNumber.Text;
            string emContact = EmergencyContact.Text;
            string username = Username.Text;
            string password = Password.Text;

            Patient registeredPatient = new Patient(isGuest, name, surname, jmbg, selectedDate, sex, phoneNumber, adress, email, idNum, emContact, medRecord, username, password);

            PatientService ps = new PatientService();
            Boolean isSuccess = ps.SavePatient(registeredPatient);
            if (isSuccess)
            {
                SecretaryMessage m1 = new SecretaryMessage("Pacijent je uspešno registrovan.");
                m1.ShowDialog();
                SecretaryPatients.Patients.Add(registeredPatient);
                this.Close();
                return;
            }
            SecretaryMessage m2 = new SecretaryMessage("Pacijent sa unetim JMBGom već postoji.");
            m2.ShowDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
                this.NewAlergenButton_Click(sender, e);
            else if (e.Key == Key.D)
                this.DeleteAllergenButton_Click(sender, e);
        }


    }
}