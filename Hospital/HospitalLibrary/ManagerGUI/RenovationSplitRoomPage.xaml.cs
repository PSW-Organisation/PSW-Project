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
    public partial class RenovationSplitRoomPage : Page, INotifyPropertyChanged
    {
        private MainManagerWindow mainManagerWindow;
        private DateTime infiniteTime = new DateTime(2999, 12, 31);
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
        public RenovationSplitRoomPage(MainManagerWindow mainManagerWindow, Room selected)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            this.selected = selected;
            List<string> type = new List<string> { "Soba za preglede", "Soba za odmor", "Operaciona sala", "Magacin" };
            Combo1.ItemsSource = type;
            Combo2.ItemsSource = type;
            DatePicker.SelectedDate = DateTime.Now;
            BrojProstorije.Text = BrojProstorije.Text + " " + selected.RoomNumber;
        }
        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        { 
            readInformation();

            if (!ValidateEntries()) return;

            RoomType type1 = RoomType.examinationRoom;

            if (Combo1.SelectedIndex == 0) type1 = RoomType.examinationRoom;
            else if (Combo1.SelectedIndex == 1) type1 = RoomType.recoveryRoom;
            else if (Combo1.SelectedIndex == 2) type1 = RoomType.operatingRoom;
            else if (Combo1.SelectedIndex == 3) type1 = RoomType.storageRoom;

            RoomType type2 = RoomType.examinationRoom;

            if (Combo2.SelectedIndex == 0) type2 = RoomType.examinationRoom;
            else if (Combo2.SelectedIndex == 1) type2 = RoomType.recoveryRoom;
            else if (Combo2.SelectedIndex == 2) type2 = RoomType.operatingRoom;
            else if (Combo2.SelectedIndex == 3) type2 = RoomType.storageRoom;

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

            RoomService roomService = new RoomService();
            var newRoom1 = new Room(endTime, 0, floor, type1);
            var newRoom2 = new Room(endTime, 0, floor, type2);
            var newRenovation = new Renovation(startTime, durationInDays, renovationId);
            selected.AddRenovation(newRenovation);
            selected.EndDateTime = endTime;
            roomService.UpdateRoom(selected);
            RenovationsPage.RenovationList.Add(newRenovation);
            roomService.SaveRoom(newRoom1);
            roomService.SaveRoom(newRoom2);

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
            if (DurationTB.Text == "" || Combo1.SelectedIndex==-1 || Combo2.SelectedIndex==-1)
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DurationTB.Text == "" || Combo1.SelectedIndex == -1 || Combo2.SelectedIndex == -1)
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private void Combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DurationTB.Text == "" || Combo1.SelectedIndex == -1 || Combo2.SelectedIndex == -1)
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        public Boolean ValidateEntries()
        {
            DurationTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(DurationTB))
            {
                return false;
            }
            return true;
        }
    }
}
