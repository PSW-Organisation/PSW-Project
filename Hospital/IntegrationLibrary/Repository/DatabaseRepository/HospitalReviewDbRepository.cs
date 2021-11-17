using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;


namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class HospitalReviewDbRepository : GenericDatabaseRepository<HospitalReview>, HospitalReviewRepository
    {
        public HospitalReviewDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
