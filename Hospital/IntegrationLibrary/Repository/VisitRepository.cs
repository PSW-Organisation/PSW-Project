using ehealthcare.Model;
using System;
using System.Collections.Generic;

namespace ehealthcare.Repository
{
    public interface VisitRepository : GenericRepository<Visit>
    {

        public List<Visit> GetPatientsVisits(int id);
        public List<Visit> CancelVisits(List<VisitTime> visitTimes, int doctorId);
    }
}
