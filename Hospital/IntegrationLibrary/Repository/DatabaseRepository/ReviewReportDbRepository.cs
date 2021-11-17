using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class ReviewReportDbRepository : GenericDatabaseRepository<ReviewReport>, ReviewReportRepository
    {
        public ReviewReportDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
