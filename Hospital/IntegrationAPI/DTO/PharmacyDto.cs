
using IntegrationLibrary.Pharmacies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Address = IntegrationLibrary.Pharmacies.Model.Address;

namespace IntegrationAPI.DTO
{
    public class PharmacyDto
    {
        public int PharmacyId { get; set; }
        public string PharmacyUrl { get; set; }
        public string PharmacyName { get; set; }
        public Address PharmacyAddress { get; set; }
        public string PharmacyApiKey { get; set; }
        public string HospitalApiKey { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
        public PharmacyCommunicationType pharmacyCommunicationType { get; set; }
    }

}

