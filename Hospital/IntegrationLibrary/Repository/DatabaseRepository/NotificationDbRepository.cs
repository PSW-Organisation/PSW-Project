using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public  class NotificationDbRepository : GenericDatabaseRepository<Notification>, NotificationRepository
    {   
        public NotificationDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
