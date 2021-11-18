using ehealthcare.Model;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.FeedbackAndSurvey.Repository;

namespace HospitalLibrary.FeedbackAndSurvey.Service
{
    public class PatientFeedbackService: IPatientFeedbackService
    {
        private readonly IPatientFeedbackRepository _patientFeedbackRepository;
      
        public PatientFeedbackService(IPatientFeedbackRepository feedbackRepository)
        {
            _patientFeedbackRepository = feedbackRepository;
        }

        public void AddPatientFeedback(PatientFeedback patientFeedback) 
        {
            _patientFeedbackRepository.Insert(patientFeedback);
        }

        public void UpdatePatientFeedback(PatientFeedback patientFeedback) 
        {
            _patientFeedbackRepository.Update(patientFeedback);
        }

        public void DeletePatientFeedback(PatientFeedback patientFeedback)
        {
            _patientFeedbackRepository.Delete(patientFeedback);
        }

        public IEnumerable<PatientFeedback> GetAllFeedbacks()
        {
            return _patientFeedbackRepository.GetAll();
        }

        public PatientFeedback GetPatientFeedback(int id) 
        {
            return _patientFeedbackRepository.Get(id);
        }
    }
}
