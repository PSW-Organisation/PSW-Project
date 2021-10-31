using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using vezba.Repository;

namespace vezba.PatientPages
{
    public partial class EditAppointmentPage : Page
    {
        private Appointment Appointment { get; set; }
        private EventsLogService LogService { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public EditAppointmentPage(Appointment appointment)
        {
            InitializeComponent();
            ShowAppointmentDetails(appointment);
            AppointmentService = new AppointmentService();
            Appointment = appointment;
        }

        private void ShowAppointmentDetails(Appointment appointment)
        {
            ID.Text = appointment.AppointentId.ToString();
            Datum.Text = appointment.StartTime.ToString("dd.MM.yyyy.");
            Opis.Text = appointment.ApointmentDescription;
            Vreme.Text = appointment.StartTime.ToString("HH:mm");
            Trajanje.Text = appointment.DurationInMunutes.ToString();
            Lekar.Text = appointment.Doctor.ToString();
            if (appointment.Room == null)
            {
                Soba.Text = "100";
            }
            else
            {
                Soba.Text = appointment.Room.RoomNumber.ToString();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DateTime initDate = Appointment.StartTime.Date;
            DateTime pickedDate = Datum.SelectedDate.Value.Date;
            String pickedTime = Vreme.Text;
            if (AppointmentService.MoveableAppointment(initDate, pickedDate))
            {
                LogService = new EventsLogService();
                AppointmentService.ChangeAppointment(Appointment, pickedDate, pickedTime);
                LogService.AddLog();
            }
            else
            {
                PatientNotification noti = new PatientNotification("Pregled možete pomeriti za maksimalno dva dana.");
                noti.ShowDialog();
            }
        }
    }
}
