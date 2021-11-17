using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class DoctorReviewDbRepository : GenericDatabaseRepository<DoctorReview>, DoctorReviewRepository
    {
        public DoctorReviewDbRepository(IntegrationDbContext dbContext) :base(dbContext) { }
    }
}
