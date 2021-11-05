using ehealthcare.Model;
using HospitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Controller
{
    public class PatientFeedbackController
    {
        private readonly PatientFeedbackService _patientFeedbackService;
        public PatientFeedbackController(HospitalDbContext hospitalDbContext)
        {
            _patientFeedbackService = new PatientFeedbackService(hospitalDbContext);
        }

        public void AddPatientFeedback(PatientFeedback patientFeedback)
        {
            _patientFeedbackService.AddPatientFeedback(patientFeedback);
        }

        public void UpdatePatientFeedback(PatientFeedback patientFeedback)
        {
            _patientFeedbackService.UpdatePatientFeedback(patientFeedback);
        }

        public void DeletePatientFeedback(PatientFeedback patientFeedback)
        {
            _patientFeedbackService.DeletePatientFeedback(patientFeedback);
        }

        public IEnumerable<PatientFeedback> GetAllFeedbacks()
        {
            return _patientFeedbackService.GetAllFeedbacks();
        }

        public PatientFeedback GetPatientFeedback(int id)
        {
            return _patientFeedbackService.GetPatientFeedback(id);
        }
    }
}
