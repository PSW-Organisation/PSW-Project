using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Service;

namespace vezba.ManagerGUI
{
    public partial class RenovationsPage : Page
    {
        private Room selected;
        public static ObservableCollection<Renovation> RenovationList { get; set; }
        private MainManagerWindow mainManagerWindow;
        public RenovationsPage(MainManagerWindow mainManagerWindow, Room selected)
        {
            InitializeComponent();
            this.selected = selected;
            this.mainManagerWindow = mainManagerWindow;

            List<Renovation> renovationList = selected.renovation;
            RenovationList = new ObservableCollection<Renovation>(renovationList);
            RenovationsBinding.ItemsSource = RenovationList;
            RenovationTitle.Text = RenovationTitle.Text + " " + this.selected.RoomNumber;
        }

        private void Renovation_Button_Click(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new RenovationViewPage(mainManagerWindow, selected);
        }

        private void Discard_Button_Click(object sender, RoutedEventArgs e)
        {
            if (RenovationsBinding.SelectedIndex > -1)
            {
                Renovation renovation = (Renovation)RenovationsBinding.SelectedItem;
                this.selected.renovation.Remove(renovation);
                RenovationList.Remove(renovation);
                RoomService roomService = new RoomService();
                roomService.UpdateRoom(this.selected);
            }
            else
            {
                MessageBox.Show("Ni jedna rezervacija nije selektovana!");
            }
        }

        private void MergeRoomsButtonClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new RenovationMergeRoomsPage(mainManagerWindow, selected);
        }

        private void SplitRoomButtonClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new RenovationSplitRoomPage(mainManagerWindow, selected);
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
    }
}
