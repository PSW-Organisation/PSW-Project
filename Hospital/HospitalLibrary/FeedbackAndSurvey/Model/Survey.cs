using System;
using System.Collections;
using System.Collections.Generic;
using ehealthcare.Model;
using HospitalLibrary.Model;

namespace HospitalLibrary.FeedbackAndSurvey.Model
{
    public class Survey : EntityDb
    {
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public int VisitId { get; set; }
        //public virtual Visit Visit { get; set; }

        public Survey(string patientId, DateTime submissionDate, int visitId)
        {
            PatientId = patientId;
            SubmissionDate = submissionDate;
            VisitId = visitId;
        }

        public Survey()
        {
        }

    }
}