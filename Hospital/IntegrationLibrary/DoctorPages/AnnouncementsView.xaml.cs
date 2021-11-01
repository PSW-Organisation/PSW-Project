using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for AnnouncementsView.xaml
    /// </summary>
    public partial class AnnouncementsView : Page
    {

        public static ObservableCollection<Announcement> Announcements { get; set; }

        private readonly DoctorView _doctorView;
        public AnnouncementsView(UserType userType, DoctorView doctorView)
        {
            InitializeComponent();
            DataContext = this;
            var announcementService = new AnnouncementService();
            var announcements = announcementService.GetAnnouncementsByUserType(userType);
            Announcements = new ObservableCollection<Announcement>(announcements);
            _doctorView = doctorView;
        }

        private void ViewAnnouncementClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var announcement = (sender as Grid).DataContext as Announcement;
            _doctorView.Main.Content = new ViewAnnouncementPage(announcement, _doctorView);
        }
    }
}
