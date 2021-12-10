using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class MedicineConsumption
    {
        private string medicineName;
        private int medicineAmmount;

        public string MedicineName { get => medicineName; set => medicineName = value; }
        public int MedicineAmmount { get => medicineAmmount; set => medicineAmmount = value; }
        public MedicineConsumption(string medicineName, int medicineAmmount)
        {
            this.medicineName = medicineName;
            this.medicineAmmount = medicineAmmount;
        }
    }
}
