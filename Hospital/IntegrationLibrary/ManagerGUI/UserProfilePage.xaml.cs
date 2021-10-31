using System.Windows;
using System.Windows.Controls;

namespace vezba.ManagerGUI
{
    public partial class UserProfilePage : Page
    {
        private MainManagerWindow mainManagerWindow;
        public UserProfilePage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            this.mainManagerWindow = mainManagerWindow;
        }

        private void ButtonMainClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MainManagerPage(mainManagerWindow);
        }

        private void ButtonRoomsClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new RoomsPage(mainManagerWindow);
        }

        private void ButtonInventoryClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new InventoryPage(mainManagerWindow);
        }

        private void ButtonMedicineClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MedicinePage(mainManagerWindow);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new TutorialPage(mainManagerWindow);
        }

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {}

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MainManagerPage(mainManagerWindow);
        }

        private void FeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new ManagerFeedback(mainManagerWindow);
        }
    }
}
