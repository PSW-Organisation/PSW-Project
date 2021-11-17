using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class VisitTimeController
	{
		private VisitTimeService visitTimeService;

		public VisitTimeController()
		{
			visitTimeService = new VisitTimeService();
		}

        public List<DateTime> getFirst21AvailableDates(Doctor doctor)
        {
            return visitTimeService.getFirst21AvailableDates(doctor);
        }


        public DateTime GetNearestAvailableTimeSlot(Doctor doctor, DateTime startTime, int duration)
        {
            return visitTimeService.GetNearestAvailableTimeSlot(doctor, startTime, duration);
        }

        public VisitTime GetNearestAvailableDelay(int doctorId,int patientId, VisitTime takenTimeSlot, List<VisitTime> potentialDelays)
        {
            return visitTimeService.GetNearestAvailableDelay(doctorId, patientId, takenTimeSlot, potentialDelays);
        }

        

        public List<VisitTime> GetDoctorsVisitTimes(Doctor doctor, DateTime startTime, DateTime finishTime)
        {
            return visitTimeService.GetDoctorsVisitTimes(doctor, startTime, finishTime);
        }


        public bool IsPatientAvailable(int patientId, VisitTime visitTime)
        {
            return visitTimeService.IsPatientAvailable(patientId, visitTime);
        }

        public List<VisitTime> GetAvailableTimeSlots(int doctorId, DateTime date)
        {
            return visitTimeService.GetAvailableTimeSlots(doctorId, date);
        }

        public List<VisitTime> GetAvailableTimeSlots(int doctorId)
        {
            return visitTimeService.GetAvailableTimeSlots(doctorId);
        }

    }
}
