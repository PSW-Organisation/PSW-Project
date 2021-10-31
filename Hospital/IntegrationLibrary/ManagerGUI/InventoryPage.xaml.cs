using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace vezba.ManagerGUI
{
    public partial class InventoryPage : Page
    {
        public static ObservableCollection<Equipment> EquipmentList { get; set; }
        public static List<Equipment> equipmentList;
        private MainManagerWindow mainManagerWindow;

        public InventoryPage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            EquipmentService equipmentService = new EquipmentService();
            equipmentList = equipmentService.GetAllEquipment();
            EquipmentList = new ObservableCollection<Equipment>(equipmentList);
            InventaryBinding.ItemsSource = EquipmentList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(InventaryBinding.ItemsSource);
            view.Filter = EquipmentFilter;
        }

        private void Add_Equipment_Button_Click(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new InventoryAddEquipmentPage(mainManagerWindow);
            EquipmentService equipmentService = new EquipmentService();
            equipmentList = equipmentService.GetAllEquipment();
        }

        private void Remove_Equipment_Button_Click(object sender, RoutedEventArgs e)
        {
            if (InventaryBinding.SelectedIndex > -1)
            {
                Equipment equipment = (Equipment)InventaryBinding.SelectedItem;
                EquipmentService equipmentService = new EquipmentService();
                equipmentService.DeleteEquipment(equipment.Id);
                equipmentList = equipmentService.GetAllEquipment();
                EquipmentList.Remove(equipment);
            }
            else
            {
                MessageBox.Show("Ni jedan artikal nije selektovan!");
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (InventaryBinding.SelectedIndex > -1)
            {
                Equipment equipment = (Equipment)InventaryBinding.SelectedItem;
                mainManagerWindow.MainManagerView.Content = new InventoryChangeEquipmentPage(mainManagerWindow, equipment, this);
            }

            else
            {
                MessageBox.Show("Ni jedan artikal nije selektovan!");
            }
        }



        private void StaticCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (EquipmentList != null && CheckedBoxStatic.IsChecked == true && equipmentList != null)
            {
                foreach (Equipment equipment in equipmentList)
                {
                    if (equipment.Type == EquipmentType.statical)
                    {
                        EquipmentList.Add(equipment);
                        InventaryBinding.Items.Refresh();
                    }
                }
            }
        }

        private void DinamicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (EquipmentList != null && CheckedBoxDinamic.IsChecked == true && equipmentList != null)
            {
                foreach (Equipment equipment in equipmentList)
                {
                    if (equipment.Type == EquipmentType.dinamical)
                    {
                        EquipmentList.Add(equipment);
                        InventaryBinding.Items.Refresh();
                    }
                }
            }
        }

        private void StaticCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (EquipmentList != null && CheckedBoxStatic.IsChecked == false)
            {
                foreach (Equipment equipment in equipmentList)
                {
                    if (equipment.Type == EquipmentType.statical)
                    {
                        for (int i = 0; i < EquipmentList.Count; i++) 
                        {
                            if (EquipmentList[i].Id == equipment.Id)
                            {
                                EquipmentList.Remove(EquipmentList[i]);
                                InventaryBinding.Items.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private void DinamicCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (EquipmentList != null && CheckedBoxDinamic.IsChecked == false)
            {
                foreach (Equipment equipment in equipmentList)
                {
                    if (equipment.Type == EquipmentType.dinamical)
                    {
                        for (int i = 0; i < EquipmentList.Count; i++)
                        {
                            if (EquipmentList[i].Id == equipment.Id)
                            {
                                    EquipmentList.Remove(EquipmentList[i]);
                                    InventaryBinding.Items.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private bool EquipmentFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Equipment).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(InventaryBinding.ItemsSource).Refresh();

        }

        private void ButtonMainClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MainManagerPage(mainManagerWindow);
        }

        private void ButtonMedicineClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MedicinePage(mainManagerWindow);
        }

        private void ButtonRoomsClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new RoomsPage(mainManagerWindow);
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
