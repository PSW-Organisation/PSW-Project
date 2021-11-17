using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class AllergenDbRepository : GenericDatabaseRepository<Allergen>, AllergenRepository

    {
        public AllergenDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
