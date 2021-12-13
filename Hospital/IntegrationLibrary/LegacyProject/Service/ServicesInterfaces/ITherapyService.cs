using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static IntegrationLibrary.Service.TherapyService;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface ITherapyService
    {
        public List<Therapy> GetAllTherapiesForPatient(Patient patient);
        public void AddTherapyToStorage(Therapy therapy);
        public List<Therapy> GetTherapiesFromVisitReport(int id);
        public Therapy GetTherapyById(int id);
        public List<MedicineInfo> GetPatientsMedicineInfosForDate(Patient patient, DateTime date);
        public List<Therapy> GetActiveTherapiesForPatient(Patient patient);
        public string GetNewId();
        public void GenerateNewTherapyNotifications();
        public List<bool> GetTherapyDays(int month, int year, Patient patient);
        public void EraseTherapyNotifications();

    }
}
