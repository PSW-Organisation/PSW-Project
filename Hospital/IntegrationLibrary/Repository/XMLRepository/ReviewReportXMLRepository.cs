using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class ReviewReportXMLRepository : GenericXMLRepository<ReviewReport>, ReviewReportRepository
	{
		public ReviewReportXMLRepository() : base("reviewReports.xml") { }
	}
}
