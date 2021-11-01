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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using Service;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for ExtendHospitalTreatment.xaml
    /// </summary>
    public partial class ExtendHospitalTreatment : Page, INotifyPropertyChanged
    {
        public HospitalTreatment HospitalTreatment { get; set; }
        private readonly DoctorView _doctorView;
        private readonly Patient _patient;
        private readonly MedicalRecordPage _medicalRecordPage;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _duration;
        public String Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }

        public List<Room> Rooms { get; set; }
        public ExtendHospitalTreatment(Patient patient, HospitalTreatment hospitalTreatment, DoctorView doctorView, MedicalRecordPage medicalRecordPage)
        {
            InitializeComponent();
            HospitalTreatment = hospitalTreatment;
            _doctorView = doctorView;
            _patient = patient;
            _medicalRecordPage = medicalRecordPage;
            DataContext = HospitalTreatment;
            DpStartDate.SelectedDate = HospitalTreatment.StartDate;
            Duration = HospitalTreatment.DurationInDays.ToString();
            var roomService = new RoomService();
            Rooms = roomService.GetAllRooms();
            if (HospitalTreatment.Room != null)
                CmbRooms.SelectedValue = HospitalTreatment.Room.RoomNumber;
            DataContext = this;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateEntries())
                return;
            HospitalTreatment.DurationInDays = int.Parse(TbDuration.Text);
            PatientService patientService = new PatientService();
            patientService.EditPatient(_patient);
            _medicalRecordPage.HospitalTreatmentListView.Items.Refresh();
            _doctorView.Main.GoBack();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private Boolean ValidateEntries()
        {
            TbDuration.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(TbDuration))
                return false;
            return true;
        }
    }
}
