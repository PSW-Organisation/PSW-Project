using Model;
using Service;
using System;
using System.Collections.Generic;
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

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryNewVacationDays.xaml
    /// </summary>
    public partial class SecretaryNewVacationDays : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string date1Input;
        public string Date1Input
        {
            get { return date1Input; }
            set
            {
                if (value != date1Input)
                {
                    date1Input = value;
                    OnPropertyChanged("Date1Input");
                }
            }
        }
        private string date2Input;
        public string Date2Input
        {
            get { return date2Input; }
            set
            {
                if (value != date2Input)
                {
                    date2Input = value;
                    OnPropertyChanged("Date2Input");
                }
            }
        }

        public Doctor Doctor { get; }
        public SecretaryNewVacationDays(Doctor doctor)
        {
            InitializeComponent();
            DoctorService doctorService = new DoctorService();
            Doctor = doctorService.GetDoctorByJmbg(doctor.Jmbg);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (To.Text.Trim().Equals("") || From.Text.Trim().Equals(""))
            {
                SecretaryMessage m3 = new SecretaryMessage("Niste popunili sva polja!");
                m3.ShowDialog();
                return;
            }
            DateTime start = new DateTime(1900, 1, 1);
            try
            {
                start = DateTime.ParseExact(From.Text, "dd.MM.yyyy.", null);
            }
            catch
            {

            }
            DateTime end = new DateTime(1900, 1, 1);
            try
            {
                end = DateTime.ParseExact(To.Text, "dd.MM.yyyy.", null);
            }
            catch
            {

            }
            if (start < DateTime.Now)
            {
                SecretaryMessage m3 = new SecretaryMessage("Datum početka je već prošao.");
                m3.ShowDialog();
                return;
            }
            if (end < start)
            {
                SecretaryMessage m3 = new SecretaryMessage("Datum završetka je pre datuma početka.");
                m3.ShowDialog();
                return;
            }
            /*if(date1Input == null || date2Input == null)
            {
                SecretaryMessage m3 = new SecretaryMessage("Niste popunili sva polja!");
                m3.ShowDialog();
                return;
            }*/


            VacationDays newVacationDays = new VacationDays(start, end);
            DoctorService doctorService = new DoctorService();
            Boolean isSuccess = doctorService.AddVacationDaysToDoctor(Doctor.Jmbg, newVacationDays);
            if (isSuccess)
            {
                SecretaryViewDoctor.VacationDays.Add(newVacationDays);
                SecretaryMessage m1 = new SecretaryMessage("Uspešno definisan godišnji odmor.");
                m1.ShowDialog();
                this.Close();
            }

        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

