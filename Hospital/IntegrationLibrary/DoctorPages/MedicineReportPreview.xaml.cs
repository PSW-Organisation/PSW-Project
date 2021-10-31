using Model;
using Service;
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

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for MedicineReportPreview.xaml
    /// </summary>
    public partial class MedicineReportPreview : Window
    {
        public List<MedicineCount> MedicineTotals { get; set; }

        public MedicineReportPreview(DateTime startDate, DateTime endDate, DoctorView doctorView)
        {
            InitializeComponent();
            var doctorUser = doctorView.DoctorUser;
            TbDoctorName.Text = doctorUser.NameAndSurname;
            TbDoctorSpeciality.Text = doctorUser.Speciality.Name;
            TbCreationDate.Text = DateTime.Now.Date.ToString("d");
            TbStartDate.Text = startDate.ToString("d");
            TbEndDate.Text = endDate.ToString("d");
            var patientService = new PatientService();
            MedicineTotals = patientService.GetMedicineCountForSelectedDate(startDate, endDate);
            TbTotal.Text = patientService.GetMedicineCountSum(MedicineTotals).ToString();
            DataContext = this;
        }

        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                IsEnabled = true;
            }
        }
    }
}
