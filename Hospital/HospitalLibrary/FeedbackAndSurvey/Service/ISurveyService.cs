using System.Collections.Generic;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.Repository;

namespace HospitalLibrary.FeedbackAndSurvey.Service
{
    public interface ISurveyService
    {
        public void AddSurvey(Survey survey);
        public void AddQuestion(Question question);
        public IEnumerable<Survey> GetAllSurveys();
        public IEnumerable<Question> GetAllQuestions();
        public IEnumerable<SurveyStats> GetSurveyStats();
    }
}