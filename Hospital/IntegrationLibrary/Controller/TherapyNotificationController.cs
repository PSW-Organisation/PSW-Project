using ehealthcare.Model;
using ehealthcare.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class TherapyNotificationController
	{
		private ITherapyNotificationService therapyNotificationService;

		public TherapyNotificationController(ITherapyNotificationService therapyNotificationService)
		{
			this.therapyNotificationService = therapyNotificationService;
		}

		/**
        * <summary>Method adds new TherapyNotification to storage.</summary>
        */
		public void AddTherapyNotificationToStorage(TherapyNotification therapyNotification)
		{
			therapyNotificationService.AddTherapyNotificationToStorage(therapyNotification);
		}

		public List<TherapyNotification> GetTherapyNotificationsForPatient(int id)
		{
			
			return therapyNotificationService.GetTherapyNotificationsForPatient(id);
		}

		public bool TherapyNotificationExists(TherapyNotification therapyNotification)
		{
			return therapyNotificationService.TherapyNotificationExists(therapyNotification);
		}

		public void RemoveTherapyNotificationFromStorage(TherapyNotification id)
		{
			therapyNotificationService.RemoveTherapyNotificationFromStorage(id);
		}
	}
}
