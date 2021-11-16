using IntegrationLibrary.Service;
using System;

namespace IntegrationLibrary.Model
{
    public class Therapy : Entity
    {
        
        private DateTime startTime;
        private DateTime endTime;
        private DateTime currentTimeToTake = DateTime.MinValue;
        private int frequencyHours;
        private int quantity;
        private Medicine medicine;
        private Patient patient;
        private bool isActive;
        private VisitReport visitReport;

        public Therapy() : base("undefinedNumberKey")
        {

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


        [System.Xml.Serialization.XmlIgnore]
        public DateTime CurrentTimeToTake
        {
            get { return currentTimeToTake; }
            set { currentTimeToTake = value; }
        }

        public int FrequencyHours
        {
            get { return frequencyHours; }
            set { frequencyHours = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string FrequencyHoursString
        {
            get { return frequencyHours.ToString() + "h"; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string QuantityString
        {
            get { return quantity.ToString() + " ml"; }
        }

        public Medicine Medicine
        {
            get { return medicine; }
            set { medicine = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public String PatientId
        {
            get
            {
                if (patient == null)
                {
                    return null;
                }

                return patient.Id;
            }
            set
            {
                PatientService patientService = new PatientService();
                patient = patientService.GetPatientById(value);
            }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public VisitReport VisitReport
        {
            get { return visitReport; }
            set { visitReport = value; }
        }

        public string VisitReportId
        {
            get { return visitReport.Id; }
            set
            {
                VisitReportService visitReportService = new VisitReportService();
                visitReport = visitReportService.GetVisitReportWithId(value);
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string EndTimeString
        {
            get
            {
                return endTime.Day.ToString() + "." + endTime.Month.ToString() + "." + endTime.Year.ToString() + ".";
            }
        }
    }
}