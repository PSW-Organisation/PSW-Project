using ehealthcare.Model;
using System;
using System.Collections.Generic;

namespace ehealthcare.Repository
{
    public interface PersonalizedNotificationRepository : GenericRepository<PersonalizedNotification>
    {
        public void NotifyPatientOfCancellation(List<Account> accounts, DateTime dateTime);
    }

}
