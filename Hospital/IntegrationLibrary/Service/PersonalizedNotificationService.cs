using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
	public class PersonalizedNotificationService : IPersonalizedNotificationService
    {
		private PersonalizedNotificationRepository personalizedNotificationRepository;

		public PersonalizedNotificationService(PersonalizedNotificationRepository personalizedNotificationRepository)
		{
            this.personalizedNotificationRepository = personalizedNotificationRepository;
		}

		/**
        * <summary>Method returns all personalized notifications for the given account.</summary>
        */
		public List<PersonalizedNotification> GetAllPersonalizedNotificationsForAccount(int username)
		{
			List<PersonalizedNotification> personalizedNotifications = personalizedNotificationRepository.GetAll();
			List<PersonalizedNotification> filteredPersonalizedNotifications = new List<PersonalizedNotification>();

			foreach (PersonalizedNotification personalizedNotification in personalizedNotifications)
			{
				foreach(Account account in personalizedNotification.Accounts)
				{
					if(account.Id == username)
					{
						filteredPersonalizedNotifications.Add(personalizedNotification);
					}
				}
			}

			return filteredPersonalizedNotifications;
		}

        public List<PersonalizedNotification> GetAllPersonalizedNotifications()
        {
            List<PersonalizedNotification> allNotifications = personalizedNotificationRepository.GetAll();
            if (allNotifications == null)
            {
                allNotifications = new List<PersonalizedNotification>();
            }

            return allNotifications;
        }

        public void CreatePersonalizedNotification(PersonalizedNotification newNotification)
        {
            personalizedNotificationRepository.Save(newNotification);
        }

        public void UpdatePersonalizedNotification(Notification oldNotification, PersonalizedNotification updatedNotification)
        {
            List<PersonalizedNotification> allNotifications = personalizedNotificationRepository.GetAll();
            int index = GetIndex(oldNotification);
            if (index != -1)
            {
                allNotifications.ElementAt(index).Subject = updatedNotification.Subject;
                allNotifications.ElementAt(index).Date = updatedNotification.Date;
                allNotifications.ElementAt(index).Description = updatedNotification.Description;
                allNotifications.ElementAt(index).Accounts = updatedNotification.Accounts;
            }

            personalizedNotificationRepository.SaveAll();
        }

        public void DeletePersonalizedNotification(Notification notification)
        {
            List<PersonalizedNotification> allNotifications = personalizedNotificationRepository.GetAll();
            int index = GetIndex(notification);

            if (index != -1)
            {
                allNotifications.RemoveAt(index);
            }

            personalizedNotificationRepository.SaveAll();
        }

        private int GetIndex(Notification notification)
        {
            int index = -1;
            List<PersonalizedNotification> allNotificaitons = personalizedNotificationRepository.GetAll();
            foreach (PersonalizedNotification n in allNotificaitons)
            {
                if (notification.Subject == n.Subject && notification.Description == n.Description && notification.NotificationRole == n.NotificationRole && notification.Date == n.Date)
                {
                    index = allNotificaitons.IndexOf(n);
                }
            }
            return index;
        }
    }
}
