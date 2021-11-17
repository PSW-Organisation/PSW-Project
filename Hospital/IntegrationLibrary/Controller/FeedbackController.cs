using ehealthcare.Model;
using ehealthcare.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class FeedbackController
	{
		private IFeedbackService feedbackService;
		public FeedbackController(IFeedbackService feedbackService)
		{
			this.feedbackService = feedbackService;
		}

		public void AddNewBugReport(BugReport bugReport)
		{
			feedbackService.AddNewBugReport(bugReport);
		}
		public void AddNewReviewReport(ReviewReport reviewReport)
		{
			feedbackService.AddNewReviewReport(reviewReport);
		}
	}
}
