using ehealthcare.Model;
using HospitalLibrary.Repository.DbRepository;
using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Medicine = HospitalLibrary.Medicines.Model.Medicine;
using System.Linq;

namespace HospitalLibrary.Medicines.Repository
{
    public class MedicineRepository : GenericDbRepository<Medicine>, IMedicineRepository
    {
        private readonly HospitalDbContext _dbContext;
        public MedicineRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public Medicine GetMedicineByName(string name)
        {
            foreach (Medicine medicine in this.GetAll())
            {
                if (medicine.medicineName.ToLower().Equals(name.ToLower()))
                    return medicine;
            }
            return null;
        }

        public int GetNewID()
        {
            return GetAll().Count() + 1;
        }
    }
}
