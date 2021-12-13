﻿using IntegrationLibrary.Proxies;
using IntegrationLibrary.Service;
using System;


namespace IntegrationLibrary.Model
{
    [Serializable]
    public class HospitalReview : Entity
    {
        private IPatient lazyPatient;
        private Patient patient;
        private DateTime ratingDate;
        private int rating;
        private string comment;

        public HospitalReview() : base(-1) 
        {
            lazyPatient = new PatientProxyImpl();
        }

        [System.Xml.Serialization.XmlIgnore]
        public Patient Patient
        {
            get
            {
                if (patient == null)
                {
                    patient = lazyPatient.GetPatient(PatientId);
                }
                return patient;
            }
            set
            {
                patient = value;
                PatientId = value.Id;
            }
        }

        public int PatientId { get; set; }

        public DateTime RatingDate
        {
            get { return ratingDate; }
            set { ratingDate = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}