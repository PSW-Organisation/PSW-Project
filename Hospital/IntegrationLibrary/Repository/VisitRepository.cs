using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;

namespace IntegrationLibrary.Repository
{
    public interface VisitRepository : GenericRepository<Visit>
    {

        public List<Visit> GetPatientsVisits(String id);
        public List<Visit> CancelVisits(List<VisitTime> visitTimes, string doctorId);
    }
}
