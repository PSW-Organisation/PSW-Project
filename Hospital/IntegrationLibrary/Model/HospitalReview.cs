using ehealthcare.Proxies;
using ehealthcare.Service;
using System;


namespace ehealthcare.Model
{
    [Serializable]
    public class HospitalReview : Entity
    {
        private IPatient lazyPatient;
        private Patient patient;
        private DateTime ratingDate;
        private int rating;
        private string comment;

        public HospitalReview() : base("undefinedNumberKey") 
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

        public String PatientId { get; set; }

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