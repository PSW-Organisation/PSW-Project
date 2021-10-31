using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for CreateAnamnesisPage.xaml
    /// </summary>
    public partial class CreateAnamnesisPage : Page, INotifyPropertyChanged
    {
        private readonly Patient _patient;

        private readonly DoctorView _doctorView;

        public event PropertyChangedEventHandler PropertyChanged;

        public Appointment Appointment { get; set; }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _description;
        public String Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public CreateAnamnesisPage(Appointment appointment, DoctorView doctorView)
        {
            InitializeComponent();
            DataContext = this;
            Appointment = appointment;
            _patient = Appointment.Patient;
            _doctorView = doctorView;
            IsEmergencyTB.Text = (Appointment.IsEmergency) ? "Da" : "Ne";
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if(!ValidateEntries())
                return;
            var newAnamnesis = NewAnamnesis();

            var patientService = new PatientService();
            patientService.AddAnamnesisToPatient(_patient, newAnamnesis);

            _doctorView.Main.GoBack();
        }

        private Anamnesis NewAnamnesis()
        {
            var comment = TbComment.Text;
            var patient = PatientNameSurname.Text;
            var doctor = DoctorNameSurname.Text;
            var time = DateTime.Now;
            var newAnamnesis = new Anamnesis(time, comment, patient, doctor);
            return newAnamnesis;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private Boolean ValidateEntries()
        {
            TbComment.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(TbComment))
                return false;
            return true;
        }
    }
}
