using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class OnCallShiftDTO
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        public DateTime date { get; set; }
    }
}
