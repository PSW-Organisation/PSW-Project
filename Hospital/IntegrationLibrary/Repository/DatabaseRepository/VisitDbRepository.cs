using System;
using System.Collections.Generic;
using System.Text;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class VisitDbRepository : GenericDatabaseRepository<Visit>, VisitRepository
    {
        public VisitDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

        public List<Visit> CancelVisits(List<VisitTime> visitTimes, int doctorId)
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

        public List<Visit> GetPatientsVisits(int id)
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
