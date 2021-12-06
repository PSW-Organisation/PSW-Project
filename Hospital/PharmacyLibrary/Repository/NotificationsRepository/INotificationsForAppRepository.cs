
using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Repository.NotificationsRepository
{
    public interface INotificationsForAppRepository 
    {

        public List<NotificationsForApp> GetAll();

       public  NotificationsForApp Get(int id);

        public NotificationsForApp Save(NotificationsForApp notification);

        public NotificationsForApp Update(NotificationsForApp notification);
        public bool Delete(int id);
        public int GenerateId();

    }
}
