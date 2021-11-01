using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Model;
using Service;
using vezba.Repository;

namespace vezba.ManagerGUI
{
    public partial class DeclinedMedicineManagerPage : Page
    {
        private List<DeclinedMedicine> declinedMedicineList;
        private MedicinePage medicinePage;
        private ObservableCollection<DeclinedMedicine> DeclinedMedicineList { get; set; }
        private MainManagerWindow mainManagerWindow;
        public DeclinedMedicineManagerPage(MainManagerWindow mainManagerWindow, MedicinePage medicinePage)
        {
            InitializeComponent();
            this.mainManagerWindow = mainManagerWindow;
            this.medicinePage = medicinePage;
            var declinedMedicineService = new DeclinedMedicineService(new DeclinedMedicineFileRepository());
            declinedMedicineList = declinedMedicineService.GetAllDeclinedMedicine();
            DeclinedMedicineList = new ObservableCollection<DeclinedMedicine>(declinedMedicineList);
            DeclinedMedicineBinding.ItemsSource = DeclinedMedicineList;
        }
        private void ViewDetailButton(object sender, RoutedEventArgs e)
        {
            if (DeclinedMedicineBinding.SelectedIndex > -1)
            {
                DeclinedMedicine selected = (DeclinedMedicine)DeclinedMedicineBinding.SelectedItems[0];
                mainManagerWindow.MainManagerView.Content = new DetailDeclinedMedicinePage(mainManagerWindow, selected, medicinePage);
            }
            else
            {
                MessageBox.Show("Ni jedna prostorija nije selektovana!");
            }
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new MedicinePage(mainManagerWindow);
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

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DeclinedMedicineBinding.SelectedIndex > -1)
            {
                DeclinedMedicine selected = (DeclinedMedicine)DeclinedMedicineBinding.SelectedItems[0];
                mainManagerWindow.MainManagerView.Content = new DetailDeclinedMedicinePage(mainManagerWindow, selected, medicinePage);
            }
            else
            {
                MessageBox.Show("Ni jedna prostorija nije selektovana!");
            }
        }
    }
}
