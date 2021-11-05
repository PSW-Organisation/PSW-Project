using ehealthcare.Model;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Service
{
    public class PatientFeedbackService
    {
        private IPatientFeedbackRepository _patientFeedbackRepository;
      
        public PatientFeedbackService(HospitalDbContext dbContext)
        {
            _patientFeedbackRepository = new PatientFeedbackDbRepository(dbContext);
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
            return _patientFeedbackRepository.GetOneById(id);
        }
    }
}
