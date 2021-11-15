using ehealthcare.Model;
using ehealthcare.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.Repository;

namespace HospitalLibrary.FeedbackAndSurvey.Repository
{
    public interface IPatientFeedbackRepository : IGenericRepository<PatientFeedback>
    {
    }
}
