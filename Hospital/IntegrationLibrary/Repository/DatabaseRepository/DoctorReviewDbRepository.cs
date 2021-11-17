using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class DoctorReviewDbRepository : GenericDatabaseRepository<DoctorReview>, DoctorReviewRepository
    {
        public DoctorReviewDbRepository(IntegrationDbContext dbContext) :base(dbContext) { }
    }
}
