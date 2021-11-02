using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class DoctorReviewXMLRepository : GenericXMLRepository<DoctorReview>, DoctorReviewRepository
	{
		public DoctorReviewXMLRepository() : base("doctorReviews.xml") { }
	}
}
