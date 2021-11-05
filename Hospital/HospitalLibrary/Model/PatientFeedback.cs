﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehealthcare.Model
{
    public class PatientFeedback
    {
        public string Id { get; set; }
        public string PatientUsername { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Text { get; set; }
        public bool Anonymous { get; set; }
        public bool PublishAllowed { get; set; }
        public bool IsPublished { get; set; }

    }
}
