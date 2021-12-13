using IntegrationLibrary.Model;
using IntegrationLibrary.Parnership.Model;
using IntegrationLibrary.Parnership.Repository.RepoInterfaces;
using IntegrationLibrary.Repository.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Parnership.Repository.RepoImpl
{
    public class MedicineTransactionDbRepository : GenericDatabaseRepository<MedicineTransaction>, MedicineTransactionRepository
    {
        public MedicineTransactionDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
