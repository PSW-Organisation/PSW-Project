using System;
using System.Collections.Generic;
using Model;
using Model;
using vezba.Repository;
using vezba.Service;

namespace Service
{
    public class MedicineService
    {

        private IMedicineRepository MedicineRepository { get; }

        public MedicineService(IMedicineRepository medicineRepository)
        {
            MedicineRepository = medicineRepository;
        }
        public List<Medicine> GetApproved()
        {
            return MedicineRepository.GetApproved();
        }

        public List<Medicine> GetAwaiting()
        {
            return MedicineRepository.GetAwaiting();
        }

        public List<Medicine> GetPossibleReplacements(Medicine medicine)
        {
            List<Medicine> medicineForReplacement = GetApproved();
            foreach (var replacement in medicineForReplacement)
            {
                if (replacement.MedicineID == medicine.MedicineID)
                {
                    medicineForReplacement.Remove(replacement);
                    break;
                }
            }

            return medicineForReplacement;
        }

        public Boolean UpdateMedicine(Medicine updatedMedicine)
        {
            return MedicineRepository.Update(updatedMedicine);
        }

        public Boolean DeleteMedicine(int medicineID)
        {
            return MedicineRepository.Delete(medicineID);
        }

        public void ApproveMedicine(Medicine medicineToApprove)
        {
            medicineToApprove.Status = MedicineStatus.approved;
            UpdateMedicine(medicineToApprove);
        }

        public Medicine getMedicineById(int medicineId)
        {
            return MedicineRepository.GetOne(medicineId);
        }
        public List<Medicine> GetAllMedicine()
        {
            return MedicineRepository.GetAll();
        }

        public Boolean SaveMedicine(Medicine newMedicine)
        {
            return MedicineRepository.Save(newMedicine);
        }

    }
}
