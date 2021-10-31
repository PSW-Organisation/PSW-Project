using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using vezba.Repository;

namespace vezba.ManagerGUI
{
    public partial class MedicineAddPage : Page, INotifyPropertyChanged
    {
        public List<Medicine> medicineList { get; set; }
        private Medicine newMedicine;
        public static ObservableCollection<Ingridient> IngredientList { get; set; }
        public List<Ingridient> ingredientTemporaryList { get; set; }
        private MainManagerWindow mainManagerWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        private String medicineName;

        public String MedicineName
        {
            get { return medicineName; }
            set
            {
                if (value != medicineName)
                {
                    medicineName = value;
                    OnPropertyChanged("MedicineName");
                }
            }
        }

        private String manufacturerName;

        public String ManufacturerName
        {
            get { return manufacturerName; }
            set
            {
                if (value != manufacturerName)
                {
                    manufacturerName = value;
                    OnPropertyChanged("ManufacturerName");
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

        public MedicineAddPage(MainManagerWindow mainManagerWindow)
        {
            InitializeComponent();
            DataContext = this;
            this.mainManagerWindow = mainManagerWindow;
            MedicineService medicineService = new MedicineService(new MedicineFileRepository());
            medicineList = medicineService.GetApproved();
            comboReplacementMedicine.ItemsSource = medicineList;
            List<string> condition = new List<string> { "Kapsula", "Pilula", "Sirup" };
            comboCondition.ItemsSource = condition;
            newMedicine = new Medicine("Naziv", "Naziv", "Naziv", 0, MedicineCondition.pill);
            ingredientTemporaryList = new List<Ingridient>();
            OkButton.IsEnabled = false;
            if (NewIngredientTextBox.Text == "") { AddIngredientButton.IsEnabled = false; }
            else { AddIngredientButton.IsEnabled = true; }
        }
        private void AddIngredientButtonClick(object sender, RoutedEventArgs e)
        {
            var ingredientName = NewIngredientTextBox.Text;
            var newIngredient = new Ingridient(ingredientName);
            ingredientTemporaryList.Add(newIngredient);
            IngredientList = new ObservableCollection<Ingridient>(ingredientTemporaryList);
            IngredientsBinding.ItemsSource = IngredientList;
            IngredientsBinding.Items.Refresh();

            if (comboCondition.SelectedIndex == -1 || MedicineNameTB.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }
        private void RemoveIngredientButtonClick(object sender, RoutedEventArgs e)
        {
            if (IngredientsBinding.SelectedIndex > -1)
            {
                Ingridient ingredient = (Ingridient)IngredientsBinding.SelectedItem;
                ingredientTemporaryList.Remove(ingredient);
                IngredientList = new ObservableCollection<Ingridient>(ingredientTemporaryList);
                IngredientsBinding.ItemsSource = IngredientList;
                IngredientsBinding.Items.Refresh();
            }

            if (comboCondition.SelectedIndex == -1 || MedicineNameTB.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            var Name = MedicineNameTB.Text;
            var Manufacturer = ManufacturerTextBox.Text;
            var Packaging = PackagingTextBox.Text;
            var Condition = MedicineCondition.pill;

            if (comboCondition.SelectedIndex == 1) Condition = MedicineCondition.pill;
            else if (comboCondition.SelectedIndex == 0) Condition = MedicineCondition.capsule;
            else if (comboCondition.SelectedIndex == 2) Condition = MedicineCondition.syrup;
            
            Medicine replacementMedicine = (Medicine)comboReplacementMedicine.SelectedItem;
            MedicineService medicineService = new MedicineService(new MedicineFileRepository());
            newMedicine = new Medicine(Name, Manufacturer, Packaging, 0, Condition) { ReplacementMedicine = replacementMedicine };
            MedicinePage.MedicineList.Add(newMedicine);
            newMedicine.ingridient = ingredientTemporaryList;
            medicineService.SaveMedicine(newMedicine);
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

        private void comboCondition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboCondition.SelectedIndex == -1 || MedicineNameTB.Text == "" || ManufacturerTextBox.Text =="" || ingredientTemporaryList.Count==0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }

        private void MedicineName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboCondition.SelectedIndex == -1 || MedicineNameTB.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }

        private void ManufacturerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (comboCondition.SelectedIndex == -1 || MedicineNameTB.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }

        private void NewIngredientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewIngredientTextBox.Text == "") { AddIngredientButton.IsEnabled = false; }
            else { AddIngredientButton.IsEnabled = true; }

            if (comboCondition.SelectedIndex == -1 || MedicineNameTB.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }

        private Boolean ValidateEntries()
        {
            MedicineNameTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(MedicineNameTB))
            {
                return false;
            }

            return true;
        }
    }
}
