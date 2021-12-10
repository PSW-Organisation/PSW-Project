using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Medicines.Repository
{
    public interface IMedicineRepository : IGenericRepository<Medicine>
    {
        public int GetNewID();
        public Medicine GetMedicineByName(string name);
    }
}
