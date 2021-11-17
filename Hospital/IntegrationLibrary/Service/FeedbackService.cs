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
	public class FeedbackService : IFeedbackService
	{
		private BugReportRepository bugReportRepository;
		private ReviewReportRepository reviewReportRepository;
		public FeedbackService(BugReportRepository bugReportRepository, ReviewReportRepository reviewReportRepository)
		{
			this.bugReportRepository = bugReportRepository;
			this.reviewReportRepository = reviewReportRepository;
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
