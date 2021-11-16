using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class HospitalizationDbRepository : GenericDatabaseRepository<Hospitalization>, HospitalizationRepository
    {
        public HospitalizationDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
