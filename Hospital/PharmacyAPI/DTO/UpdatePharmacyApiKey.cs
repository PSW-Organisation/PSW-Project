using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.DTO
{
    public class UpdatePharmacyApiKey
    {
        public long HospitalId {get;set;}
        public string PharmacyApiKey { get; set; }

    }
}
