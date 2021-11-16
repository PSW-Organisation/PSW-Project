using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;


namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class HospitalReviewDbRepository : GenericDatabaseRepository<HospitalReview>, HospitalReviewRepository
    {
        public HospitalReviewDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
