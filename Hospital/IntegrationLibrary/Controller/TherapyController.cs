using ehealthcare.Model;
using ehealthcare.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ehealthcare.Service.TherapyService;

namespace ehealthcare.Controller
{
	public class TherapyController
	{
		private ITherapyService therapyService;
		
		public TherapyController(ITherapyService therapyService)
		{
			this.therapyService = therapyService;
		}

		/**
        * <summary>Method returns all therapies for the given patient.</summary>
        */
		public List<Therapy> GetAllTherapiesForPatient(Patient patient)
		{
			return therapyService.GetAllTherapiesForPatient(patient);
		}

		/**
        * <summary>Method adds new Therapy to storage.</summary>
        */
		public void AddTherapyToStorage(Therapy therapy)
		{
			therapyService.AddTherapyToStorage(therapy);
		}

		/**
        * <summary>Method finds and returns all therapies from giver patients VisitReport.</summary>
        */
		public List<Therapy> GetTherapiesFromVisitReport(int id)
		{
			return therapyService.GetTherapiesFromVisitReport(id);
		}

		/**
        * <summary>Method finds and returns Therapy class object by it's id.</summary>
        */
		public Therapy GetTherapyById(int id)
		{
			return therapyService.GetTherapyById(id);
		}

		public List<MedicineInfo> GetPatientsMedicineInfosForDate(Patient patient, DateTime date)
		{
			return therapyService.GetPatientsMedicineInfosForDate(patient, date);
		}

		/**
        * <summary>Method generates new id for the Therapy class object.</summary>
        */
		public string GetNewId()
		{
			return therapyService.GetNewId();
		}

		/**
        * <summary>Method is being called every 5 minutes. Method checks if logged in patient has any therapies and if patient should take medicine for any therapy 5 minutes
		  from the time this method was called. For every therapy for which the medicine should be taken a new TherapyNotification is created, serialized and notification bell
		  shows new therapy notifications for patient to check out.</summary>
        */
		public void GenerateNewTherapyNotifications()
		{
			therapyService.GenerateNewTherapyNotifications();
		}

		public List<bool> GetTherapyDays(int month, int year, Patient patient)
		{
			return therapyService.GetTherapyDays(month, year, patient);
		}

		public void EraseTherapyNotifications()
		{
			therapyService.EraseTherapyNotifications();
		}

		public List<Therapy> GetActiveTherapiesForPatient(Patient patient)
		{
			return therapyService.GetActiveTherapiesForPatient(patient);
		}
	}
}
