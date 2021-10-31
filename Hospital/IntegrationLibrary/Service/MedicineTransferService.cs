using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Repository;

namespace vezba.Service
{
    class MedicineTransferService
    {
        private IMedicineRepository MedicineRepository { get; }
        private IDeclinedMedicineRepository DeclinedMedicineRepository { get; }

        public MedicineTransferService(IMedicineRepository medicineRepository, IDeclinedMedicineRepository declinedMedicineRepository)
        {
            MedicineRepository = medicineRepository;
            DeclinedMedicineRepository = declinedMedicineRepository;
        }

        public DeclinedMedicine DeclineMedicine(Medicine medicineToDecline, String description)
        {
            var declinedMedicine = new DeclinedMedicine(0, medicineToDecline, description);
            MedicineRepository.Delete(medicineToDecline.MedicineID);
            DeclinedMedicineRepository.Save(declinedMedicine);
            return declinedMedicine;
        }
    }
}
