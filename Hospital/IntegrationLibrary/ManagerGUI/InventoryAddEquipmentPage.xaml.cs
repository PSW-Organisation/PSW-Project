using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;

namespace vezba.ManagerGUI
{
    public partial class InventoryAddEquipmentPage : Page, INotifyPropertyChanged
    {
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


        public InventoryAddEquipmentPage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            List<string> type = new List<string> {"Dinamička", "Statička"};
            comboEquipmentType.ItemsSource = type;
            OkButton.IsEnabled = false;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            EquipmentType type = EquipmentType.statical;

            if(!ValidateEntries()) return;

            if (comboEquipmentType.SelectedIndex == 0)
            {
                type = EquipmentType.dinamical;
            }
            else
            {
                type = EquipmentType.statical;
            }

            EquipmentService equipmentService = new EquipmentService();
            var newEquipment = new Equipment(0, EquipmentNameTB.Text, type);
            equipmentService.SaveEquipment(newEquipment);
            InventoryPage.EquipmentList.Add(newEquipment);
            NavigationService.GoBack();
        }

        private void Cancel_Add_Button_Click(object sender, RoutedEventArgs e)
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

        private void comboEquipmentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEquipmentType.SelectedIndex == -1 || EquipmentNameTB.Text == "")
            {
                OkButton.IsEnabled = false;
            }

            else OkButton.IsEnabled = true;
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
