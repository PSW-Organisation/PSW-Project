using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
	public class VisitReportService
	{
		private VisitReportRepository visitReportRepository;

		public VisitReportService()
		{
			visitReportRepository = new VisitReportXMLRepository();
		}

		public List<VisitReport> GetDoneVisitReportsForPatient(String id)
		{
			List<VisitReport> visitReports = visitReportRepository.GetAll();
			List<VisitReport> filteredVisitReports = new List<VisitReport>();
			if (visitReports != null)
			{
				foreach (VisitReport visitReport in visitReports)
				{
					if (visitReport.PatientId == id && visitReport.ReportDate < DateTime.Now && visitReport.ReportDate != DateTime.MinValue)
					{
						filteredVisitReports.Add(visitReport);
					}
				}
			}
			filteredVisitReports.Sort((x, y) => y.ReportDate.CompareTo(x.ReportDate));
			return filteredVisitReports;
		}

		public VisitReport GetVisitReportWithId(string id)
		{
			return visitReportRepository.Get(id);
		}

		public void CreateNewVisitReport(VisitReport visitReport)
		{
			visitReportRepository.Save(visitReport);
		}

		public void UpdateVisitReport(VisitReport visitReport)
		{
			visitReportRepository.Delete(visitReport.Id);
			visitReportRepository.Save(visitReport);
		}
	}
}
