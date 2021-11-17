using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public  class NotificationDbRepository : GenericDatabaseRepository<Notification>, NotificationRepository
    {   
        public NotificationDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
