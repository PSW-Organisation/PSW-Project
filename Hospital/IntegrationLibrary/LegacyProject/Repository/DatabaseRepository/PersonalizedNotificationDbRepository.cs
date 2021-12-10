using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class PersonalizedNotificationDbRepository : GenericDatabaseRepository<PersonalizedNotification>, PersonalizedNotificationRepository
    {
        public PersonalizedNotificationDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

        public void NotifyPatientOfCancellation(List<Account> accounts, DateTime dateTime)
        {
            PersonalizedNotification cancellationNotification = new PersonalizedNotification()
            {
                Subject = "Obaveštenje o otkazivanju termina",
                Description = "Poštovani,\nVaš termin koji je zakazan " + dateTime.ToString("MM/dd/yyyy") + " u " + dateTime.ToString("hh:mm tt") + " je otkazan.",
                Date = DateTime.Now,
                NotificationRole = NotificationRole.specificPatients,
                Accounts = accounts
            };

            Save(cancellationNotification);
        }
    }
}

