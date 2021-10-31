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

namespace vezba.PatientPages
{
    public partial class MyDoctor : Page
    {
        public static ObservableCollection<Doctor> Doctors { get; set; }
        private DoctorService DoctorService { get; set; }
        public MyDoctor()
        {
            InitializeComponent();
            DoctorService = new DoctorService();
            List<Doctor> doctors = DoctorService.GetAllDoctors();
            Doctors = new ObservableCollection<Doctor>(doctors);
            doctorsTable.ItemsSource = Doctors;
        }

        private void ButtonConfirmDoctor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
