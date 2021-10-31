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
using System.Windows.Shapes;

namespace vezba.SecretaryGUI
{

    public partial class SecretaryEditAnnouncement : Window
    {
        private Announcement announcement;
        public SecretaryEditAnnouncement(Announcement a)
        {
            InitializeComponent();
            announcement = a;
            RecipientLabel.Visibility = System.Windows.Visibility.Collapsed;
            RecipientTitleLabel.Visibility = System.Windows.Visibility.Collapsed;
            switch (a.Visibility)
            {
                case Model.Visibility.all:
                    VisibilityLabel.Content = "Svi";
                    break;
                case Model.Visibility.doctors:
                    VisibilityLabel.Content = "Lekari";
                    break;
                case Model.Visibility.secretaries:
                    VisibilityLabel.Content = "Sekretari";
                    break;
                case Model.Visibility.menagers:
                    VisibilityLabel.Content = "Upravnici";
                    break;
                case Model.Visibility.staff:
                    VisibilityLabel.Content = "Zaposleni";
                    break;
                case Model.Visibility.patients:
                    VisibilityLabel.Content = "Pacijenti";
                    break;
                case Model.Visibility.individual:
                    VisibilityLabel.Content = "Individualno";
                    RecipientLabel.Visibility = System.Windows.Visibility.Visible;
                    RecipientTitleLabel.Visibility = System.Windows.Visibility.Visible;

                    PatientService patientService = new PatientService();
                    RecipientLabel.Content = patientService.GetPatientByJmbg(a.Recipients[0]).NameAndSurname;

                    break;
            }

            Content.Text = a.Content;
            Title.Text = a.Title;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int id = this.announcement.Id;
            DateTime po = this.announcement.Posted;
            DateTime ed = DateTime.Today;
            String con = Content.Text;
            String tit = Title.Text;
            Model.Visibility vis = this.announcement.Visibility;
            Announcement editedAnnouncement = new Announcement(id, po, ed, tit, con, vis);
            if (vis == Model.Visibility.individual)
                editedAnnouncement.AddRecipient(this.announcement.Recipients[0]);

            AnnouncementService announcementService = new AnnouncementService();
            announcementService.EditAnnouncement(editedAnnouncement);
            SecretaryMessage m1 = new SecretaryMessage("Obaveštenje je uspešno izmenjeno.");
            m1.ShowDialog();

            var previousAnnouncement = SecretaryAnnouncements.Announcements.FirstOrDefault(a => a.Id == id);
            if (previousAnnouncement != null)
                SecretaryAnnouncements.Announcements[SecretaryAnnouncements.Announcements.IndexOf(previousAnnouncement)] = editedAnnouncement;

            this.Close();
        }
        private void WindowKeyListener(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
            else if (e.Key == Key.Enter)
                this.SaveButton_Click(sender, e);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            return;
        }
    }
}
