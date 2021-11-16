using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class HospitalReviewXMLRepository : GenericXMLRepository<HospitalReview>, HospitalReviewRepository
	{
		public HospitalReviewXMLRepository() : base("hospitalReviews.xml") { }
	}
}
