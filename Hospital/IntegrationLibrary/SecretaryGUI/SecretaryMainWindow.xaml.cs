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
using System.Windows.Shapes;

namespace vezba.SecretaryGUI
{
    /// <summary>
    /// Interaction logic for SecretaryMainWindow.xaml
    /// </summary>
    public partial class SecretaryMainWindow : Window
    {
        public SolidColorBrush selectedTabColor;
        public Button selectedButton;
        public SecretaryMainWindow()
        {
            //#655A71  (101, 90, 113)
            InitializeComponent();
            var app = (App)Application.Current;
            if (app.theme.Equals("dark"))
            {
                selectedTabColor = new SolidColorBrush(Color.FromRgb(101, 90, 113));
            }
            else
            {
                selectedTabColor = new SolidColorBrush(Color.FromRgb(206, 208, 253));
            }
            WindowContent.Content = new SecretaryPatients();
            PatientsButton.Background = selectedTabColor;//Brushes.SlateBlue;
            selectedButton = PatientsButton;
        }

        private void PatientsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = new SecretaryPatients();
            ResetButtonColors();
            PatientsButton.Background = selectedTabColor;
            selectedButton = PatientsButton;
        }

        private void AppointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = new SecretaryAppointments();
            ResetButtonColors();
            AppointmentsButton.Background = selectedTabColor;
            selectedButton = AppointmentsButton;
        }

        private void DoctorsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = new SecretaryDoctors();
            ResetButtonColors();
            DoctorsButton.Background = selectedTabColor;

            selectedButton = DoctorsButton;
        }

        private void RoomsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = new SecretaryRooms();
            ResetButtonColors();
            RoomsButton.Background = selectedTabColor;

            selectedButton = RoomsButton;
        }

        private void AnnouncementsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = new SecretaryAnnouncements();
            ResetButtonColors();
            AnnouncementsButton.Background = selectedTabColor;
            selectedButton = AnnouncementsButton;
        }

        private void ResetButtonColors()
        {
            PatientsButton.Background = Brushes.Transparent;
            AppointmentsButton.Background = Brushes.Transparent;
            DoctorsButton.Background = Brushes.Transparent;
            RoomsButton.Background = Brushes.Transparent;
            AnnouncementsButton.Background = Brushes.Transparent;
            SettingsButton.Background = Brushes.Transparent;
            NotificationButton.Background = Brushes.Transparent;
        }

        private void NotificationButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContent.Content = new SecretaryNotifications();
            ResetButtonColors();
            NotificationButton.Background = selectedTabColor;

            selectedButton = NotificationButton;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryPersonalisation w = new SecretaryPersonalisation(this);
            w.ShowDialog();
        }
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryHelp w = new SecretaryHelp();
            w.ShowDialog();
        }
        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryFeedback w = new SecretaryFeedback();
            w.ShowDialog();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                this.PatientsButton_Click(sender, e);
            else if (e.Key == Key.F2)
                this.AppointmentsButton_Click(sender, e);
            else if (e.Key == Key.F3)
                this.DoctorsButton_Click(sender, e);
            else if (e.Key == Key.F4)
                this.RoomsButton_Click(sender, e);
            else if (e.Key == Key.F5)
                this.AnnouncementsButton_Click(sender, e);
            else if (e.Key == Key.F6)
                this.NotificationButton_Click(sender, e);
            else if (e.Key == Key.F7)
                this.SettingsButton_Click(sender, e);
            else if (e.Key == Key.F8)
                this.HelpButton_Click(sender, e);
            else if (e.Key == Key.F9)
                this.FeedbackButton_Click(sender, e);

        }
    }
}
