using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class TherapyDbRepository : GenericDatabaseRepository<Therapy>, TherapyRepository
    {
        public TherapyDbRepository(IntegrationDbContext dbContext): base(dbContext) { }
    }
}
