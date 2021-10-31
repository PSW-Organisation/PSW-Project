using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;

namespace vezba.ManagerGUI
{
    public partial class RenovationMergeRoomsPage : Page, INotifyPropertyChanged
    {
        private MainManagerWindow mainManagerWindow;
        public List<Room> roomList { get; set; }
        private Room selected;
        private DateTime startTime;
        private DateTime endTime;
        private int durationInDays;
        private int renovationId;
        private int roomNumber;
        private Floor floor;
        public event PropertyChangedEventHandler PropertyChanged;

        private int renovationDuration;
        public int RenovationDuration
        {
            get
            {
                return renovationDuration;
            }
            set
            {
                if (value != renovationDuration)
                {
                    renovationDuration = value;
                    OnPropertyChanged("RenovationDuration");
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
        public RenovationMergeRoomsPage(MainManagerWindow mainManagerWindow, Room selected)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            this.selected = selected;

            RoomService roomService = new RoomService();
            var roomListTemporary = roomService.GetAllRooms();
            roomList = new List<Room>();
            foreach (Room room in roomListTemporary)
            {
                if(room != null)
                if (room.RoomFloor == selected.RoomFloor && room.RoomNumber != selected.RoomNumber) {
                    roomList.Add(room);
                }
            }
            RoomToMerge.ItemsSource = roomList;
            BrojProstorije.Text = BrojProstorije.Text + " " + selected.RoomNumber;
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            readInformation();


            AppointmentService appointmentService = new AppointmentService();

            if (DateTime.Compare(startTime, DateTime.Now) < 0)
            {
                MessageBox.Show("Izabrani datum je već prošao!");
                return;
            }

            if (appointmentService.Overlap(roomNumber, startTime, endTime) || appointmentService.HasFutureAppointments(roomNumber, startTime, endTime))
            {
                return;
            }

            Room roomToMerge = (Room)RoomToMerge.SelectedItem;
            var newRenovation = new Renovation(startTime, durationInDays, renovationId);
            roomToMerge.AddRenovation(newRenovation);
            selected.AddRenovation(newRenovation);
            roomToMerge.EndDateTime = endTime;
            RoomService roomService = new RoomService();
            roomService.UpdateRoom(roomToMerge);
            roomService.UpdateRoom(selected);
            RenovationsPage.RenovationList.Add(newRenovation);

            NavigationService.GoBack();
        }

        private void readInformation()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var startDate = DatePicker.SelectedDate;
            startTime = new DateTime(startDate.Value.Year, startDate.Value.Month, startDate.Value.Day, 0, 0, 0);
            durationInDays = int.Parse(DurationTB.Text);
            endTime = startTime.AddDays(durationInDays);
            renovationId = selected.renovation.Count + 1;
            roomNumber = selected.RoomNumber;
            floor = selected.RoomFloor;
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

        private void Trajanje_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DurationTB.Text == "" || RoomToMerge.SelectedIndex == -1)
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private void RoomToMerge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DurationTB.Text == "" ||  RoomToMerge.SelectedIndex == -1)
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

    }
}
