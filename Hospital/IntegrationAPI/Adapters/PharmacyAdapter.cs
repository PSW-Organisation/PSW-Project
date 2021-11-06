using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class PharmacyAdapter
    {
        public static Pharmacy PharmacyDtoToPharmacy(PharmacyDto dto)
        {
            Pharmacy pharmacy = new Pharmacy();
            pharmacy.PharmacyName = dto.PharmacyName;
            pharmacy.PharmacyUrl = dto.PharmacyUrl;
            pharmacy.PharmacyAddress = dto.PharmacyAddress;
            pharmacy.PharmacyApiKey = dto.PharmacyApiKey;
            pharmacy.HospitalApiKey = dto.HospitalApiKey;
            return pharmacy;
        }

        public static Pharmacy UpdatePharmacyDtoToPharmacy(PharmacyDto dto, Pharmacy pharmacy)
        {
            pharmacy.PharmacyName = dto.PharmacyName;
            pharmacy.PharmacyUrl = dto.PharmacyUrl;
            pharmacy.PharmacyAddress = dto.PharmacyAddress;
            pharmacy.PharmacyApiKey = dto.PharmacyApiKey;
            pharmacy.HospitalApiKey = dto.HospitalApiKey;
            return pharmacy;
        }
        public static PharmacyDto PharmacyToPharmacyDto(Pharmacy pharmacy)
        {
            PharmacyDto dto = new PharmacyDto();
            dto.PharmacyName = pharmacy.PharmacyName;
            dto.PharmacyUrl = pharmacy.PharmacyUrl;
            dto.PharmacyAddress = pharmacy.PharmacyAddress;
            dto.PharmacyApiKey = pharmacy.PharmacyApiKey;
            dto.HospitalApiKey = pharmacy.HospitalApiKey;

            return dto;
        }
    }
}
