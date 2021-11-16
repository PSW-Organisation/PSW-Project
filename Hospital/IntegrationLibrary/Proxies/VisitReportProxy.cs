using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Proxies
{
	interface IVisitReport
	{
		public VisitReport GetVisitReport(string id);
	}

	public class VisitReportImpl : IVisitReport
	{
		VisitReportRepository visitReportRepository;
		public VisitReport GetVisitReport(string id)
		{
			if (visitReportRepository == null)
				visitReportRepository = new VisitReportXMLRepository();
			return visitReportRepository.Get(id);
		}
	}

	public class VisitReportProxyImpl : IVisitReport
	{
		private IVisitReport visitReport;
		public VisitReport GetVisitReport(string id)
		{
			if (visitReport == null)
			{
				visitReport = new VisitReportImpl();
			}
			return visitReport.GetVisitReport(id);
		}
	}
}
