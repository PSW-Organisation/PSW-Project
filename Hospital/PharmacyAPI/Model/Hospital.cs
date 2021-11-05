using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Model
{
    public class Hospital
    {
        private long hospitalId;
        private string hospitalUrl;
        private string hospitalName;
        private string hospitalAddress;
        private string hospitalApiKey;

        public long HospitalId { get => hospitalId; set => hospitalId = value; }
        public string HospitalUrl { get => hospitalUrl; set => hospitalUrl = value; }
        public string HospitalName { get => hospitalName; set => hospitalName = value; }
        public string HospitalAddress { get => hospitalAddress; set => hospitalAddress = value; }
        public string HospitalApiKey { get => hospitalApiKey; set => hospitalApiKey = value; }

        public Hospital() { }
        public Hospital(long hospitalId, string hospitalUrl, string hospitalName, string hospitalAddress, string hospitalApiKey)
        {
            this.hospitalId = hospitalId;
            this.hospitalUrl = hospitalUrl;
            this.hospitalName = hospitalName;
            this.hospitalAddress = hospitalAddress;
            this.hospitalApiKey = hospitalApiKey;
        }
    }
}
