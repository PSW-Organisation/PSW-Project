using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Medicine : Entity
    {
        private String medicineName;
        private MedicineStatus medicineStatus;
        private List<String> medicineIngredient;
        private int medicineAmount;
        public Medicine() : base(-1) { }

        public String MedicineName
        {
            get { return medicineName; }
            set { medicineName = value; }
        }

        public MedicineStatus MedicineStatus
        {
            get { return medicineStatus; }
            set { medicineStatus = value; }
        }


        public List<String> MedicineIngredient
        {
            get
            {
                if (medicineIngredient == null)
                    medicineIngredient = new List<String>();
                return medicineIngredient;
            }
            set
            {
                RemoveAllMedicineIngredient();
                if (value != null)
                {
                    foreach (String oMedicineIngredient in value)
                        AddMedicineIngredient(oMedicineIngredient);
                }
            }
        }

        public void AddMedicineIngredient(String newMedicineIngredient)
        {
            if (newMedicineIngredient == null)
                return;
            if (medicineIngredient == null)
                medicineIngredient = new List<String>();
            if (!medicineIngredient.Contains(newMedicineIngredient))
                medicineIngredient.Add(newMedicineIngredient);
        }

        public void RemoveMedicineIngredient(String oldMedicineIngredient)
        {
            if (oldMedicineIngredient == null)
                return;
            if (medicineIngredient != null)
                if (medicineIngredient.Contains(oldMedicineIngredient))
                    medicineIngredient.Remove(oldMedicineIngredient);
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

        public int MedicineAmount { get => medicineAmount; set => medicineAmount = value; }
        public Medicine(int argId, String argName, MedicineStatus argMedicineStatus, int argQuantity): base(argId)
        {
            medicineName = argName;
            medicineStatus = argMedicineStatus;
            medicineAmount = argQuantity;
        }
    
    }

   
}