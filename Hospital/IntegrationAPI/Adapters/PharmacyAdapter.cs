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
            pharmacy.PharmacyComunicationInfo.PharmacyUrl = dto.PharmacyUrl;
            pharmacy.PharmacyAddress = dto.PharmacyAddress;
            pharmacy.PharmacyComunicationInfo.PharmacyApiKey = dto.PharmacyApiKey;
            pharmacy.PharmacyComunicationInfo.HospitalApiKey = dto.HospitalApiKey;
            pharmacy.Comment = dto.Comment;
            pharmacy.Picture = dto.Picture;
            pharmacy.PharmacyComunicationInfo.PharmacyCommunicationType = dto.pharmacyCommunicationType;
            return pharmacy;
        }

        public static Pharmacy UpdatePharmacyDtoToPharmacy(PharmacyDto dto, Pharmacy pharmacy)
        {
            pharmacy.PharmacyName = dto.PharmacyName;
            pharmacy.PharmacyComunicationInfo.PharmacyUrl = dto.PharmacyUrl;
            pharmacy.PharmacyAddress = dto.PharmacyAddress;
            pharmacy.PharmacyComunicationInfo.PharmacyApiKey = dto.PharmacyApiKey;
            pharmacy.PharmacyComunicationInfo.HospitalApiKey = dto.HospitalApiKey;
            pharmacy.Comment = dto.Comment;
            pharmacy.Picture = dto.Picture;
            pharmacy.PharmacyComunicationInfo.PharmacyCommunicationType = dto.pharmacyCommunicationType;
            return pharmacy;
        }
        public static PharmacyDto PharmacyToPharmacyDto(Pharmacy pharmacy)
        {
            PharmacyDto dto = new PharmacyDto();
            dto.PharmacyId = pharmacy.Id;
            dto.PharmacyName = pharmacy.PharmacyName;
            dto.PharmacyUrl = pharmacy.PharmacyComunicationInfo.PharmacyUrl;
            dto.PharmacyAddress = pharmacy.PharmacyAddress;
            dto.PharmacyApiKey = pharmacy.PharmacyComunicationInfo.PharmacyApiKey;
            dto.HospitalApiKey = pharmacy.PharmacyComunicationInfo.HospitalApiKey;
            dto.Comment = pharmacy.Comment;
            dto.Picture = pharmacy.Picture;
            dto.pharmacyCommunicationType = pharmacy.PharmacyComunicationInfo.PharmacyCommunicationType;
            return dto;
        }
    }
}
