using System.Collections.Generic;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;

namespace HospitalLibrary.FeedbackAndSurvey.Service
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public void AddSurvey(Survey survey)
        {
            _surveyRepository.Insert(survey);
        }

        public void AddQuestion(Question question)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Survey> GetAllSurveys()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SurveyStats> GetSurveyStats()
        {
            return _surveyRepository.GetSurveyStats();
        }
    }
}