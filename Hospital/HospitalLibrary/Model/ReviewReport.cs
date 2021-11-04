using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Model
{
	[Serializable]
	public class ReviewReport : Feedback
	{
		private int easyToUse;
		private int hasFeaturesIWant;
		private int isFastAndResponsive;
		private int wouldRecommentToFriend;
		private string improvementSuggestion;

		public int EasyToUse
		{
			get { return easyToUse; }
			set { easyToUse = value; }
		}
		public int HasFeaturesIWant
		{
			get { return hasFeaturesIWant; }
			set { hasFeaturesIWant = value; }
		}
		public int IsFastAndResponsive
		{
			get { return isFastAndResponsive; }
			set { isFastAndResponsive = value; }
		}
		public int WouldRecommentToFriend
		{
			get { return wouldRecommentToFriend; }
			set { wouldRecommentToFriend = value; }
		}

		public string ImprovementSuggestion
		{
			get { return improvementSuggestion; }
			set { improvementSuggestion = value; }
		}
	}
}
