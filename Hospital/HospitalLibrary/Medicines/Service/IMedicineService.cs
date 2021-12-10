using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Medicines.Service
{
    public interface IMedicineService
    {
        public Medicine GetMedicineByName(string name);

        public Medicine Save(Medicine medicine);

        public void Update(Medicine medicine);

        public Medicine GetMedicine(int id);

        public IList<Medicine> GetAllMedicine();

        public void DeleteMedicine(Medicine id);
    }
}
