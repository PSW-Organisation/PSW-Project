using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class OnCallShiftDTO
    {
        public string DoctorId { get; set; }
        public DateTime date { get; set; }

        public OnCallShiftDTO() { }
        public OnCallShiftDTO(string doctorId, DateTime date)
        {
            DoctorId = doctorId;
            this.date = date;
        }
    }
}
