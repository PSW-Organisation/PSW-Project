using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
	public class TherapyNotificationService : ITherapyNotificationService
	{
		private TherapyNotificationRepository therapyNotificationRepository;

		public TherapyNotificationService(TherapyNotificationRepository therapyNotificationRepository)
		{
			this.therapyNotificationRepository = therapyNotificationRepository;
		}

		/**
        * <summary>Method adds new TherapyNotification to storage.</summary>
        */
		public void AddTherapyNotificationToStorage(TherapyNotification therapyNotification)
		{
			therapyNotificationRepository.Save(therapyNotification);
		}

		public List<TherapyNotification> GetTherapyNotificationsForPatient(int id)
		{
			List<TherapyNotification> therapyNotifications = therapyNotificationRepository.GetAll();
			List<TherapyNotification> filteredTherapyNotifications = new List<TherapyNotification>();
			if (therapyNotifications != null)
			{
				foreach (TherapyNotification therapyNotification in therapyNotifications)
				{
					if (therapyNotification.Therapy.PatientId == id)
					{
						filteredTherapyNotifications.Add(therapyNotification);
					}
				}
			}
			return filteredTherapyNotifications;
		}

		public bool TherapyNotificationExists(TherapyNotification therapyNotification)
		{
			List<TherapyNotification> therapyNotifications = therapyNotificationRepository.GetAll();
			foreach (TherapyNotification notification in therapyNotifications)
			{
				if(notification.Date == therapyNotification.Date && notification.Therapy.Medicine.Id == therapyNotification.Therapy.Medicine.Id)
				{
					return true;
				}
			}
			return false;
		}

		public void RemoveTherapyNotificationFromStorage(TherapyNotification id)
		{
			therapyNotificationRepository.Delete(id);
		}
	}
}
