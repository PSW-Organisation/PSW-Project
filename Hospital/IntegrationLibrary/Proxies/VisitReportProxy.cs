using ehealthcare.Model;
using ehealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Proxies
{
	interface IVisitReport
	{
		public VisitReport GetVisitReport(int id);
	}

	public class VisitReportImpl : IVisitReport
	{
		VisitReportRepository visitReportRepository;
		public VisitReport GetVisitReport(int id)
		{
			
			return visitReportRepository.Get(id);
		}
	}

	public class VisitReportProxyImpl : IVisitReport
	{
		private IVisitReport visitReport;
		public VisitReport GetVisitReport(int id)
		{
			if (visitReport == null)
			{
				visitReport = new VisitReportImpl();
			}
			return visitReport.GetVisitReport(id);
		}
	}
}
