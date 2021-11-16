using IntegrationLibrary.Model;
using IntegrationLibrary.PatientApp.ApplicationData;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Service
{
	public class TherapyService
	{
		private TherapyRepository therapyRepository;
		private int xMinutes = 5;
		private int xHours = 6;
		public class MedicineInfo
		{
			public DateTime Date { get; set; }
			public string HourAndMinute { get; set; }
			public string Quantity { get; set; }
			public string Medicine { get; set; }
		}

		public TherapyService()
		{
			therapyRepository = new TherapyXMLRepository();
		}

		/**
        * <summary>Method returns all therapies for the given patient.</summary>
        */
		public List<Therapy> GetAllTherapiesForPatient(Patient patient)
		{
			List<Therapy> therapies = therapyRepository.GetAll();
			List<Therapy> filteredTherapies = new List<Therapy>();
			if (therapies != null)
			{
				foreach (Therapy therapy in therapies)
				{
					if (therapy.Patient.Id == patient.Id)
					{
						filteredTherapies.Add(therapy);
					}
				}
			}
			return filteredTherapies;
		}

		/**
        * <summary>Method adds new Therapy to storage.</summary>
        */
		public void AddTherapyToStorage(Therapy therapy)
		{
			therapyRepository.Save(therapy);
		}

		/**
        * <summary>Method finds and returns all therapies from giver patients VisitReport.</summary>
        */
		public List<Therapy> GetTherapiesFromVisitReport(string id)
		{
			List<Therapy> therapies = therapyRepository.GetAll();
			List<Therapy> filteredTherapies = new List<Therapy>();
			if (therapies != null)
			{
				foreach (Therapy therapy in therapies)
				{
					if (therapy.VisitReportId == id)
					{
						filteredTherapies.Add(therapy);
					}
				}
			}
			return filteredTherapies;
		}

		/**
        * <summary>Method finds and returns Therapy class object by it's id.</summary>
        */
		public Therapy GetTherapyById(string id)
		{
			return therapyRepository.Get(id);
		}

		public List<MedicineInfo> GetPatientsMedicineInfosForDate(Patient patient, DateTime date)
		{
			List<Therapy> filteredTherapies = GetAllTherapiesForPatient(patient);
			List<MedicineInfo> medicineInfos = new List<MedicineInfo>();

			foreach (Therapy therapy in filteredTherapies)
			{
				DateTime startDate = new DateTime(date.Year, date.Month, date.Day, therapy.StartTime.Hour, therapy.StartTime.Minute, 0);
				double hoursDifference = Math.Abs((startDate - therapy.StartTime).TotalHours);
				DateTime closestDateTime = therapy.StartTime.AddHours(therapy.FrequencyHours * ((int)(hoursDifference / therapy.FrequencyHours)));
				if(closestDateTime.Day == startDate.Day && closestDateTime.Month == startDate.Month && closestDateTime.Year == startDate.Year)
				{
					string hour = closestDateTime.Hour.ToString();
					string minute = closestDateTime.Minute.ToString();
					if (hour.Length == 1) hour = "0" + hour;
					if (minute.Length == 1) minute = "0" + minute;
					medicineInfos.Add(
					new MedicineInfo()
					{
						Date = closestDateTime,
						HourAndMinute = hour + ":" + minute,
						Quantity = therapy.QuantityString,
						Medicine = therapy.Medicine.Name
					}); 
				}
			}
			medicineInfos.Sort((x, y) => x.Date.CompareTo(y.Date));
			return medicineInfos;
		}

		public List<Therapy> GetActiveTherapiesForPatient(Patient patient)
		{
			List<Therapy> patientsTherapies = GetAllTherapiesForPatient(patient);
			List<Therapy> filteredTherapies = new List<Therapy>();
			foreach (Therapy therapy in patientsTherapies)
			{
				if(therapy.IsActive == true)
					filteredTherapies.Add(therapy);
			}
			return filteredTherapies;
		}

		/**
        * <summary>Method generates new id for the Therapy class object.</summary>
        */
		public string GetNewId()
		{
			int newId = therapyRepository.GetAll().Count + 1;
			return newId.ToString();
		}

		/**
        * <summary>Method is being called every 5 minutes. Method checks if logged in patient has any therapies and if patient should take medicine for any therapy 5 minutes
		  from the time this method was called. For every therapy for which the medicine should be taken a new TherapyNotification is created, serialized and notification bell
		  shows new therapy notifications for patient to check out.</summary>
        */
		public void GenerateNewTherapyNotifications()
		{
			Patient loggedInPatient = (Patient)AppData.getInstance().LoggedInAccount.User;
			List<Therapy> therapies = GetAllTherapiesForPatient(loggedInPatient);
			if (therapies.Count != 0)
			{
				List<Therapy> therapiesToTake = FilterTherapiesToTakeInXMinutes(therapies);
				if(therapiesToTake.Count != 0)
				{
					List<Account> accounts = new List<Account>();
					accounts.Add(AppData.getInstance().LoggedInAccount);
					TherapyNotificationService therapyNotificationService = new TherapyNotificationService();
					foreach (Therapy therapy in therapiesToTake)
					{
						TherapyNotification therapyNotification = new TherapyNotification()
						{
							Accounts = accounts,
							Therapy = therapy,
							Date = therapy.CurrentTimeToTake,
							Subject = "Uzmite lek",
							Description = GenerateDescriptionForTherapyNotification(therapy.CurrentTimeToTake, therapy.Medicine.Name),
							MedicineTaken = false
						};
						if(!therapyNotificationService.TherapyNotificationExists(therapyNotification))
						{
							therapyNotificationService.AddTherapyNotificationToStorage(therapyNotification);
						}
						
					}
				}
			}
		}

		/**
        * <summary>Method filters the given list of therapies and returns only the therapies whose medicine should be taken in the next 5 minutes.</summary>
        */
		private List<Therapy> FilterTherapiesToTakeInXMinutes(List<Therapy> therapies)
		{
			List<Therapy> therapiesToTake = new List<Therapy>();
			DateTime dateTimeNow = DateTime.Now;
			DateTime dateTimeInXMins = dateTimeNow.AddMinutes(xMinutes);
			foreach (Therapy therapy in therapies)
			{
				if (therapy.StartTime > dateTimeNow)
				{
					if (dateTimeInXMins > therapy.StartTime)
					{
						therapiesToTake.Add(therapy);
						therapy.CurrentTimeToTake = therapy.StartTime;
						continue;
					}
				}
				if (therapy.EndTime < dateTimeNow)
				{
					continue;
				}
				if (dateTimeNow < therapy.EndTime && dateTimeNow > therapy.StartTime)
				{
					DateTime startTime = therapy.StartTime;
					while (startTime < therapy.EndTime)
					{
						startTime = startTime.AddHours(therapy.FrequencyHours);
						if (startTime > dateTimeNow)
						{
							if (dateTimeInXMins > startTime)
							{
								therapiesToTake.Add(therapy);
								therapy.CurrentTimeToTake = startTime;
								break;
							}
						}
					}
				}
			}
			return therapiesToTake;
		}

		private string GenerateDescriptionForTherapyNotification(DateTime date, string medicine)
		{
			string month = "";
			if (date.Month == 1)
			{
				month = "januara";
			}
			else if (date.Month == 2)
			{
				month = "februara";
			}
			else if (date.Month == 3)
			{
				month = "marta";
			}
			else if (date.Month == 4)
			{
				month = "aprila";
			}
			else if (date.Month == 5)
			{
				month = "maja";
			}
			else if (date.Month == 6)
			{
				month = "juna";
			}
			else if (date.Month == 7)
			{
				month = "jula";
			}
			else if (date.Month == 8)
			{
				month = "avgusta";
			}
			else if (date.Month == 9)
			{
				month = "septembra";
			}
			else if (date.Month == 10)
			{
				month = "oktobra";
			}
			else if (date.Month == 11)
			{
				month = "novembra";
			}
			else if (date.Month == 12)
			{
				month = "decembra";
			}
			return  "Podsetnik da uzmete lek " + medicine + " " + date.Day + ". " + month + " u " + date.Hour + ":" + (date.Minute < 10 ? "0" + date.Minute.ToString() : date.Minute.ToString()) + " časova.";
		}

		public List<bool> GetTherapyDays(int month, int year, Patient patient)
		{
			int daysInMonth = DateTime.DaysInMonth(year, month);
			List<bool> daysToTakeTherapy = new List<bool>();
			List<Therapy> therapies = GetAllTherapiesForPatient(patient);
			List<Therapy> filteredTherapies = FilterTherapiesForMonthAndYear(month, year, therapies);
			bool hasTherapyToday;
			for (int i = 1; i <= daysInMonth; i++)
			{
				hasTherapyToday = false;
				foreach (Therapy therapy in filteredTherapies)
				{
					DateTime startDayOfMonth = new DateTime(year, month, i, therapy.StartTime.Hour, therapy.StartTime.Minute, 0);
					DateTime endDayOfMonth = new DateTime(year, month, i, therapy.EndTime.Hour, therapy.EndTime.Minute, 0);
					if (therapy.EndTime < endDayOfMonth)
					{
						continue;
					}
					double hoursDifference = Math.Abs((startDayOfMonth - therapy.StartTime).TotalHours);
					DateTime closestDateTime = therapy.StartTime.AddHours(therapy.FrequencyHours * ((int)(hoursDifference / therapy.FrequencyHours)));
					if (closestDateTime.Day == startDayOfMonth.Day)
					{
						daysToTakeTherapy.Add(true);
						hasTherapyToday = true;
						break;
					}
				}
				if(!hasTherapyToday)
					daysToTakeTherapy.Add(false);
			}
			return daysToTakeTherapy;
		}

		/**
        * <summary>Method returns list of therapies that are active in given month and year.</summary>
        */
		private List<Therapy> FilterTherapiesForMonthAndYear(int month, int year, List<Therapy> therapies)
		{
			List<Therapy> filteredTherapies = new List<Therapy>();
			foreach (Therapy therapy in therapies)
			{
				if (therapy.StartTime.Year <= year && therapy.IsActive)
				{
					if(therapy.EndTime.Year >= year)
					{
						if(therapy.StartTime.Month <= month)
						{
							if(therapy.EndTime.Month >= month )
							{
								filteredTherapies.Add(therapy);
							}
						}
					}
				}
			}
			return filteredTherapies;
		}

		public void EraseTherapyNotifications()
		{
			TherapyNotificationService therapyNotificationService = new TherapyNotificationService();
			List<TherapyNotification> therapyNotifications = therapyNotificationService.GetTherapyNotificationsForPatient(AppData.getInstance().LoggedInAccount.User.Id);
			if(therapyNotifications.Count != 0) 
			{
				foreach (TherapyNotification therapyNotification in therapyNotifications)
				{
					if(therapyNotification.Date.AddHours(xHours) <= DateTime.Now)
					{
						therapyNotificationService.RemoveTherapyNotificationFromStorage(therapyNotification.Id);
					}
				}
			}
		}
	}
}
