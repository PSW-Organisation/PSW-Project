using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class PharmacyDbRepository : GenericDatabaseRepository<Pharmacy>, PharmacyRepository
    {
        public PharmacyDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
