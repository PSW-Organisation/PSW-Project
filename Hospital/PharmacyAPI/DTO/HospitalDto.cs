using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.DTO
{
    public class HospitalDto
    {
        public long HospitalId { get; set; }
        public string HospitalUrl { get; set; }
        public string HospitalName { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalApiKey { get; set; }
        public string PharmacyApiKey { get; set; }
    }
}
