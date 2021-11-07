using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.DTO
{
    public class ComplaintDTO
    {

        public long ComplaintId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long HospitalId { get; set; } 

    }
}
