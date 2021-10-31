using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace vezba.ManagerGUI
{
    public partial class RoomOccupiedPage : Page
    {
        private DateTime startDate;
        private DateTime endDate;
        private Room room;
        private MainManagerWindow mainManagerWindow;
        public RoomOccupiedPage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            DatePicker1.SelectedDate = DateTime.Now;
            DatePicker2.SelectedDate = DateTime.Now;
            RoomService roomService = new RoomService();
            List<Room> rooms = roomService.GetAllRooms();
            ComboRoom.ItemsSource = rooms;
        }

        private void Potvrdi_Button_Click(object sender, RoutedEventArgs e)
        {
            room = (Room)ComboRoom.SelectedItem;
            startDate = (DateTime)DatePicker1.SelectedDate;
            endDate = (DateTime)DatePicker2.SelectedDate;

            if (DateTime.Compare(startDate, endDate) > 0)
                return;

            mainManagerWindow.MainManagerView.Content = new PDFPage(mainManagerWindow, room, startDate, endDate);
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

        private void Odustani_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
