using ehealthcare.Proxies;
using ehealthcare.Service;
using System;
using System.Collections.Generic;


namespace ehealthcare.Model
{
    [Serializable]
    public class Workday : Entity
    {
        private DateTime startTime;
        private DateTime endTime;
        private List<VisitTime> visitTimes;
        private IDoctor lazyDoctor;
        private Doctor doctor;

        public Workday() : base(-1) 
        {
            lazyDoctor = new DoctorProxyImpl();
        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public List<VisitTime> VisitTimes
        {
            get { return visitTimes; }
            set { visitTimes = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Doctor Doctor
        {
            get
            {
                if (doctor == null)
                {
                    doctor = lazyDoctor.GetDoctor(DoctorId);
                }
                return doctor;
            }
            set
            {
                doctor = value;
                DoctorId = value.Id;
            }
        }

        public int DoctorId { get; set; }

        public bool IsInWorkTime(DateTime start, DateTime end) 
        {
            return this.StartTime <= start && this.EndTime >= end;
        }

        public bool IsOverlapping(DateTime start, DateTime end)
        {
            foreach (VisitTime visitTime in this.VisitTimes)
            {
                if (visitTime.Overlaps(start, end))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return startTime.ToString("t") + "-" + endTime.ToString("t");
        }

    }
}