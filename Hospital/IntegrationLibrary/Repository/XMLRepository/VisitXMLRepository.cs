using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class VisitXMLRepository : GenericXMLRepository<Visit>, VisitRepository
	{
		public VisitXMLRepository() : base("visits.xml") { }

        public List<Visit> CancelVisits(List<VisitTime> visitTimes, string doctorId)
        {
            List<Visit> canceledVisits = new List<Visit>();
            foreach (VisitTime visitTime in visitTimes)
            {
                foreach (Visit visit in base.GetAll())
                {
                    if (visit.DoctorId.Equals(doctorId) && visit.VisitTime.StartTime.Equals(visitTime.StartTime) && visit.VisitTime.EndTime.Equals(visitTime.EndTime))
                    {
                        visit.VisitStatus = VisitStatus.canceled;
                        canceledVisits.Add(visit);
                        break;
                    }
                }
            }
            SaveAll();

            return canceledVisits;
        }


        public List<Visit> GetPatientsVisits(String id)
        {
            List<Visit> patientsVisits = new List<Visit>();
            foreach (Visit visit in base.GetAll())
            {
                if (visit.PatientId == id)
                {
                    patientsVisits.Add(visit);
                }
            }

            return patientsVisits;
        }


    }
}
