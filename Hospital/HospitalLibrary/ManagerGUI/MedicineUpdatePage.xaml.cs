using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;
using vezba.Repository;

namespace vezba.ManagerGUI
{
    public partial class MedicineUpdatePage : Page, INotifyPropertyChanged
    {
        private Medicine selected;
        private MedicinePage addMedicineWindow;
        private MainManagerWindow mainManagerWindow;
        public static ObservableCollection<Ingridient> IngredientList { get; set; }
        public List<Ingridient> ingredientTemporaryList { get; set; }


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
        public MedicineUpdatePage(MainManagerWindow mainManagerWindow, Medicine medicine, MedicinePage addMedicineWindow)
        {
            InitializeComponent();
            selected = medicine;
            this.DataContext = this;
            this.addMedicineWindow = addMedicineWindow;
            this.mainManagerWindow = mainManagerWindow;

            MedicineService medicineService = new MedicineService(new MedicineFileRepository());
            List<Medicine> medicineList = medicineService.GetAllMedicine();
            List<Medicine> temporary = new List<Medicine>();

            for (int i = 0; i < medicineList.Count; i++)
            {
                if (medicineList[i].Status == MedicineStatus.approved && medicineList[i].Name != medicine.Name)
                {
                    temporary.Add(medicineList[i]);
                }
            }

            comboReplacementMedicine.ItemsSource = temporary;
            List<string> condition = new List<string> { "Kapsula", "Pilula", "Sirup" };
            comboCondition.ItemsSource = condition;

            ingredientTemporaryList = medicine.ingridient;

            NameTextBox.Text = medicine.Name;
            ManufacturerTextBox.Text = medicine.Manufacturer;
            PackagingTextBox.Text = medicine.Packaging;

            if (medicine.Condition == MedicineCondition.capsule)
            {
                comboCondition.SelectedIndex = 0;
            }
            else if (medicine.Condition == MedicineCondition.pill)
            {
                comboCondition.SelectedIndex = 1;
            }
            else if (medicine.Condition == MedicineCondition.syrup)
            {
                comboCondition.SelectedIndex = 2;
            }

            if (medicine.ReplacementMedicine == null)
            {

            }
            else
            {
                for (int i = 0; i < temporary.Count; i++)
                {
                    if (temporary[i].Name == medicine.ReplacementMedicine.Name)
                    {
                        comboReplacementMedicine.SelectedIndex = i;
                    }
                }
            }

            List<Ingridient> ingredientList = medicine.ingridient;
            IngredientList = new ObservableCollection<Ingridient>(ingredientList);
            IngredientsBinding.ItemsSource = IngredientList;

            MedicineName = selected.Name;
            ManufacturerName = selected.Manufacturer;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            selected.Name = NameTextBox.Text;
            selected.Manufacturer = ManufacturerTextBox.Text;
            selected.Packaging = PackagingTextBox.Text;

            if (comboCondition.SelectedIndex == 1)
            {
                selected.Condition = MedicineCondition.pill;
            }

            else if (comboCondition.SelectedIndex == 0)
            {
                selected.Condition = MedicineCondition.capsule;
            }

            else if (comboCondition.SelectedIndex == 2)
            {
                selected.Condition = MedicineCondition.syrup;
            }

            selected.ReplacementMedicine = (Medicine)comboReplacementMedicine.SelectedItem;

            MedicineService medicineService = new MedicineService(new MedicineFileRepository());
            medicineService.UpdateMedicine(selected);
            addMedicineWindow.MedicineBinding.Items.Refresh();

            NavigationService.GoBack();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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


            if (NameTextBox.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ingredientName = NewIngredientTextBox.Text;
            var newIngredient = new Ingridient(ingredientName);

            ingredientTemporaryList.Add(newIngredient);
            IngredientList = new ObservableCollection<Ingridient>(ingredientTemporaryList);
            IngredientsBinding.ItemsSource = IngredientList;
            IngredientsBinding.Items.Refresh();


            if (NameTextBox.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
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

        private void ManufacturerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;
        }

        private void NewIngredientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text == "" || ManufacturerTextBox.Text == "" || ingredientTemporaryList.Count == 0)
            {
                OkButton.IsEnabled = false;
            }
            else OkButton.IsEnabled = true;

            if (NewIngredientTextBox.Text == "") { AddIngredientButton.IsEnabled = false; }
            else { AddIngredientButton.IsEnabled = true; }
        }

        private Boolean ValidateEntries()
        {
            NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(NameTextBox))
            {
                return false;
            }

            return true;
        }
    }
}