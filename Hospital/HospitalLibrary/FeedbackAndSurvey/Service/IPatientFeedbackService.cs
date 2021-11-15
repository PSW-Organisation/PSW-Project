using System.Collections.Generic;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;

namespace HospitalLibrary.FeedbackAndSurvey.Service
{
    public interface IPatientFeedbackService
    {
        public void AddPatientFeedback(PatientFeedback patientFeedback);
        public void UpdatePatientFeedback(PatientFeedback patientFeedback);
        public void DeletePatientFeedback(PatientFeedback patientFeedback);
        public IEnumerable<PatientFeedback> GetAllFeedbacks();
        public PatientFeedback GetPatientFeedback(string id);
    }
}