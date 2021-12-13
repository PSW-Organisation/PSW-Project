using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Model
{
    public class MedicineSearch
    {
        private string medicineName;
        private int medicineAmount;
        private string apiKey;

        public string MedicineName
        {
            get { return medicineName; }
            set { medicineName = value; }
        }

        public int MedicineAmount
        {
            get { return medicineAmount; }
            set { medicineAmount = value; }
        }

        public string ApiKey
        {
            get { return apiKey; }
            set { apiKey = value; }
        }

        public MedicineSearch()
        {

        }

        public MedicineSearch(string medicineName, int medicineAmount, string apiKey)
        {
            this.medicineName = medicineName;
            this.medicineAmount = medicineAmount;
            this.apiKey = apiKey;
        }
    }
}
