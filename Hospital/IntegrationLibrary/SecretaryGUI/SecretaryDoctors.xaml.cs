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
    public partial class SecretaryDoctors : Page
    {
        public ObservableCollection<Doctor> Doctors { get; set; }
        public SecretaryDoctors()
        {
            InitializeComponent();
            this.DataContext = this;
            DoctorService doctorService = new DoctorService();
            Doctors = new ObservableCollection<Doctor>(doctorService.GetAllDoctors());
        }

        private void ViewDoctorButton_Click(object sender, RoutedEventArgs e)
        {

            if (doctorsTable.SelectedCells.Count > 0)
            {
                Doctor selectedDoctor = (Doctor)doctorsTable.SelectedItem;
                SecretaryViewDoctor w = new SecretaryViewDoctor(selectedDoctor);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m1 = new SecretaryMessage("Niste selektovali lekara.");
            m1.ShowDialog();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Doctors.Clear();
                DoctorService doctorService = new DoctorService();
                List<Doctor> doctors = new List<Doctor>();
                String input = SearchBox.Text;
                if (input.Trim().Equals(""))
                {
                    foreach (Doctor a in doctorService.GetAllDoctors())
                    {
                        Doctors.Add(a);
                    }
                    return;
                }
                doctors = DoSearch<Doctor>.GetSearchResult(new SearchDoctors(), input);
                //doctors = doctorService.GetSearchResultDoctors(search);
                foreach (Doctor a in doctors)
                {
                    Doctors.Add(a);
                }

            }
        }
        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
                this.ViewDoctorButton_Click(sender, e);
        }
    }
}
