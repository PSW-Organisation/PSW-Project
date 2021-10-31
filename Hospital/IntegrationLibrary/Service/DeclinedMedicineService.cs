using System;
using System.Collections.Generic;
using Model;
using vezba.Repository;

namespace Service
{
   public class DeclinedMedicineService
   {
        private IDeclinedMedicineRepository DeclinedMedicineRepository { get; }

        public DeclinedMedicineService(IDeclinedMedicineRepository declinedMedicineRepository)
        {
            DeclinedMedicineRepository = declinedMedicineRepository;
        }

        public List<DeclinedMedicine> GetAllDeclinedMedicine()
        {
            return DeclinedMedicineRepository.GetAll();
        }

        public Boolean SaveDeclinedMedicine(DeclinedMedicine declinedMedicine)
        {
            return DeclinedMedicineRepository.Save(declinedMedicine);
        }

        public Boolean DeleteDeclinedMedicine(int medicineId)
        {
            return DeclinedMedicineRepository.Delete(medicineId);
        }

    }
}