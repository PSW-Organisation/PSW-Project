using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Model
{
	[Serializable]
	public class BugReport : Feedback
	{
		private string title;
		private string details;
		public string Title
		{
			get { return title; }
			set { title = value; }
		}
		public string Details
		{
			get { return details; }
			set { details = value; }
		}
	}
}
