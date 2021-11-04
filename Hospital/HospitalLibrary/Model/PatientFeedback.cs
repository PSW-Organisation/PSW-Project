using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ehealthcare.Model
{
    public class PatientFeedback : Entity
    {
        public string PatientUsername { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Text { get; set; }
        public bool Anonymous { get; set; }
        public bool PublishAllowed { get; set; }
        public bool IsPublished { get; set; }

        public PatientFeedback(string id, string patientUsername, DateTime submissionDate, string text,
                                bool anonymous, bool publishAllowed, bool isPublished): base(id)
        {
            PatientUsername = patientUsername;
            SubmissionDate = submissionDate;
            Text = text;
            Anonymous = anonymous;
            PublishAllowed = publishAllowed;
            IsPublished = isPublished;
        }

        public PatientFeedback() : base("undefinedKey") { }
        
    }
}
