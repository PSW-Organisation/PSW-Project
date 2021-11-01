using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace vezba.ManagerGUI
{
    public partial class PDFPage : Page
    {

        private MainManagerWindow mainManagerWindow;
        private List<Appointment> appointments;
        public static ObservableCollection<Appointment> Appointments { get; set; }
        private Room selected;
        DateTime startDatePDF;
        DateTime endDatePDF;

        public PDFPage(MainManagerWindow mainManagerWindow, Room selected, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            this.mainManagerWindow = mainManagerWindow;
            this.selected = selected;
            startDatePDF = startDate;
            endDatePDF = endDate;
            var startDateOnly = startDatePDF.Date;
            var endDateOnly = endDatePDF.Date;
            
            AppointmentService appointmentService = new AppointmentService();
            appointments = appointmentService.GetAllAppointments();
            Appointments = new ObservableCollection<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Room != null && appointment!=null)
                {
                    if (appointment.Room.RoomNumber == selected.RoomNumber && DateTime.Compare(appointment.StartTime, startDate)>=0 && DateTime.Compare(appointment.EndTime, endDate)<=0)
                    {
                        Appointments.Add(appointment);
                    }
                }
            }

            AppointmentsBinding.ItemsSource = Appointments;

            Naslov1.Text = Naslov1.Text + " " + selected.RoomNumber;
            Naslov2.Text = Naslov2.Text + " " + startDateOnly.ToString("dd.MM.yyyy") + " do " + endDateOnly.ToString("dd.MM.yyyy");
            Datum.Text = Datum.Text + " " + DateTime.Now.ToString("dd.MM.yyyy");          
        }

        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "invoice");
                }
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
