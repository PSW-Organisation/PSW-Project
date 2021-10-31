using Model;
using System.Windows;
using System.Windows.Controls;

namespace vezba.ManagerGUI
{
    public partial class MainManagerPage : Page
    {
        private MainManagerWindow mainManagerWindow;
        public MainManagerPage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            this.mainManagerWindow = mainManagerWindow;
        }

        private void ButtonAnnouncementsClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new Announcements(mainManagerWindow, UserType.menager);
        }

        private void ButtonMedicineClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MedicinePage(mainManagerWindow);
        }

        private void ButtonInventoryClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new InventoryPage(mainManagerWindow);
        }

        private void ButtonRoomsClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new RoomsPage(mainManagerWindow);
        }

        private void ButtonStaffClick(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonSupplyClick(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonSurveyClick(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new UserProfilePage(mainManagerWindow);
        }
    }
}