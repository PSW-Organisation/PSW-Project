using ehealthcare.Model;
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class GenericDatabaseRepository<T> where T : EntityDb
    {
        private readonly IntegrationDbContext dbContext;

        public GenericDatabaseRepository(IntegrationDbContext context)
        {
            this.dbContext = context;
        }

        public IList<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }
    }
}
