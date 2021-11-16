using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Repository
{
	public interface PersonalizedNotificationRepository : GenericRepository<PersonalizedNotification>
    {
        public void NotifyPatientOfCancellation(List<Account> accounts, DateTime dateTime);
    }

}
