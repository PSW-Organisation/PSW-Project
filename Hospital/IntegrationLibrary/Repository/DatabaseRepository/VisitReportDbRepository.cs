using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class VisitReportDbRepository : GenericDatabaseRepository<VisitReport>, VisitReportRepository
    {
        public VisitReportDbRepository(IntegrationDbContext dbContext): base(dbContext) {  }
    }
}
