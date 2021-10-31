using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class NotificationsPage : Page
    {
        public static ObservableCollection<Announcement> Announcements { get; set; }
        private AnnouncementService AnnouncementService { get; set; }
        public NotificationsPage(UserType ut, String jmbg)
        {
            InitializeComponent();
            this.DataContext = this;
            AnnouncementService = new AnnouncementService();
            List<Announcement> announcements = AnnouncementService.GetAnnouncementsByUserType(ut);
            announcements.AddRange(AnnouncementService.GetUserIndividualAnnouncements(jmbg));

            Announcements = new ObservableCollection<Announcement>(announcements);
        }

        /*private void ButtonShowNotification_Click(object sender, RoutedEventArgs e)
        {
            if (announcementsTable.SelectedItems.Count > 0)
            {
                Announcement announcement = (Announcement)announcementsTable.SelectedItem;
                this.NavigationService.Navigate(new ShowNotificationPage(announcement));
            }
            else
            {
                PatientNotification noti = new PatientNotification("Niste selektovali obaveštenje!");
                noti.ShowDialog();
            }

        }*/

        private void ShowNotification_Click(object sender, SelectionChangedEventArgs e)
        {
            if (announcementsTable.SelectedItems.Count > 0)
            {
                Announcement announcement = (Announcement)announcementsTable.SelectedItem;
                this.NavigationService.Navigate(new ShowNotificationPage(announcement));
            }
            else
            {
                PatientNotification noti = new PatientNotification("Niste selektovali obaveštenje!");
                noti.ShowDialog();
            }
        }
    }
}
