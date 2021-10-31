using System.Windows;
using System.Windows.Controls;
using Model;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for ViewAnnouncementPage.xaml
    /// </summary>
    public partial class ViewAnnouncementPage : Page
    {
        private readonly DoctorView _doctorView;

        public ViewAnnouncementPage(Announcement announcement, DoctorView doctorView)
        {
            InitializeComponent();
            _doctorView = doctorView;
            DataContext = announcement;
        }

        private void ReturnClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }
    }
}
