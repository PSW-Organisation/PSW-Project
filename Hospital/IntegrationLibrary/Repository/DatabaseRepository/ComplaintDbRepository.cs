using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class ComplaintDbRepository : GenericDatabaseRepository<Complaint>, ComplaintRepository
    {
        public ComplaintDbRepository(IntegrationDbContext dbContext): base(dbContext) { }
    }
}
