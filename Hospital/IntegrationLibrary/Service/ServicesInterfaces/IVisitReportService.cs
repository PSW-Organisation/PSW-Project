using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IVisitReportService
    {
        public List<VisitReport> GetDoneVisitReportsForPatient(int id);
        public VisitReport GetVisitReportWithId(int id);
        public void CreateNewVisitReport(VisitReport visitReport);
        public void UpdateVisitReport(VisitReport visitReport);
    }
}
