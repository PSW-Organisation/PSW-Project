using System.Collections.Generic;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.Repository;

namespace HospitalLibrary.FeedbackAndSurvey.Repository
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        public IEnumerable<SurveyStats> GetSurveyStats();

    }
}