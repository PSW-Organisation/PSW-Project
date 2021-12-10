using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class MedicineDTO
    {
        public int Id {get;set;}
        public string MedicineName { get; set; }
        public int MedicineAmount { get; set; }
    }
}
