using Model;
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
using System.Windows.Shapes;

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryDeleteConfirmation.xaml
    /// </summary>
    public partial class SecretaryDeleteConfirmation : Window
    {
        private int mode = -1;
        public Boolean isConfirmed = false;
        public SecretaryDeleteConfirmation()
        {
            InitializeComponent();
            TextBlock.Text = "Da li ste sigurni da zelite da obrisete objekat?";
        }
        public SecretaryDeleteConfirmation(Announcement announcement)
        {
            InitializeComponent();
            TextBlock.Text = "Da li ste sigurni da zelite da obrisete obaveštenje \"" + announcement.Title + "\"?";
        }

        public SecretaryDeleteConfirmation(Appointment appointment)
        {
            InitializeComponent();
            TextBlock.Text = "Da li ste sigurni da zelite da obrisete termin?";
        }

        public SecretaryDeleteConfirmation(Patient patient)
        {
            InitializeComponent();
            TextBlock.Text = "Da li ste sigurni da zelite da obrisete pacijenta " + patient.NameAndSurname + "?";
        }
        public SecretaryDeleteConfirmation(Ingridient allergen)
        {
            InitializeComponent();
            TextBlock.Text = "Da li ste sigurni da zelite da uklonite alergen " + allergen.Name + "?";
        }
        public SecretaryDeleteConfirmation(Doctor doctor, VacationDays vd)
        {
            InitializeComponent();
            TextBlock.Text = "Da li ste sigurni da zelite da uklonite godisnji odmor lekaru " + doctor.NameAndSurname + " za period od " + vd.FormatedStartDate + " do " + vd.FormatedEndDate + "?";
        }
        public SecretaryDeleteConfirmation(Doctor doctor, WorkingHours wh)
        {
            InitializeComponent();
            TextBlock.Text = "Da li ste sigurni da zelite da uklonite odmor lekaru " + doctor.NameAndSurname + " za period od " + wh.FormatedBeginnigDate + " do " + wh.FormatedEndDate + "?";
        }

        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }
        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            isConfirmed = true;
            this.Close();
        }

        private void CancelButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}