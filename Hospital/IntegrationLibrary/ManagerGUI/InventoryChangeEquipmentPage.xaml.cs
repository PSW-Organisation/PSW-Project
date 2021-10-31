using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Service;

namespace vezba.ManagerGUI
{
    public partial class InventoryChangeEquipmentPage : Page, INotifyPropertyChanged
    {
        private Equipment equipment;
        private InventoryPage inventoryPage;
        private MainManagerWindow mainManagerWindow;
        public event PropertyChangedEventHandler PropertyChanged;

        private String equipmentName;

        public String EquipmentName
        {
            get { return equipmentName; }
            set
            {
                if (value != equipmentName)
                {
                    equipmentName = value;
                    OnPropertyChanged("EquipmentName");
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
        public InventoryChangeEquipmentPage(MainManagerWindow mainManagerWindow, Equipment equipment, InventoryPage inventoryPage)
        {
            InitializeComponent();
            this.equipment = equipment;
            this.inventoryPage = inventoryPage;
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            List<string> type = new List<string> { "Dinamička", "Statička"};
            comboEquipmentType.ItemsSource = type;
            if (equipment.Type == EquipmentType.dinamical)
            {
                comboEquipmentType.SelectedIndex = 0;
            }
            else
            {
                comboEquipmentType.SelectedIndex = 1;
            }

            EquipmentName = equipment.Name;

        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if(!ValidateEntries()) return;
            
            var name = EquipmentNameTB.Text;
            equipment.Name = name;

            if (comboEquipmentType.SelectedIndex==0)
            {
                equipment.Type = EquipmentType.dinamical;
            }
            else
            {
                equipment.Type = EquipmentType.statical;
            }

            inventoryPage.InventaryBinding.Items.Refresh();
            EquipmentService equipmentService = new EquipmentService();
            equipmentService.UpdateEquipment(equipment);
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

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NazivOpreme_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboEquipmentType.SelectedIndex == -1 || EquipmentNameTB.Text == "")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
        }

        private Boolean ValidateEntries()
        {
            EquipmentNameTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(EquipmentNameTB))
            {
                return false;
            }

            return true;
        }
    }
}