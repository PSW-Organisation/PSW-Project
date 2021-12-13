using IntegrationLibrary.Model;
using IntegrationLibrary.Repository.DatabaseRepository;
using IntegrationLibrary.SharedModel.Model;
using IntegrationLibrary.SharedModel.Repository.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.SharedModel.Repository.RepoImpl
{
   public  class NotificationsForAppDbRepository : GenericDatabaseRepository<NotificationsForApp>, NotificationsForAppRepository
    {
        public NotificationsForAppDbRepository(IntegrationDbContext dbContex): base(dbContex) { }
    }
}
