using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Medicines.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.Medicines.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository _medicineRepository)
        {
            this._medicineRepository = _medicineRepository;
        }

        public void DeleteMedicine(Medicine id)
        {
            _medicineRepository.Delete(id);
        }

        public IList<Medicine> GetAllMedicine()
        {
            return _medicineRepository.GetAll();
        }

        public Medicine GetMedicine(int id)
        {
            return _medicineRepository.Get(id);
        }

        public Medicine GetMedicineByName(string name)
        {
            return this._medicineRepository.GetMedicineByName(name);
        }

        public Medicine Save(Medicine medicine)
        {
            Medicine existingMedicine = this.GetMedicineByName(medicine.MedicineName);
            if (existingMedicine == null)
            {
                return addIfMedicineNotExist(medicine);

            }
            else
            {
                return IfMedicineExist(medicine, existingMedicine);
            }
        }

        private Medicine IfMedicineExist(Medicine medicine, Medicine existing)
        {
            existing.MedicineAmount = existing.MedicineAmount + medicine.MedicineAmount;
            existing.MedicineName = existing.MedicineName.First().ToString().ToUpper() + existing.MedicineName.Substring(1);
            this.Update(existing);
            return existing;
        }

        private Medicine addIfMedicineNotExist(Medicine medicine)
        {
            medicine.Id = _medicineRepository.GetNewID();
            medicine.MedicineName = medicine.MedicineName.First().ToString().ToUpper() + medicine.MedicineName.Substring(1);
            _medicineRepository.Insert(medicine);
            Medicine medicineAdded = this.GetMedicineByName(medicine.MedicineName);
            return medicine;
        }

        public void Update(Medicine medicine)
        {
            medicine.MedicineName = medicine.MedicineName.First().ToString().ToUpper() + medicine.MedicineName.Substring(1);
            _medicineRepository.Update(medicine);
        }
    }
}
