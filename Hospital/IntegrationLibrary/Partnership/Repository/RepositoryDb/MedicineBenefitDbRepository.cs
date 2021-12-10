using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class MedicineBenefitDbRepository : GenericDatabaseRepository<MedicineBenefit>, MedicineBenefitRepository
    {
        public MedicineBenefitDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

    }
}
