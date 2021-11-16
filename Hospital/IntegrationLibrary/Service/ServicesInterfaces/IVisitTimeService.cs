using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IVisitTimeService
    {
        public List<DateTime> getFirst21AvailableDates(Doctor doctor);
        public DateTime GetNearestAvailableTimeSlot(Doctor doctor, DateTime startTime, int duration);
        public VisitTime GetNearestAvailableDelay(int doctorId, int patientId, VisitTime takenTimeSlot, List<VisitTime> potentialDelays);
        public List<VisitTime> GetDoctorsVisitTimes(Doctor doctor, DateTime startTime, DateTime finishTime);
        public bool IsPatientAvailable(int patientId, VisitTime visitTime);
        public List<VisitTime> GetAvailableTimeSlots(int doctorId, DateTime date);
        public List<VisitTime> GetAvailableTimeSlots(int doctorId);
    }
}
