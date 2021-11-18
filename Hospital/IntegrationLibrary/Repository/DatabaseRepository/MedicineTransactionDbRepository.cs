using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class MedicineTransactionDbRepository : GenericDatabaseRepository<MedicineTransaction>, MedicineTransactionRepository
    {
        public MedicineTransactionDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
