using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.DTO
{
    public class PharmacyDTO
    {
        public long PharmacyId { get; set; }
        public string PharmacyUrl { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }
        public string PharmacyApiKey { get; set; }


    }
}
