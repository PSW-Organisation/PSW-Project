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
    /// Interaction logic for EditAppointmentPage.xaml
    /// </summary>
    public partial class EditAppointmentPage : Page, INotifyPropertyChanged
    {
        public Appointment Appointment { get; set; }
        private readonly DoctorView _doctorView;
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Room> Rooms { get; set; }
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

        public EditAppointmentPage(Appointment appointment, DoctorView doctorView, CalendarInterface calendarInterface)
        {
            InitializeComponent();

            var patientService = new PatientService();
            Patients = patientService.GetAllPatients();

            var doctorService = new DoctorService();
            Doctors = doctorService.GetAllDoctors();

            var roomService = new RoomService();
            Rooms = roomService.GetAllRooms();

            Appointment = appointment;
            DataContext = this;
            _doctorView = doctorView;

            if (Appointment.Patient != null && Appointment.Patient.Jmbg != null)
                cmbPatients.SelectedValue = Appointment.Patient.Jmbg;
            if (Appointment.Room != null)
                cmbRooms.SelectedValue = appointment.Room.RoomNumber;
            if (Appointment.Doctor != null && Appointment.Doctor.Jmbg != null)
                cmbDoctors.SelectedValue = Appointment.Doctor.Jmbg;

            this.calendarInterface = calendarInterface;

            StartDatePicker.SelectedDate = appointment.StartTime.Date;
            StartTime = Appointment.StartTime.ToString("t");
            Duration = Appointment.DurationInMunutes.ToString();
            Description = Appointment.ApointmentDescription;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if(!ValidateEntries())
                return;
            var updatedAppointment = UpdatedAppointment();

            var appointmentService = new AppointmentService();
            if (appointmentService.DoctorRescheduleAppointment(updatedAppointment))
            {
                calendarInterface.UpdateAppointment(updatedAppointment);

                _doctorView.Main.GoBack();
                _doctorView.Main.GoBack();
            }
            else
            {
                var newStartTime = appointmentService.FindNextFreeAppointmentStartTime(updatedAppointment);
                StartDatePicker.SelectedDate = newStartTime.Date;
                TimeTB.Text = newStartTime.ToString("t");
            }
        }

        private Appointment UpdatedAppointment()
        {
            var appointmentId = Appointment.AppointentId;
            var startDate = StartDatePicker.SelectedDate;
            var hour = int.Parse(TimeTB.Text.Split(':')[0]);
            var minute = int.Parse(TimeTB.Text.Split(':')[1]);
            var startDateTime = new DateTime(startDate.Value.Year, startDate.Value.Month, startDate.Value.Day, hour, minute, 0);
            var durationInMinutes = int.Parse(DurationTB.Text);
            var appointmentDescription = Description;

            var patient = (Patient) cmbPatients.SelectedItem;
            var room = (Room) cmbRooms.SelectedItem;
            var doctor = (Doctor) cmbDoctors.SelectedItem;
            var isEmergency = (Boolean) IsEmergencyCB.IsChecked;
            var updatedAppointment = new Appointment(appointmentId, patient, doctor, room, startDateTime, durationInMinutes,
                appointmentDescription, null, isEmergency);
            return updatedAppointment;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
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

                while(TimeTB.Text.Length != 0)
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
