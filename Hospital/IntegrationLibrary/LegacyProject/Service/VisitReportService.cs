using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
	public class VisitReportService : IVisitReportService
	{
		private VisitReportRepository visitReportRepository;

		public VisitReportService(VisitReportRepository visitReportRepository)
		{
			this.visitReportRepository = visitReportRepository;
		}

        public VisitReportService()
        {
        }

        public List<VisitReport> GetDoneVisitReportsForPatient(int id)
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

		public VisitReport GetVisitReportWithId(int id)
		{
			return visitReportRepository.Get(id);
		}

		public void CreateNewVisitReport(VisitReport visitReport)
		{
			visitReportRepository.Save(visitReport);
		}

		public void UpdateVisitReport(VisitReport visitReport)
		{
			visitReportRepository.Delete(visitReport);
			visitReportRepository.Save(visitReport);
		}
	}
}
