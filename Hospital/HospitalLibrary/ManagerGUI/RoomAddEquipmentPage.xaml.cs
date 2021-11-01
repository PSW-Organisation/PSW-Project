using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Service;

namespace vezba.ManagerGUI
{
    public partial class RoomAddEquipmentPage : Page, INotifyPropertyChanged
    {
        private Room selected;
        private MainManagerWindow mainManagerWindow;
        private int equipmentQuantity;
        public event PropertyChangedEventHandler PropertyChanged;

        public int EquipmentQuantity
        {
            get
            {
                return equipmentQuantity;
            }
            set
            {
                if (value != equipmentQuantity)
                {
                    equipmentQuantity = value;
                    OnPropertyChanged("EquipmentQuantity");
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
        public RoomAddEquipmentPage(MainManagerWindow mainManagerWindow, Room selected)
        {
            InitializeComponent();
            DataContext = this;
            this.selected = selected;
            this.mainManagerWindow = mainManagerWindow;
            EquipmentService equipmentService = new EquipmentService();
            List<Equipment> equipmentList = equipmentService.GetAllEquipment();
            comboEquipmentName.ItemsSource = equipmentList;
        }
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if(!ValidateEntries()) return;
            Equipment comboEquipment = (Equipment)comboEquipmentName.SelectedItem;
            var Quantity = int.Parse(QuantityTB.Text);
            var endTime = new DateTime(2999, 1, 1, 0, 0, 0);

            RoomInventoryService roomInventoryService = new RoomInventoryService();
            RoomInventory newRoomInventory = new RoomInventory(DateTime.Now, endTime, Quantity, 0, comboEquipment, selected);
            roomInventoryService.SaveRoomInventory(newRoomInventory);
            RoomUpdatePage.RoomInventoryList.Add(newRoomInventory);
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

        private void QuantityTextChanged(object sender, TextChangedEventArgs e)
        {
            if (QuantityTB.Text == "" || comboEquipmentName.SelectedIndex == -1)
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private void comboEquipmentName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (QuantityTB.Text == "" || comboEquipmentName.SelectedIndex==-1)
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private Boolean ValidateEntries()
        {
            QuantityTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(QuantityTB))
            {
                return false;
            }
            return true;
        }
    }
}
