using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Service;
using vezba.Repository;

namespace vezba.ManagerGUI
{
    public partial class Announcements : Page
    {
        public static ObservableCollection<Announcement> Ans { get; set; }
        private MainManagerWindow mainManagerWindow;
        public Announcements(MainManagerWindow mainManagerWindow, UserType ut)
        {
            InitializeComponent();
            this.DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            AnnouncementService announcementService = new AnnouncementService();
            List<Announcement> announcements = announcementService.GetAnnouncementsByUserType(ut);
            Ans = new ObservableCollection<Announcement>(announcements);
            AnnouncementsList.ItemsSource = Ans;
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
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

        private void ButtonMainClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MainManagerPage(mainManagerWindow);
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AnnouncementsList.SelectedIndex > -1)
            {
                Announcement announcement = (Announcement)AnnouncementsList.SelectedItems[0];
                mainManagerWindow.MainManagerView.Content = new ViewAnnouncementManagerPage(mainManagerWindow, announcement);
            }
            else
            {
                MessageBox.Show("Niste selektovali obavestenje!");
            }
        }
    }
}
