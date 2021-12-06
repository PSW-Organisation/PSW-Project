using PharmacyLibrary.Model;
using PharmacyAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PharmacyLibrary.Repository.NotificationsRepository
{
    public class NotificationsForAppRepository : INotificationsForAppRepository
    {
        private readonly PharmacyDbContext pharmacyDbContext;

        public NotificationsForAppRepository(PharmacyDbContext dbContext)
        {
            this.pharmacyDbContext = dbContext;
        }

        public bool Delete(int id)
        {
            NotificationsForApp notification = pharmacyDbContext.Notifications.SingleOrDefault(notification => notification.Id == id);
            if (notification == null)
            {
                return false;
            }
            else
            {
                pharmacyDbContext.Notifications.Remove(notification);
                pharmacyDbContext.SaveChanges();
                return true ;
            }
        }

      

        public int GenerateId()
        {
            int maxId = 0;
            foreach (NotificationsForApp entity in pharmacyDbContext.Set<NotificationsForApp>().ToList())
            {
                try
                {
                    int maxCandidate = Convert.ToInt32(entity.Id);
                    if (maxCandidate > maxId)
                    {
                        maxId = maxCandidate;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return (maxId + 1);
        }

        public NotificationsForApp Get(int id)
        {
            NotificationsForApp notification = pharmacyDbContext.Notifications.FirstOrDefault(notification => notification.Id == id);
            if(notification == null)
            {
                return null;
            }
            else
            {
                return notification;
            }
        }

        public List<NotificationsForApp> GetAll()
        {
            List<NotificationsForApp> notifications = new List<NotificationsForApp>();
            pharmacyDbContext.Notifications.ToList().ForEach(notification => notifications.Add(notification));
            return notifications;
        }

        public NotificationsForApp Save(NotificationsForApp notification)
        {
            pharmacyDbContext.Set<NotificationsForApp>().Add(notification);
            pharmacyDbContext.SaveChanges();
            return notification;
        }

        

        public NotificationsForApp Update(NotificationsForApp notification)
        {
            NotificationsForApp note = this.Get(notification.Id);
            if(note == null)
            {
                return null;
            }
            else
            {
                pharmacyDbContext.Entry(note).CurrentValues.SetValues(notification);
                pharmacyDbContext.SaveChanges();
                return notification;
            }
        }
    }
}
