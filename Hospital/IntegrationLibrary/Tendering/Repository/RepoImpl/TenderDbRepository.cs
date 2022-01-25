using IntegrationLibrary.Model;
using IntegrationLibrary.Repository.DatabaseRepository;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLibrary.Tendering.Repository.RepoImpl
{
    public class TenderDbRepository : GenericDatabaseRepository<Tender>, TenderRepository
    {

        private IntegrationDbContext dbContext;
        private DbSet<Tender> Tenders;

        public TenderDbRepository(IntegrationDbContext dbContext) : base(dbContext) {
            this.dbContext = dbContext;
        }

        public List<Tender> GetTenders()
        {
            Tenders = dbContext.Set<Tender>();
            var tenders = Tenders.Include(tender => tender.TenderItems).ToList();
            return tenders;
        }
    }
}
