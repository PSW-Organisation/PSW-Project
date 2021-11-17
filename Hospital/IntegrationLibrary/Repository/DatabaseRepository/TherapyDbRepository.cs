using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class TherapyDbRepository : GenericDatabaseRepository<Therapy>, TherapyRepository
    {
        public TherapyDbRepository(IntegrationDbContext dbContext): base(dbContext) { }
    }
}
