using System.ComponentModel;
using HospitalLibrary.Model;

namespace HospitalLibrary.FeedbackAndSurvey.Model
{
    public class Question
    {
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        public QuestionCategory Category { get; set; }

        public Question(){}

        public Question(int surveyId, int id, int value, QuestionCategory category)
        {
            SurveyId = surveyId;
            Id = id;
            Value = value;
            Category = category;
        }
    }
}