using PharmacyAPI;
using PharmacyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmacyLibrary.Repository.MedicineRepository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly PharmacyDbContext pharmacyDbContext;

        public MedicineRepository(PharmacyDbContext pharmacyDbContext)
        {
            this.pharmacyDbContext = pharmacyDbContext;
        }

        public bool Add(Medicine newMedicine)
        {
            if (newMedicine.Name.Length <= 0)
            {
                return false;
            }
            int id = pharmacyDbContext.Medicines.ToList().Count > 0 ? pharmacyDbContext.Medicines.Max(medicine => medicine.Id) + 1 : 1;

            newMedicine.Id = id;
            newMedicine.MedicineStatus = MedicineStatus.waitingForApproval;
            newMedicine.Name = newMedicine.Name.First().ToString().ToUpper() + newMedicine.Name.Substring(1);

            if ( newMedicine.Quantity < 0)
            {
                newMedicine.Quantity = 0;
            }

            pharmacyDbContext.Medicines.Add(newMedicine);
            pharmacyDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Medicine medicine = pharmacyDbContext.Medicines.SingleOrDefault(medicine => medicine.Id == id);
            if (medicine == null)
            {
                return false;

            }
            else
            {
                pharmacyDbContext.Medicines.Remove(medicine);
                pharmacyDbContext.SaveChanges();
                return true;
            }
        }

        public List<Medicine> Get()
        {
            List<Medicine> result = new List<Medicine>();
            pharmacyDbContext.Medicines.ToList().ForEach(medicine => result.Add(medicine));
            return result;
        }

        public Medicine Get(int id)
        {
            Medicine medicine = pharmacyDbContext.Medicines.FirstOrDefault(medicine => medicine.Id == id);
            if (medicine == null)
            {
                return null;
            }
            else
            {
                return medicine;
            }
        }

        public bool Update(Medicine m)
        {
            Medicine medicine = pharmacyDbContext.Medicines.FirstOrDefault(medicine => medicine.Id == m.Id);
            if ((medicine == null) || (m.Name.Length <= 0) || (medicine.Quantity < 0))
            {
                return false;
            }

            if (m.Name.Length > 0)
            {
                medicine.Name = m.Name;
            }
            if (m.MedicineStatus == MedicineStatus.approved || m.MedicineStatus == MedicineStatus.disapproved || m.MedicineStatus == MedicineStatus.waitingForApproval)
            {
                medicine.MedicineStatus = m.MedicineStatus;
            }

            medicine.Name = medicine.Name.First().ToString().ToUpper() + medicine.Name.Substring(1);
            pharmacyDbContext.Update(medicine);
            pharmacyDbContext.SaveChanges();
            return true;
        }

        public Boolean CheckAvaliableQuantity(int idMedicine, int quantity)
        {
            Medicine medicine = pharmacyDbContext.Medicines.FirstOrDefault(medicine => medicine.Id == idMedicine);
            if (medicine == null || medicine.Quantity < quantity) 
            {
                return false;
            }

            return true;
        }

        public Medicine FindByName(string medicineName)
        {
            foreach (Medicine medicine in this.Get())
            {
                if (medicine.Name.ToLower().Equals(medicineName.ToLower()))
                    return medicine;
            }
            return null;
        }

        public List<Medicine> Search(string name, string useFor)
        {
            List<Medicine> medications = new List<Medicine>();
            List<Medicine> nameFilter = pharmacyDbContext.Medicines.Where(medicine => medicine.Name.ToUpper().Contains(name.ToUpper())).ToList();

            foreach (Medicine medicine in nameFilter)
            {
                foreach (string medicineUseFor in medicine.UseFor)
                {
                    if (medicineUseFor.ToUpper().Contains(useFor.ToUpper())) medications.Add(medicine);
                }
            }

            return medications;
        }
    }
}
