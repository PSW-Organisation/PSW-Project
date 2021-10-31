using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Service;

namespace vezba.ManagerGUI
{
    public partial class RenovationViewPage : Page, INotifyPropertyChanged
    {
        private Room selected;
        private MainManagerWindow mainManagerWindow;
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

        public RenovationViewPage(MainManagerWindow mainManagerWindow, Room selected)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            this.selected = selected;
            BrojProstorije.Text = BrojProstorije.Text + " " + selected.RoomNumber;
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var startDate = DatePicker.SelectedDate;
            var startDateTime = new DateTime(startDate.Value.Year, startDate.Value.Month, startDate.Value.Day, 0, 0, 0);
            var durationInDays = int.Parse(DurationTB.Text);
            var endTime = startDateTime.AddDays(durationInDays);
            var id = selected.renovation.Count + 1;
            var number = selected.RoomNumber;

            AppointmentService appointmentService = new AppointmentService();

            if(!ValidateEntries()) return;

            if (DateTime.Compare(startDateTime, DateTime.Now) < 0)
            {
                MessageBox.Show("Izabrani datum je već prošao!");
                return;
            }

            if (appointmentService.Overlap(number, startDateTime, endTime))
            {
                return;
            }

            var newRenovation = new Renovation(startDateTime, durationInDays, id);
            selected.AddRenovation(newRenovation);
            RoomService roomService = new RoomService();
            roomService.UpdateRoom(this.selected);
            RenovationsPage.RenovationList.Add(newRenovation);
            NavigationService.GoBack();
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

        private void Trajanje_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DurationTB.Text == "")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }
    }
}
