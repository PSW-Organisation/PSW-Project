using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.DTO
{
    public class PharmacyDto
    {
        public int PharmacyId { get; set; }
        public string PharmacyUrl { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public string PharmacyApiKey { get; set; }
        public string HospitalApiKey { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
        public PharmacyCommunicationType communicationType { get; set; }
    }

}

