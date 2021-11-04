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
	public class FeedbackService
	{
		private BugReportRepository bugReportRepository;
		private ReviewReportRepository reviewReportRepository;
		public FeedbackService()
		{
			bugReportRepository = new BugReportXMLRepository();
			reviewReportRepository = new ReviewReportXMLRepository();
		}

		public void AddNewBugReport(BugReport bugReport)
		{
			bugReportRepository.Save(bugReport);
		}

		public void AddNewReviewReport(ReviewReport reviewReport)
		{
			reviewReportRepository.Save(reviewReport);
		}
	}
}
