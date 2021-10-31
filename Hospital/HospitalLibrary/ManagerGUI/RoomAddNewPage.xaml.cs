using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;

namespace vezba.ManagerGUI
{
    public partial class RoomAddNewPage : Page, INotifyPropertyChanged
    {
        private MainManagerWindow mainManagerWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        private int roomNumber;
        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }
            set
            {
                if (value != roomNumber)
                {
                    roomNumber = value;
                    OnPropertyChanged("RoomNumber");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public RoomAddNewPage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            List<string> floor = new List<string> { "Prvi", "Drugi", "Treći" };
            comboFloor.ItemsSource = floor;
            List<string> type = new List<string> {"Soba za preglede", "Soba za odmor", "Operaciona sala", "Magacin" };
            comboRoomType.ItemsSource = type;

            if (comboRoomType.SelectedIndex == -1 || comboFloor.SelectedIndex == -1 || RoomNumberTB.Text=="")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Floor floor = Floor.first;
            RoomType type = RoomType.examinationRoom;

            if (!ValidateEntries()) return;

            if (comboFloor.SelectedIndex == 0) floor = Floor.first;
            else if (comboFloor.SelectedIndex == 1) floor = Floor.second;
            else if (comboFloor.SelectedIndex == 2) floor = Floor.third;

            if (comboRoomType.SelectedIndex == 0) type = RoomType.examinationRoom;
            else if (comboRoomType.SelectedIndex == 1) type = RoomType.recoveryRoom;
            else if (comboRoomType.SelectedIndex == 2) type = RoomType.operatingRoom;
            else if (comboRoomType.SelectedIndex == 3) type = RoomType.storageRoom;

            RoomService roomService = new RoomService();
            var newRoomNumber = int.Parse(RoomNumberTB.Text);
            var newRoom = new Room(DateTime.Now, newRoomNumber, floor, type);
            roomService.SaveRoom(newRoom);
            RoomsPage.Rooms.Add(newRoom);
            NavigationService.GoBack();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
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

        private void comboFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboRoomType.SelectedIndex == -1 || comboFloor.SelectedIndex == -1 || RoomNumberTB.Text == "")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private void comboRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboRoomType.SelectedIndex == -1 || comboFloor.SelectedIndex == -1 || RoomNumberTB.Text == "")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private void BrojSobeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboRoomType.SelectedIndex == -1 || comboFloor.SelectedIndex == -1 || RoomNumberTB.Text == "")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private Boolean ValidateEntries()
        {
            RoomNumberTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(RoomNumberTB))
            {
                return false;
            } 
            return true;
        }
    }
}
