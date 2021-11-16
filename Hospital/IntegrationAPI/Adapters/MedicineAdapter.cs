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
            medicine.Name = dto.Name;
            medicine.MedicineStatus = MedicineStatus.approved;
            medicine.MedicineIngredient = new List<String>();
            medicine.MedicineAmmount = dto.MedicineAmmount;
            return medicine;
        }

        public static MedicineDTO MedicineToMedicineDto(Medicine medicine)
        {
            MedicineDTO dto = new MedicineDTO();
            dto.Id = medicine.Id;
            dto.Name = medicine.Name;
            dto.MedicineAmmount = medicine.MedicineAmmount;
            return dto;
        }

        public static MedicineTransaction MedicineDtoToMedicineTransaction(MedicineDTO dto)
        {
            MedicineTransaction transaction = new MedicineTransaction();
            transaction.Id = "";
            transaction.MedicineId = dto.Id;
            transaction.MedicineAmmount = dto.MedicineAmmount;
            transaction.TransactionTime = DateTime.Now;
            return transaction;
        }
    }
}
