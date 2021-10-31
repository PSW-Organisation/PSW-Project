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
using vezba.Service;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for CreateHospitalTreatment.xaml
    /// </summary>
    public partial class CreateHospitalTreatment : Page, INotifyPropertyChanged
    {
        public List<Room> Rooms { get; set; }
        private readonly Patient _patient;
        private readonly DoctorView _doctorView;
        private MedicalRecordPage medicalRecordPage;

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

        public CreateHospitalTreatment(Patient patient, DoctorView doctorView, MedicalRecordPage medicalRecordPage)
        {
            InitializeComponent();
            _patient = patient;
            _doctorView = doctorView;
            DataContext = this;
            var roomService = new RoomService();
            Rooms = roomService.GetAllRooms();
            CmbRooms.SelectedIndex = 0;
            this.medicalRecordPage = medicalRecordPage;
            DpStartDate.SelectedDate = DateTime.Now.Date;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateEntries())
                return;

            var patientStayRegulator = new PatientStayRegulator();
            if (!patientStayRegulator.TreatPatient(DpStartDate.SelectedDate.Value, int.Parse(TbDuration.Text), (Room)CmbRooms.SelectedItem))
            {
                MessageBox.Show("Soba nema dovoljno slobodnih kreveta u navedenom periodu", "Soba nije u stanju da primi pacijenta");
                return;
            }

            var newHospitalTreatment = NewHospitalTreatment();
            var patientService = new PatientService();
            patientService.AddHospitalTreatmentToPatient(_patient, newHospitalTreatment);
            medicalRecordPage.HospitalTreatmentListView.Items.Refresh();
            _doctorView.Main.GoBack();
        }

        private HospitalTreatment NewHospitalTreatment()
        {
            var startDate = (DateTime) DpStartDate.SelectedDate;
            var durationInDays = int.Parse(Duration);
            var room = (Room) CmbRooms.SelectedItem;
            var newHospitalTreatment = new HospitalTreatment(startDate, durationInDays, room);
            return newHospitalTreatment;
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
