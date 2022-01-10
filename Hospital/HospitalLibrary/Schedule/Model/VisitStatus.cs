using HospitalLibrary.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Schedule.Model
{
    public class VisitStatus : ValueObject
    {
        public int VisitId { get; }
        public bool IsReviewed { get; }
        public bool IsCanceled { get; }

        public VisitStatus() { }
        public VisitStatus(int visitId, bool isReviewed, bool isCanceled)
        {
            VisitId = visitId;
            IsReviewed = isReviewed;
            IsCanceled = isCanceled;
            Validate();
        }

        public VisitStatus(bool isReviewed, bool isCanceled)
        {
            IsReviewed = isReviewed;
            IsCanceled = isCanceled;
        }
        private void Validate()
        {
            if (IsReviewed == true && IsCanceled == true)
                throw new ArgumentException();
        }

        public VisitStatus Create(int visitId, bool isReviewed, bool isCanceled)
        {
            return new VisitStatus(visitId, isReviewed, isCanceled);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IsReviewed;
            yield return IsCanceled;
        }
    }
}
