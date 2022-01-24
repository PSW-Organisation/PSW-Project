using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
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
            pharmacy.Id = dto.PharmacyId;
            pharmacy.PharmacyName = dto.PharmacyName;
            pharmacy.PharmacyUrl = dto.PharmacyUrl;
            pharmacy.PharmacyAddress = dto.PharmacyAddress;
            pharmacy.PharmacyApiKey = dto.PharmacyApiKey;
            pharmacy.HospitalApiKey = dto.HospitalApiKey;
            pharmacy.Comment = dto.Comment;
            pharmacy.Picture = dto.Picture;
            pharmacy.PharmacyCommunicationType = dto.pharmacyCommunicationType;
            pharmacy.Email = dto.Email;
            return pharmacy;
        }

        public static Pharmacy UpdatePharmacyDtoToPharmacy(PharmacyDto dto, Pharmacy pharmacy)
        {
            pharmacy.PharmacyName = dto.PharmacyName;
            pharmacy.PharmacyUrl = dto.PharmacyUrl;
            pharmacy.PharmacyAddress = dto.PharmacyAddress;
            //pharmacy.PharmacyApiKey = dto.PharmacyApiKey;
            pharmacy.HospitalApiKey = dto.HospitalApiKey;
            pharmacy.Comment = dto.Comment;
            pharmacy.Picture = dto.Picture;
            pharmacy.PharmacyCommunicationType = dto.pharmacyCommunicationType;
            pharmacy.Email = dto.Email;
            return pharmacy;
        }
        public static PharmacyDto PharmacyToPharmacyDto(Pharmacy pharmacy)
        {
            PharmacyDto dto = new PharmacyDto();
            dto.PharmacyId = pharmacy.Id;
            dto.PharmacyName = pharmacy.PharmacyName;
            dto.PharmacyUrl = pharmacy.PharmacyUrl;
            dto.PharmacyAddress = pharmacy.PharmacyAddress;
            dto.PharmacyApiKey = pharmacy.PharmacyApiKey;
            dto.HospitalApiKey = pharmacy.HospitalApiKey;
            dto.Comment = pharmacy.Comment;
            dto.Picture = pharmacy.Picture;
            dto.pharmacyCommunicationType = pharmacy.PharmacyCommunicationType;
            dto.Email = pharmacy.Email;
            return dto;
        }
    }
}
