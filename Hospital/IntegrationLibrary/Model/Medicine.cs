using System;
using System.Collections.Generic;

namespace ehealthcare.Model
{
    [Serializable]
    public class Medicine : Entity
    {
        private String name;
        private MedicineStatus medicineStatus;
        private List<MedicineIngredient> medicineIngredient;

        public Medicine() : base("undefinedNumberKey") { }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public MedicineStatus MedicineStatus
        {
            get { return medicineStatus; }
            set { medicineStatus = value; }
        }


        public List<MedicineIngredient> MedicineIngredient
        {
            get
            {
                if (medicineIngredient == null)
                    medicineIngredient = new List<MedicineIngredient>();
                return medicineIngredient;
            }
            set
            {
                RemoveAllMedicineIngredient();
                if (value != null)
                {
                    foreach (MedicineIngredient oMedicineIngredient in value)
                        AddMedicineIngredient(oMedicineIngredient);
                }
            }
        }

        public void AddMedicineIngredient(MedicineIngredient newMedicineIngredient)
        {
            if (newMedicineIngredient == null)
                return;
            if (this.medicineIngredient == null)
                this.medicineIngredient = new List<MedicineIngredient>();
            if (!this.medicineIngredient.Contains(newMedicineIngredient))
                this.medicineIngredient.Add(newMedicineIngredient);
        }

        public void RemoveMedicineIngredient(MedicineIngredient oldMedicineIngredient)
        {
            if (oldMedicineIngredient == null)
                return;
            if (this.medicineIngredient != null)
                if (this.medicineIngredient.Contains(oldMedicineIngredient))
                    this.medicineIngredient.Remove(oldMedicineIngredient);
        }

        public void RemoveAllMedicineIngredient()
        {
            if (medicineIngredient != null)
                medicineIngredient.Clear();
        }


        [System.Xml.Serialization.XmlIgnore]
        public String MedicineStatusString
        {
            get
            {
                if (Enum.GetName(typeof(MedicineStatus), medicineStatus) == "approved")
                {
                    return "Odobren";
                }
                else if (Enum.GetName(typeof(MedicineStatus), medicineStatus) == "disapproved")
                {
                    return "Neodobren";
                }
                else
                {
                    return "Čeka na odobravanje";
                }
            }
        }
    }
}