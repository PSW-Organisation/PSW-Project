using Model;
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
    public partial class ActiveTherapies : Page
    {
        public static ObservableCollection<Prescription> Prescriptions { get; set; }
        public ActiveTherapies()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Prescription> prescriptions = new List<Prescription>();
            foreach(Prescription p in PatientView.Patient.MedicalRecord.Prescription)
            {
                if (p.StartDate.Date.AddDays(p.DurationInDays) >= DateTime.Now.Date)
                {
                    prescriptions.Add(p);
                }
            }
            Prescriptions = new ObservableCollection<Prescription>(prescriptions);
        }
    }
}
