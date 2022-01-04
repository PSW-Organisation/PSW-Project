using IntegrationLibrary.Model;
using IntegrationLibrary.Repository.DatabaseRepository;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Repository.RepoImpl
{
    public class TenderDbRepository : GenericDatabaseRepository<Tender>, TenderRepository
    {
        public TenderDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

    }
}
