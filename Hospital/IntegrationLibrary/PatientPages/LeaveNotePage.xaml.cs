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

namespace vezba.PatientPages
{
    public partial class LeaveNotePage : Page
    {
        public Appointment Appointment { get; set; }
        public AppointmentService Service { get; set; }
        public LeaveNotePage(Appointment appointment, String str)
        {
            InitializeComponent();
            Service = new AppointmentService();
            Appointment = appointment;
            beleska.Text = str;
        }

        private void ButtonLeaveNote_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note((DateTime)start.SelectedDate, (DateTime)end.SelectedDate, DateTime.ParseExact(time.Text, "HH:mm", CultureInfo.InvariantCulture), beleska.Text);
            Appointment.Note = note;
            Appointment.Note.NoteContent = beleska.Text;
            Service.EditAppointment(Appointment);
            PatientNotification noti = new PatientNotification("Vaša beleška za dati pregled je ostavljena.");
            noti.ShowDialog();
            this.NavigationService.Navigate(new AppointmentHistoryPage());
        }

        private void beleska_GotFocus(object sender, RoutedEventArgs e)
        {
            VirtualKeyboard keyboard = new VirtualKeyboard(beleska);
            keyboard.Show();
        }
    }
}
