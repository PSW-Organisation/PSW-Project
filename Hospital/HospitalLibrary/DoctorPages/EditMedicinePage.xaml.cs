using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Model;
using Service;
using vezba.Repository;

namespace vezba.DoctorPages
{
    /// <summary>
    /// Interaction logic for EditMedicinePage.xaml
    /// </summary>
    public partial class EditMedicinePage : Page, INotifyPropertyChanged
    {
        public Medicine Medicine { get; set; }

        private readonly MedicineService _medicineService;

        private readonly DoctorView _doctorView;

        private readonly MedicinePageView _medicinePageView;

        private List<Medicine> _medicineForReplacement;
        public List<Medicine> MedicineForReplacement
        {
            get
            {
                return _medicineForReplacement;
            }
            set
            {
                if (value != _medicineForReplacement)
                {
                    _medicineForReplacement = value;
                }
            }
        }

        private List<Ingridient> _ingredients;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private String _medicineName;
        public String MedicineName
        {
            get
            {
                return _medicineName;
            }
            set
            {
                if (value != _medicineName)
                {
                    _medicineName = value;
                    OnPropertyChanged("MedicineName");
                }
            }
        }

        private String _manufacturer;
        public String Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                if (value != _manufacturer)
                {
                    _manufacturer = value;
                    OnPropertyChanged("Manufacturer");
                }
            }
        }

        private String _packaging;

        public String Packaging
        {
            get
            {
                return _packaging;
            }
            set
            {
                if (value != _packaging)
                {
                    _packaging = value;
                    OnPropertyChanged("Packaging");
                }
            }
        }

        public List<Ingridient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                if (value != _ingredients)
                {
                    _ingredients = value;
                }
            }
        }

        public EditMedicinePage(Medicine medicine, DoctorView doctorView, MedicinePageView medicinePageView)
        {
            InitializeComponent();
            DataContext = this;
            Medicine = medicine;
            _doctorView = doctorView;
            _medicinePageView = medicinePageView;
            switch (medicine.Condition)
            {
                case MedicineCondition.pill:
                    ConditionCMB.SelectedIndex = 0;
                    break;
                case MedicineCondition.capsule:
                    ConditionCMB.SelectedIndex = 1;
                    break;
                case MedicineCondition.syrup:
                    ConditionCMB.SelectedIndex = 2;
                    break;
            }

            Ingredients = new List<Ingridient>(medicine.Ingridient);

            _medicineService = new MedicineService(new MedicineFileRepository());
            MedicineForReplacement = _medicineService.GetPossibleReplacements(Medicine);

            if (medicine.ReplacementMedicine != null)
                ReplacementMedicineCB.SelectedValue = medicine.ReplacementMedicine.MedicineID;
            MedicineName = Medicine.Name;
            Manufacturer = Medicine.Manufacturer;
            Packaging = Medicine.Packaging;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            if(!ValidateEntries())
                return;
            EditMedicine();
            _medicineService.UpdateMedicine(Medicine);
            _medicinePageView.ApprovedMedicineListView.Items.Refresh();
            _doctorView.Main.GoBack();
            _doctorView.Main.GoBack();
        }

        private void EditMedicine()
        {
            var medicineName = MedicineName;
            var manufacturer = Manufacturer;
            var packaging = Packaging;
            MedicineCondition condition;
            switch (ConditionCMB.SelectedIndex)
            {
                case 0:
                    condition = MedicineCondition.pill;
                    break;
                case 1:
                    condition = MedicineCondition.capsule;
                    break;
                default:
                    condition = MedicineCondition.syrup;
                    break;
            }

            var replacementMedicine = (Medicine) ReplacementMedicineCB.SelectedItem;
            Medicine.Name = medicineName;
            Medicine.Manufacturer = manufacturer;
            Medicine.Packaging = packaging;
            Medicine.Condition = condition;
            Medicine.Ingridient = new List<Ingridient>(Ingredients);
            Medicine.ReplacementMedicine = replacementMedicine;
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _doctorView.Main.GoBack();
        }

        private void PlusButtonClick(object sender, RoutedEventArgs e)
        {
            if(TbAllergen.Text == null || TbAllergen.Text.Length == 0)
                return;
            var ingredientName = TbAllergen.Text;
            var ingredient = new Ingridient(ingredientName);
            Ingredients.Add(ingredient);
            IngredientListBox.Items.Refresh();
            TbAllergen.Clear();
        }

        private void MinusButtonClick(object sender, RoutedEventArgs e)
        {
            if (IngredientListBox.SelectedItems.Count > 0)
            {
                var ingredient = (Ingridient)IngredientListBox.SelectedItem;
                Ingredients.Remove(ingredient);
                IngredientListBox.Items.Refresh();
            }
        }

        private Boolean ValidateEntries()
        {
            Boolean ret = true;
            NameTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(NameTB))
                ret = false;
            ManufacturerTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(ManufacturerTB))
                ret = false;
            PackagingTB.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (Validation.GetHasError(PackagingTB))
                ret = false;
            return ret;
        }
    }
}
