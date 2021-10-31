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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vezba.PatientPages
{
    public partial class AppointmentDetails : Page
    {
        private Appointment Appointment { get; set; }
        private AppointmentService AppointmentService { get; set; }
        public AppointmentDetails(Appointment appointment)
        {
            InitializeComponent();
            ShowAppointmentDetails(appointment);
            AppointmentService = new AppointmentService();
            Appointment = appointment;
        }

        private void ShowAppointmentDetails(Appointment appointment)
        {
            ID.Content = appointment.AppointentId.ToString();
            Datum.Content = appointment.StartTime.ToString("dd.MM.yyyy.");
            Opis.Content = appointment.ApointmentDescription;
            Vreme.Content = appointment.StartTime.ToString("HH:mm");
            Trajanje.Content = appointment.DurationInMunutes.ToString();
            Lekar.Content = appointment.Doctor.ToString();
            if (appointment.Room == null)
            {
                Soba.Content = "100";
            }
            else
            {
                Soba.Content = appointment.Room.RoomNumber.ToString();
            }
            Beleska.Content = appointment.Note.NoteContent;
        }

        private void LeaveNote_Click(object sender, RoutedEventArgs e)
        {
            String note = (String)Beleska.Content;
            this.NavigationService.Navigate(new LeaveNotePage(Appointment, note));
        }
    }
}
