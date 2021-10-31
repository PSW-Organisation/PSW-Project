using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using vezba.PatientPages;
using vezba.Repository;

namespace vezba
{
    public partial class PatientView : Window
    {
        public static Patient Patient { get; set; }
        private PatientService PatientService { get; set; }
        private AppointmentService AppointmentService { get; set; }

        public PatientView()
        {
            InitializeComponent();
            this.DataContext = this;

            AppointmentService = new AppointmentService();
            SetPatientLoggedIn();
            PatientService.AddHardcorePrescriptions();
            PatientMainPage.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            StartThreads();
            PatientMainPage.Navigate(new StartPage());
        }

        private void SetPatientLoggedIn()
        {
            PatientService = new PatientService();
            Patient = PatientService.LoadPatient();
        }

        private void StartThreads()
        {
            Thread therapyNotifications = new Thread(PatientService.MedicineNotification);
            therapyNotifications.Start();
            Thread noteNotifications = new Thread(AppointmentService.NoteNotification);
            noteNotifications.Start();
        }

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            PatientMainPage.Content = new MainPage();
        }

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            var s = new LogoutPopup(this);
            s.Show();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            try { PatientMainPage.NavigationService.GoBack(); }
            catch (Exception ex) { }

        }

        private void Appointments_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PatientMainPage.Navigate(new AppointmentsPage());
        }

        private void Therapies_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PatientMainPage.Navigate(new TherapiesPage());
        }

        private void Events_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PatientMainPage.Navigate(new CalendarPage());
        }

        private void Notifications_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PatientMainPage.Navigate(new NotificationsPage(UserType.patient, Patient.Jmbg));
        }

        private void ButtonMore_Click(object sender, RoutedEventArgs e)
        {
            PatientMainPage.Navigate(new MorePage());
        }

        private void ButtonFeedback_Click(object sender, RoutedEventArgs e)
        {
            PatientMainPage.Navigate(new FeedbackPage());
        }
    }
}
