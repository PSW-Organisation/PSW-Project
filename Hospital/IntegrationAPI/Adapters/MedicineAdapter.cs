using IntegrationAPI.DTO;
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Adapters
{
    public class MedicineAdapter
    {
        public static Medicine MedicineDtoToMedicine(MedicineDTO dto)
        {
            Medicine medicine = new Medicine();
            medicine.Id = dto.Id;
            medicine.MedicineName = dto.MedicineName;
            medicine.MedicineStatus = MedicineStatus.approved;
            medicine.MedicineIngredient = new List<String>();
            medicine.MedicineAmount = dto.MedicineAmount;
            return medicine;
        }

        public static MedicineDTO MedicineToMedicineDto(Medicine medicine)
        {
            MedicineDTO dto = new MedicineDTO();
            dto.Id = medicine.Id;
            dto.MedicineName = medicine.MedicineName;
            dto.MedicineAmount = medicine.MedicineAmount;
            return dto;
        }

        public static MedicineTransaction MedicineDtoToMedicineTransaction(MedicineDTO dto)
        {
            MedicineTransaction transaction = new MedicineTransaction();
            transaction.Id = 0;
            transaction.MedicineId = dto.Id;
            transaction.MedicineAmmount = dto.MedicineAmount;
            transaction.TransactionTime = DateTime.Now;
            return transaction;
        }

      
    }
}
