using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.PatientApp.ApplicationData
{
	public class AppData
	{
		private static AppData instance;
		public static AppData getInstance()
		{
			if(instance == null)
			{
				instance = new AppData();
			}
			return instance;
		}

		private Account loggedInAccount;
		private bool hasUnreadNotifications;
		public event Action HasUnreadNotificationsChanged;

		public Account LoggedInAccount
		{
			get
			{
				return loggedInAccount;
			}
			set
			{
				loggedInAccount = value;
			}
		}

		public bool HasUnreadNotifications
		{
			get
			{
				return hasUnreadNotifications;
			}
			set
			{
				hasUnreadNotifications = value;
				OnHasUnreadNotificationsChanged();
			}
		}

		private void OnHasUnreadNotificationsChanged()
		{
			HasUnreadNotificationsChanged?.Invoke();
		}
	
		

	}
}
