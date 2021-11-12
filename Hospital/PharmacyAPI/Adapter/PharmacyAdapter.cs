
using PharmacyAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Adapter
{
    public class PharmacyAdapter
    {

        public static Pharmacy PharmacyDtoToPharmacy(PharmacyDTO dto)
        {
            Pharmacy pharmacy = new Pharmacy();
            pharmacy.PharmacyId = dto.PharmacyId;
            pharmacy.PharmacyUrl = dto.PharmacyUrl;
            pharmacy.PharmacyName = dto.PharmacyName;
            pharmacy.PharmacyAddress = dto.PharmacyAddress;
            pharmacy.PharmacyApiKey = dto.PharmacyApiKey;

            return pharmacy;
        }

        public static PharmacyDTO PharmacyToPharmacyDto(Pharmacy pharmacy)
        {
            PharmacyDTO dto = new PharmacyDTO();
            dto.PharmacyId = pharmacy.PharmacyId;
            dto.PharmacyUrl = pharmacy.PharmacyUrl;
            dto.PharmacyName = pharmacy.PharmacyName;
            dto.PharmacyAddress = pharmacy.PharmacyAddress;
            dto.PharmacyApiKey = pharmacy.PharmacyApiKey;

            return dto;
        }

    }
}
