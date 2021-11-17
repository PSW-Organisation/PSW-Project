using ehealthcare.Model;
using ehealthcare.PatientApp.ApplicationData;
using ehealthcare.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
	public class ReminderService : IReminderService
	{

		private ReminderRepository reminderRepository;
		private PersonalizedNotificationRepository personalizedNotificationRepository;

		public ReminderService(ReminderRepository reminderRepository, PersonalizedNotificationRepository personalizedNotificationRepository)
		{
			this.reminderRepository = reminderRepository;
			this.personalizedNotificationRepository = personalizedNotificationRepository;
		}

		public void CreateNewReminder(Reminder reminder)
		{
			reminderRepository.Save(reminder);
		}

		public void GenerateNewNoteNotifications()
		{
			List<Reminder> reminders = GetAllRemindersForAccount(AppData.getInstance().LoggedInAccount.Id);
			DateTime timeNow = DateTime.Now;
			foreach (Reminder reminder in reminders)
			{
				if(reminder.StartTime > DateTime.Now)
				{
					continue;
				} 
				else
				{
					if(reminder.Minute == timeNow.Minute)
					{
						if(reminder.Hour == timeNow.Hour)
						{
							if (reminder.Days.Contains(timeNow.DayOfWeek))
							{
								List<Account> accounts = new List<Account>();
								accounts.Add(AppData.getInstance().LoggedInAccount);
								personalizedNotificationRepository.Save(
									new PersonalizedNotification()
									{
										Accounts = accounts,
										Date = timeNow,
										Subject = reminder.Title,
										Description = reminder.Description,
										NotificationRole = NotificationRole.patient
									}
								);
							} 
							else
							{
								continue;
							}
						} 
						else
						{
							continue;
						}
					}
					else
					{
						continue;
					}
				}
			}
		}

		public List<Reminder> GetAllRemindersForAccount(int username)
		{
			List<Reminder> reminders = reminderRepository.GetAll();
			List<Reminder> filteredReminders = new List<Reminder>();
			if (reminders != null)
			{
				foreach (Reminder reminder in reminders)
				{
					if (reminder.AccountUsername == username)
					{
						filteredReminders.Add(reminder);
					}
				}
			}
			return filteredReminders;
		}
	}
}
