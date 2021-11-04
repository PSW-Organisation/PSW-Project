using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehealthcare.Model
{
    public class PatientFeedback
    {
        public string id { get; set; }
        public string patientId { get; set; }
        public string text { get; set; }
        public bool anonymous { get; set; }
        public bool publishAllowed { get; set; }

    }
}
