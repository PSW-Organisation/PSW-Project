using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class VisitReportDbRepository : GenericDatabaseRepository<VisitReport>, VisitReportRepository
    {
        public VisitReportDbRepository(IntegrationDbContext dbContext): base(dbContext) {  }
    }
}
