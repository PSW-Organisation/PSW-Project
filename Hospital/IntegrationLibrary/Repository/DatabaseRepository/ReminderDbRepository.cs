using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class ReminderDbRepository : GenericDatabaseRepository<Reminder>, ReminderRepository
    {
        public ReminderDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
