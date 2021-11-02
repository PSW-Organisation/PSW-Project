using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class FeedbackController
	{
		private FeedbackService feedbackService;
		public FeedbackController()
		{
			feedbackService = new FeedbackService();
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
