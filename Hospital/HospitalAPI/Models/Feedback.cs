using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Models
{
    public class Feedback
    {
        public string id { get; set; }
        public string patientId { get; set; }
        public string text { get; set; }
        public bool anonymous { get; set; }
        public bool publishAllowed { get; set; }

    }
}
