using IntegrationLibrary.Model;
using IntegrationLibrary.Repository.DatabaseRepository;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Repository.RepoImpl
{
    public class TenderItemDbRepository : GenericDatabaseRepository<TenderItem>, TenderItemRepository
    {
        public TenderItemDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
