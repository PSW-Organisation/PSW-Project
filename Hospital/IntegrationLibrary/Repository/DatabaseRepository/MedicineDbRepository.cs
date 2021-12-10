using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class MedicineDbRepository : GenericDatabaseRepository<Medicine>, MedicineRepository
    {
        public MedicineDbRepository(IntegrationDbContext dbContext): base(dbContext) { }

        public Medicine GetMedicineByName(string name)
        {
            foreach (Medicine medicine in this.GetAll())
            {
                if (medicine.MedicineName.Equals(name))
                    return medicine;
            }
            return null;
        }
    }
}
