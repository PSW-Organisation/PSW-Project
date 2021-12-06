using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
   public  class NotificationsForAppDbRepository : GenericDatabaseRepository<NotificationsForApp>, NotificationsForAppRepository
    {
        public NotificationsForAppDbRepository(IntegrationDbContext dbContex): base(dbContex) { }
    }
}
