using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class MedicineSearchAdapter
    {
        public static MedicineSearch MedicineSearchDtoToMedicineSearch(MedicineSearchDTO dto)
        {
            MedicineSearch medicine = new MedicineSearch();
            medicine.MedicineName = dto.MedicineName;
            medicine.MedicineAmount = dto.MedicineAmount;
            medicine.ApiKey = dto.ApiKey;
            return medicine;
        }

        public static MedicineSearchDTO MedicineSearchToMedicineSearchDto(MedicineSearch medicine)
        {
            MedicineSearchDTO dto = new MedicineSearchDTO();
            dto.MedicineName = medicine.MedicineName;
            dto.MedicineAmount = medicine.MedicineAmount;
            dto.ApiKey = medicine.ApiKey;
            return dto;
        }
    }
}
