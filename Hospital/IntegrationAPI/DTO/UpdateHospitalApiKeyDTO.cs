using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class UpdateHospitalApiKeyDTO
    {
        public long PharmacyID { get; set; }
        public string HospitalApiKey { get; set; }
    }
}
