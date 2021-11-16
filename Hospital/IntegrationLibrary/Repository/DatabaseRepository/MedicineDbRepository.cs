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
    }
}
