using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IFeedbackService
    {
        public void AddNewBugReport(BugReport bugReport);
        public void AddNewReviewReport(ReviewReport reviewReport);
    }
}
