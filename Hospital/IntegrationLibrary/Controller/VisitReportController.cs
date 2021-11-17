using ehealthcare.Model;
using ehealthcare.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
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
