using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class ReviewReportDbRepository : GenericDatabaseRepository<ReviewReport>, ReviewReportRepository
    {
        public ReviewReportDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
