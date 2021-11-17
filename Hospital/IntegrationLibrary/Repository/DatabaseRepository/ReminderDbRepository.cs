using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class ReminderDbRepository : GenericDatabaseRepository<Reminder>, ReminderRepository
    {
        public ReminderDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }
    }
}
