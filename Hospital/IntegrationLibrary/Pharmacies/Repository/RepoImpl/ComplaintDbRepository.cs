using IntegrationLibrary.Model;
using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Repository.RepoInterfaces;
using IntegrationLibrary.Repository.DatabaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Repository.RepoImpl
{
    public class ComplaintDbRepository : GenericDatabaseRepository<Complaint>, ComplaintRepository
    {
        public ComplaintDbRepository(IntegrationDbContext dbContext): base(dbContext) { }
    }
}
