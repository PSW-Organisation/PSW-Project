using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class MedicineSearchDTO
    {
        public MedicineSearchDTO() { }
        public MedicineSearchDTO(string medicineName, int medicineAmount, string apiKey)
        {
            this.MedicineName = medicineName;
            this.MedicineAmount = medicineAmount;
            this.ApiKey = apiKey;
        }

        public string MedicineName { get; set; }
        public int MedicineAmount { get; set; }
        public string ApiKey { get; set; }
    }
}
