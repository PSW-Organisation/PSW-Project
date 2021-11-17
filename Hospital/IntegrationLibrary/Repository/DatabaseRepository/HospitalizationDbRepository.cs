using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class HospitalizationDbRepository : GenericDatabaseRepository<Hospitalization>, HospitalizationRepository
    {
        public HospitalizationDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
