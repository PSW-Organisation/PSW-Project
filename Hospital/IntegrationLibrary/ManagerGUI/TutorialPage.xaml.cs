using System.Windows;
using System.Windows.Controls;

namespace vezba.ManagerGUI
{
    public partial class TutorialPage : Page
    {
        private MainManagerWindow mainManagerWindow;
        public TutorialPage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            this.mainManagerWindow = mainManagerWindow;
            PreviousButton.IsEnabled = false;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Video.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            Video.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Video.Stop();
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

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new UserProfilePage(mainManagerWindow);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new TutorialSecondPage(mainManagerWindow);
        }
    }
}
