using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class TherapyNotificationDbRepository : GenericDatabaseRepository<TherapyNotification>, TherapyNotificationRepository
    {
        public TherapyNotificationDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
