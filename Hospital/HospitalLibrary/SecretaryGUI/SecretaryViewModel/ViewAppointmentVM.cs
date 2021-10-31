using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Command;

namespace vezba.SecretaryGUI.SecretaryViewModel
{
    class ViewAppointmentVM
    {

        private SecretaryViewAppointment window;
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public string Room { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public ViewAppointmentVM(Appointment appointment, SecretaryViewAppointment window)
        {
            Patient = appointment.PatientName;
            Doctor = appointment.DoctorName;
            Room = appointment.RoomName;
            Date = appointment.StartTime.ToString("dd.MM.yyyy.");
            Time = appointment.StartTime.ToString("HH:mm");
            Duration = appointment.DurationInMunutes.ToString();
            Description = appointment.ApointmentDescription;

            this.window = window;
            SetCommands();
        }
        public RelayCommand CloseCommand { get; private set; }

        private void CloseViewAppointmentWindow(object parameter)
        {
            window.Close();
        }
        private void SetCommands()
        {
            CloseCommand = new RelayCommand(CloseViewAppointmentWindow);
        }
    }
}
