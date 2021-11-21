using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Medicine : Entity
    {
        private String name;
        private MedicineStatus medicineStatus;

        private List<String> medicineIngredient;
        private int medicineAmmount;
        public Medicine() : base(-1) { }

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

        public int MedicineAmmount { get => medicineAmmount; set => medicineAmmount = value; }
     public Medicine(int argId, String argName, MedicineStatus argMedicineStatus, int argQuantity): base(argId)
    {
       
        name = argName;
        medicineStatus = argMedicineStatus;
        medicineAmmount = argQuantity;
    }
    
    }

   
}