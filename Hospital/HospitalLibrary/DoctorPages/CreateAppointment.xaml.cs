using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;
using vezba.Adapter;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Page, INotifyPropertyChanged
    {
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Room> Rooms { get; set; }
        private DoctorView doctorView;
        private CalendarInterface calendarInterface;
        private CancellationTokenSource _tokenSource = null;
        private String oldTime;
        private String oldDuration;
        private String oldDescription;

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

        private String _startTime;

        public String StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (value != _startTime)
                {
                    _startTime = value;
                    OnPropertyChanged("StartTime");
                }
            }
        }

        public CreateAppointment(DoctorView doctorView, CalendarInterface calendarInterface, Doctor doctor)
        {
            InitializeComponent();

            var patientService = new PatientService();
            Patients = patientService.GetAllPatients();

            var doctorService = new DoctorService();
            Doctors = doctorService.GetAllDoctors();

            var roomService = new RoomService();
            Rooms = roomService.GetAllRooms();

            DataContext = this;
            cmbPatients.SelectedIndex = 0;
            cmbRooms.SelectedIndex = 0;
            this.doctorView = doctorView;
            this.calendarInterface = calendarInterface;
            if (doctor != null && doctor.Jmbg != null)
                cmbDoctors.SelectedValue = doctor.Jmbg;
            StartDatePicker.SelectedDate = DateTime.Now.Date;
        }

        public CreateAppointment(DoctorView doctorView, CalendarInterface calendarInterface, DateTime generatedStartTime, Doctor doctor)
        {
            InitializeComponent();

            var patientService = new PatientService();
            Patients = patientService.GetAllPatients();

            var doctorService = new DoctorService();
            Doctors = doctorService.GetAllDoctors();

            var roomService = new RoomService();
            Rooms = roomService.GetAllRooms();

            DataContext = this;
            cmbPatients.SelectedIndex = 0;
            cmbRooms.SelectedIndex = 0;
            this.doctorView = doctorView;
            this.calendarInterface = calendarInterface;
            StartDatePicker.SelectedDate = generatedStartTime.Date;
            StartTime = generatedStartTime.ToString("t");
            if (doctor != null && doctor.Jmbg != null)
                cmbDoctors.SelectedValue = doctor.Jmbg;
            Duration = "60";
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateEntries())
                return;
            var newAppointment = NewAppointment();

            var appointmentService = new AppointmentService();
            if (appointmentService.ScheduleAppointment(newAppointment))
            {
                calendarInterface.AddAppointment(newAppointment);
                doctorView.Main.GoBack();
            }
        }
        private Appointment NewAppointment()
        {
            var startDate = StartDatePicker.SelectedDate;
            var hour = int.Parse(TimeTB.Text.Split(':')[0]);
            var minute = int.Parse(TimeTB.Text.Split(':')[1]);
            var startDateTime = new DateTime(startDate.Value.Year, startDate.Value.Month, startDate.Value.Day, hour, minute, 0);
            var durationInMinutes = int.Parse(Duration);
            var appointmentDescription = Description;
            var patient = (Patient)cmbPatients.SelectedItem;
            var room = (Room)cmbRooms.SelectedItem;
            var doctor = (Doctor)cmbDoctors.SelectedItem;
            var isEmergency = (Boolean)IsEmergencyCB.IsChecked;
            var newAppointment = new Appointment(0, patient, doctor, room, startDateTime, durationInMinutes, appointmentDescription, null, isEmergency);
            return newAppointment;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            doctorView.Main.GoBack();
        }

        private Boolean ValidateEntries()
        {
            Boolean ret = true;
            TimeTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(TimeTB))
                ret = false;
            DurationTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(DurationTB))
                ret = false;
            DescriptionTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(DescriptionTB))
                ret = false;
            return ret;
        }

        internal async Task RunDemo(CancellationToken token)
        {
            while (true)
            {
                IsEmergencyCB.Dispatcher.Invoke(() =>
                {
                    IsEmergencyCB.IsChecked = true;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);
                IsEmergencyCB.Dispatcher.Invoke(() =>
                {
                    IsEmergencyCB.IsChecked = false;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                StartDatePicker.Dispatcher.Invoke(() =>
                {
                    StartDatePicker.IsDropDownOpen = true;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);
                StartDatePicker.Dispatcher.Invoke(() =>
                {
                    StartDatePicker.IsDropDownOpen = false;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                while (TimeTB.Text.Length != 0)
                {
                    TimeTB.Dispatcher.Invoke(() =>
                    {
                        TimeTB.Text = TimeTB.Text.Remove(TimeTB.Text.Length - 1, 1);
                    });
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    await Task.Delay(100);
                }
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                String time = "08:00";
                foreach (var item in time)
                {

                    TimeTB.Dispatcher.Invoke(() =>
                    {
                        TimeTB.Text += item;
                    });
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    await Task.Delay(100);
                }
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                while (DurationTB.Text.Length != 0)
                {
                    DurationTB.Dispatcher.Invoke(() =>
                    {
                        DurationTB.Text = DurationTB.Text.Remove(DurationTB.Text.Length - 1, 1);
                    });
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    await Task.Delay(100);
                }
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                String duration = "45";
                foreach (var item in duration)
                {

                    DurationTB.Dispatcher.Invoke(() =>
                    {
                        DurationTB.Text += item;
                    });
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    await Task.Delay(100);
                }
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                while (DescriptionTB.Text.Length != 0)
                {
                    DescriptionTB.Dispatcher.Invoke(() =>
                    {
                        DescriptionTB.Text = DescriptionTB.Text.Remove(DescriptionTB.Text.Length - 1, 1);
                    });
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    await Task.Delay(100);
                }
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                String description = "Sistematski pregled";
                foreach (var item in description)
                {

                    DescriptionTB.Dispatcher.Invoke(() =>
                    {
                        DescriptionTB.Text += item;
                    });
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested();
                    await Task.Delay(100);
                }
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                cmbPatients.Dispatcher.Invoke(() =>
                {
                    cmbPatients.IsDropDownOpen = true;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);
                cmbPatients.Dispatcher.Invoke(() =>
                {
                    cmbPatients.IsDropDownOpen = false;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                cmbRooms.Dispatcher.Invoke(() =>
                {
                    cmbRooms.IsDropDownOpen = true;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);
                cmbRooms.Dispatcher.Invoke(() =>
                {
                    cmbRooms.IsDropDownOpen = false;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                cmbDoctors.Dispatcher.Invoke(() =>
                {
                    cmbDoctors.IsDropDownOpen = true;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);
                cmbDoctors.Dispatcher.Invoke(() =>
                {
                    cmbDoctors.IsDropDownOpen = false;
                });
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                await Task.Delay(500);

                StartTime = oldTime;
                Duration = oldDuration;
                Description = oldDescription;
            }
        }

        private async void RunDemoClick(object sender, RoutedEventArgs e)
        {
            DemoButton.Visibility = System.Windows.Visibility.Collapsed;
            StopDemoButton.Visibility = System.Windows.Visibility.Visible;
            OkButton.IsEnabled = false;
            TimeTB.IsReadOnly = true;
            DurationTB.IsReadOnly = true;
            DescriptionTB.IsReadOnly = true;
            oldTime = TimeTB.Text;
            oldDescription = DescriptionTB.Text;
            oldDuration = DurationTB.Text;
            var oldChecked = IsEmergencyCB.IsChecked;
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            try
            {
                await RunDemo(token);
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                _tokenSource.Dispose();
            }
            IsEmergencyCB.IsChecked = oldChecked;
            TimeTB.Text = oldTime;
            DescriptionTB.Text = oldDescription;
            DurationTB.Text = oldDuration;
            TimeTB.IsReadOnly = false;
            DurationTB.IsReadOnly = false;
            DescriptionTB.IsReadOnly = false;
            OkButton.IsEnabled = true;
            StartDatePicker.IsDropDownOpen = false;
            cmbDoctors.IsDropDownOpen = false;
            cmbPatients.IsDropDownOpen = false;
            cmbRooms.IsDropDownOpen = false;
        }

        private void CancelDemoClick(object sender, RoutedEventArgs e)
        {
            StopDemoButton.Visibility = System.Windows.Visibility.Collapsed;
            DemoButton.Visibility = System.Windows.Visibility.Visible;
            _tokenSource.Cancel();
        }
    }
}
