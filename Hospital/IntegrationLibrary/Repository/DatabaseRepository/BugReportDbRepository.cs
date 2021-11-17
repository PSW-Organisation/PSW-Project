using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class BugReportDbRepository : GenericDatabaseRepository<BugReport>, BugReportRepository
    {
        public BugReportDbRepository(IntegrationDbContext dbContext) :base(dbContext) { }
    }
}
