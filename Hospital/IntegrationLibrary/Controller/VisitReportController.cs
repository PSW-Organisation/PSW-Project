using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class VisitReportController
	{
		private VisitReportService visitReportService;

		public VisitReportController()
		{
			visitReportService = new VisitReportService();
		}

		public List<VisitReport> GetDoneVisitReportsForPatient(String id)
		{
			return visitReportService.GetDoneVisitReportsForPatient(id);
		}

		public VisitReport GetVisitReportWithId(string id)
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
