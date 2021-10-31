using System.ComponentModel;
using Model;
using System.Windows;
using System.Windows.Controls;
using Service;
using System;
using vezba.Repository;

namespace vezba.ManagerGUI
{
    public partial class RoomChangeEquipmentPage : Page, INotifyPropertyChanged
    {
        private RoomInventory selected;
        private RoomUpdatePage roomUpdatePage;
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

        public RoomChangeEquipmentPage(MainManagerWindow mainManagerWindow, RoomInventory selected, RoomUpdatePage roomUpdatePage)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            this.selected = selected;
            this.roomUpdatePage = roomUpdatePage;

            EquipmentNameLabel.Content = EquipmentNameLabel.Content + "    " + selected.equipment.Name;
            Id.Content = Id.Content + "    " + selected.equipment.Id;

            if (selected.equipment.Type == EquipmentType.dinamical)
            {
                EquipmentTypeLabel.Content = EquipmentTypeLabel.Content + "    Dinamička";
            }
            else if (selected.equipment.Type == EquipmentType.statical)
            {
                EquipmentTypeLabel.Content = EquipmentTypeLabel.Content + "    Statička";
            }

            EquipmentQuantity = selected.Quantity;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            selected.Quantity = int.Parse(Quantity.Text);
            if (!ValidateEntries()) return;

            RoomInventoryService roomInventoryService = new RoomInventoryService();
            roomInventoryService.UpdateRoomInventory(selected);
            roomUpdatePage.RoomInventoryBinding.Items.Refresh();
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
            if (Quantity.Text == "")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private Boolean ValidateEntries()
        {
            Quantity.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(Quantity))
            {
                return false;
            }
            return true;
        }
    }
}
