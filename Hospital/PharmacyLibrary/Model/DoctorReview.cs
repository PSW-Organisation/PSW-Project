﻿using ehealthcare.Proxies;
using ehealthcare.Service;
using System;

namespace ehealthcare.Model
{
    [Serializable]
    public class DoctorReview : Entity
    {
        private IVisit lazyVisit;
        private Visit visit;
        private DateTime ratingDate;
        private int rating;
        private string comment;

        public DoctorReview() : base("undefinedKey")
        {
            lazyVisit = new VisitProxyImpl();
        }

        [System.Xml.Serialization.XmlIgnore]
        public Visit Visit
        {
            get
            {
                if (visit == null)
                {
                    visit = lazyVisit.GetVisit(base.Id);
                }
                return visit;
            }
            set
            {
                visit = value;
                base.Id = value.Id;
            }
        }

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