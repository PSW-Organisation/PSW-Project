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

namespace vezba.SecretaryGUI
{
    public partial class SecretaryNotifications : Page
    {
        public ObservableCollection<Announcement> Announcements { get; set; }
        public SecretaryNotifications()
        {
            InitializeComponent();
            this.DataContext = this;
            AnnouncementService s = new AnnouncementService();
            List<Announcement> announcements = s.GetAnnouncementsByUserType(UserType.secretary);
            Announcements = new ObservableCollection<Announcement>(announcements);
        }

        private void ViewAnnouncementButton_Click(object sender, RoutedEventArgs e)
        {
            if (announcementTable.SelectedCells.Count > 0)
            {
                Announcement a = (Announcement)announcementTable.SelectedItem;
                SecretaryViewAnnouncement w = new SecretaryViewAnnouncement(a);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m = new SecretaryMessage("Niste selektovali obaveštenje.");
            m.ShowDialog();
        }
        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                this.ViewAnnouncementButton_Click(sender, e);
        }
    }
}
