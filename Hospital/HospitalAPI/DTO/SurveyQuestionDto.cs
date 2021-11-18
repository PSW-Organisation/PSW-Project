using System;
using System.Collections.Generic;
using HospitalLibrary.FeedbackAndSurvey.Model;

namespace HospitalAPI.DTO
{
    public class SurveyQuestionDto
    {
        public string PatientId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int VisitId { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}