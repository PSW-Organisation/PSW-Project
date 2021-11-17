using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class VisitReportController
	{
		private IVisitReportService visitReportService;

		public VisitReportController(IVisitReportService visitReportService)
		{
			this.visitReportService = visitReportService;
		}

		public List<VisitReport> GetDoneVisitReportsForPatient(int id)
		{
			return visitReportService.GetDoneVisitReportsForPatient(id);
		}

		public VisitReport GetVisitReportWithId(int id)
		{
			return visitReportService.GetVisitReportWithId(id);
		}

		public void CreateNewVisitReport(VisitReport visitReport)
		{
			visitReportService.CreateNewVisitReport(visitReport);
		}

		public void UpdateVisitReport(VisitReport visitReport)
		{
			visitReportService.UpdateVisitReport(visitReport);
		}
	}
}
