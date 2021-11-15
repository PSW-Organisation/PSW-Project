using ehealthcare.Model;
using ehealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;
using HospitalLibrary.Repository.DbRepository;

namespace HospitalLibrary.FeedbackAndSurvey.Repository
{
    public class PatientFeedbackDbRepository : GenericDbRepository<PatientFeedback>, IPatientFeedbackRepository
    {

        public PatientFeedbackDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
