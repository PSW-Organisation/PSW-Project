using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class MedicineDTO
    {
        public int Id {get;set;}
        public String MedicineName { get; set; }
        public MedicineStatus MedicineStatus { get; set; }
        public int MedicineAmount { get; set; }
        public List<String> MedicineIngredient { get; set; }
    }
}
