using System.Windows;
using System.Windows.Controls;
using Model;

namespace vezba.ManagerGUI
{
    public partial class DetailDeclinedMedicinePage : Page
    {
        private MainManagerWindow mainManagerWindow;
        private DeclinedMedicine declinedMedicine;
        private MedicinePage medicinePage;
        public DetailDeclinedMedicinePage(MainManagerWindow mainManagerWindow, DeclinedMedicine declinedMedicine, MedicinePage medicinePage)
        {
            InitializeComponent();
            this.mainManagerWindow = mainManagerWindow;
            this.medicinePage = medicinePage;
            this.declinedMedicine = declinedMedicine;
            Manufacturer.Text = Manufacturer.Text + " " + declinedMedicine.MedicineManufacturer;
            Name.Text = Name.Text + " " + declinedMedicine.MedicineName;
            Shape.Text = Shape.Text + " " + declinedMedicine.Medicine.Condition;
            Packaging.Text = Packaging.Text + " " + declinedMedicine.Medicine.Packaging;
            if (declinedMedicine.Medicine.ReplacementMedicine != null) Replacement.Text = Replacement.Text + " " + declinedMedicine.Medicine.ReplacementMedicine.Name;
            listViewAlergens.ItemsSource = declinedMedicine.Medicine.ingridient;
            Komentar.Text = Komentar.Text + " " + declinedMedicine.Description;
        }

        private void EditButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            mainManagerWindow.MainManagerView.Content = new DeclinedMedicineEditPage(mainManagerWindow, declinedMedicine, medicinePage);
        }

        private void ButtonBackClick(object sender, System.Windows.RoutedEventArgs e)
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
    }
}

