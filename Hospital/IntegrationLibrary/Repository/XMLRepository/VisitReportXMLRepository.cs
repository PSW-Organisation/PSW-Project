using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class VisitReportXMLRepository : GenericXMLRepository<VisitReport>, VisitReportRepository
	{
		public VisitReportXMLRepository() : base("visitReports.xml")
		{

		}
	}
}
