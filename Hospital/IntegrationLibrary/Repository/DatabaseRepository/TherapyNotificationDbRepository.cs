using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class TherapyNotificationDbRepository : GenericDatabaseRepository<TherapyNotification>, TherapyNotificationRepository
    {
        public TherapyNotificationDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
