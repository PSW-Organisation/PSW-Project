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
    public partial class SecretaryAnnouncements : Page
    {
        public static ObservableCollection<Announcement> Announcements { get; set; }
        public SecretaryAnnouncements()
        {
            InitializeComponent();
            this.DataContext = this;
            AnnouncementService announcementService = new AnnouncementService();
            List<Announcement> temp = announcementService.GetAllAnnouncements();
            Announcements = new ObservableCollection<Announcement>(temp);
        }

        private void NewAnnouncementButton_Click(object sender, RoutedEventArgs e)
        {
            SecretaryNewAnnouncement w = new SecretaryNewAnnouncement();
            w.ShowDialog();
        }
        private void ViewAnnouncementButton_Click(object sender, RoutedEventArgs e)
        {
            if (announcementTable.SelectedCells.Count > 0)
            {
                Announcement announcement = (Announcement)announcementTable.SelectedItem;
                SecretaryViewAnnouncement w = new SecretaryViewAnnouncement(announcement);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m = new SecretaryMessage("Niste selektovali obaveštenje.");
            m.ShowDialog();
        }

        private void EditAnnouncementButton_Click(object sender, RoutedEventArgs e)
        {
            if (announcementTable.SelectedCells.Count > 0)
            {
                Announcement announcement = (Announcement)announcementTable.SelectedItem;
                SecretaryEditAnnouncement w = new SecretaryEditAnnouncement(announcement);
                w.ShowDialog();
                return;
            }
            SecretaryMessage m = new SecretaryMessage("Niste selektovali obaveštenje.");
            m.ShowDialog();
        }

        private void DeleteAnnouncementButton_Click(object sender, RoutedEventArgs e)
        {
            if (announcementTable.SelectedCells.Count > 0)
            {
                Announcement selecetedAnnouncement = (Announcement)announcementTable.SelectedItem;
                SecretaryDeleteConfirmation dc = new SecretaryDeleteConfirmation(selecetedAnnouncement);
                Boolean ic = false;
                dc.ShowDialog();
                ic = dc.isConfirmed;
                if (!ic)
                    return;
                AnnouncementService announcementService = new AnnouncementService();
                announcementService.DeleteAnnouncement(selecetedAnnouncement.Id);
                Announcements.Remove(selecetedAnnouncement);
                SecretaryMessage m1 = new SecretaryMessage("Obaveštenje je obrisano.");
                m1.ShowDialog();
                return;

            }
            SecretaryMessage m = new SecretaryMessage("Niste selektovali obaveštenje.");
            m.ShowDialog();
        }
        private void OnKeyDownDataGridHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
                this.ViewAnnouncementButton_Click(sender, e);
            else if (e.Key == Key.N)
                this.NewAnnouncementButton_Click(sender, e);
            else if (e.Key == Key.E)
                this.EditAnnouncementButton_Click(sender, e);
            else if (e.Key == Key.D)
                this.DeleteAnnouncementButton_Click(sender, e);
        }

    }
}
