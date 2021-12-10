using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IMedicineOrderService
    {
        public Medicine AddMedicine(Medicine medicine);
        public List<Pharmacy> searchMedicine(string medicineName, int medicineAmount);
        public PharmacyCommunicationType checkCommunicationType(string apiKey);
        public bool checkIfMedicineExistsHTTP(MedicineSearch medicineSearch);
        public bool orderMedicineHTTP(MedicineSearch medicineSearch);
    }
}
