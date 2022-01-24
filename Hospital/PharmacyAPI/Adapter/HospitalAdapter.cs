using PharmacyAPI.DTO;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Adapter
{
    public class HospitalAdapter
    {
        public static Hospital HospitalDtoToHospital( HospitalDto dto)
        {
            Hospital hospital = new Hospital();
            hospital.HospitalId = dto.HospitalId;
            hospital.HospitalAddress = dto.HospitalAddress;
            hospital.HospitalName = dto.HospitalName;
            hospital.HospitalUrl = dto.HospitalUrl;
            hospital.HospitalApiKey = dto.HospitalApiKey;
            hospital.PharmacyApiKey = dto.PharmacyApiKey;
            hospital.Email = dto.Email;
            return hospital;
        }

        public static HospitalDto HospitalToHospitalDto(Hospital hospital)
        {
            HospitalDto dto = new HospitalDto();
            dto.HospitalId = hospital.HospitalId;
            dto.HospitalAddress = hospital.HospitalAddress;
            dto.HospitalName = hospital.HospitalName;
            dto.HospitalUrl = hospital.HospitalUrl;
            dto.HospitalApiKey = hospital.HospitalApiKey;
            dto.PharmacyApiKey = hospital.PharmacyApiKey;
            dto.Email = hospital.Email;
            return dto;
        }

        public static Hospital UpdateHospitalDtoToHospital(HospitalDto dto, Hospital hospital)
        {
            hospital.HospitalAddress = dto.HospitalAddress;
            hospital.HospitalName = dto.HospitalName;
            hospital.HospitalUrl = dto.HospitalUrl;
            hospital.HospitalApiKey = dto.HospitalApiKey;
            hospital.PharmacyApiKey = dto.PharmacyApiKey;
            hospital.Email = dto.Email;
            return hospital;
        }
    }
}
