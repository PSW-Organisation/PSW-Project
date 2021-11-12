using System;
using System.Collections.Generic;


namespace PharmacyAPI.Model
{
    public class Medicine
    {
        private int id;
        private String name;
        private MedicineStatus medicineStatus;
        private int quantity;

        public Medicine() { }

        public Medicine(int argId, String argName, MedicineStatus argMedicineStatus, int argQuantity)
        {
            id = argId;
            name = argName;
            medicineStatus = argMedicineStatus;
            quantity = argQuantity;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

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