using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class ReviewReportXMLRepository : GenericXMLRepository<ReviewReport>, ReviewReportRepository
	{
		public ReviewReportXMLRepository() : base("reviewReports.xml") { }
	}
}
