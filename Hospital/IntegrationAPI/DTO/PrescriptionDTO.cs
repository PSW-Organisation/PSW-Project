using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class PrescriptionDTO
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string MedicineId { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Diagnosis { get; set; }
    }
}
