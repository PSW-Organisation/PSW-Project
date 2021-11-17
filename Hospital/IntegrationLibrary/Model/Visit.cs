using IntegrationLibrary.Proxies;
using IntegrationLibrary.Service;
using System;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Visit : Entity
    {
        private int serialNumber;
        private VisitTime visitTime;
        private VisitType visitType;
        private int price;
        private VisitStatus visitStatus;
        private PaymentMethod paymentMethod;
        private IPatient lazyPatient;
        private Patient patient;
        private IDoctor lazyDoctor;
        private Doctor doctor;
        private IRoom lazyRoom;
        private Room room;
        private IVisitReport lazyVisitReport;
        private VisitReport visitReport;
        private bool isReviewed;

        public Visit() : base(-1) 
        {
            lazyPatient = new PatientProxyImpl();
            lazyDoctor = new DoctorProxyImpl();
            lazyRoom = new RoomProxyImpl();
            lazyVisitReport = new VisitReportProxyImpl();
        }

        public int SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        public VisitTime VisitTime
        {
            get { return visitTime; }
            set { visitTime = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String VisitTimeString
        {
            get { return visitTime.ToString(); }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String VisitTimeStringDoctor
        {
            get { return visitTime.ToStringDoctor(); }
        }

        public VisitType VisitType
        {
            get { return visitType; }
            set { visitType = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String VisitTypeString
        {
            get
            {
                if (Enum.GetName(typeof(VisitType), visitType) == "examination")
                {
                    return "Pregled";
                }
                else
                {
                    return "Operacija";
                }
            }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String PriceString
        {
            get { return Price.ToString() + "$"; }
        }

        public VisitStatus VisitStatus
        {
            get { return visitStatus; }
            set { visitStatus = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public String VisitStatusString
        {
            get
            {
                if (Enum.GetName(typeof(VisitStatus), visitStatus) == "forthcoming")
                {
                    return "Predstojeći";
                }
                else if (Enum.GetName(typeof(VisitStatus), visitStatus) == "completed")
                {
                    return "Završen";
                }
                else if (Enum.GetName(typeof(VisitStatus), visitStatus) == "missed")
                {
                    return "Propušten";
                }
                else
                {
                    return "Otkazan";
                }
                
            }
        }

        public PaymentMethod PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Doctor Doctor
        {
            get 
            {
                if(doctor == null)
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

        [System.Xml.Serialization.XmlIgnore]
        public String DoctorName
        {
            get { return Doctor.Name + " " + Doctor.Surname; }
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

        [System.Xml.Serialization.XmlIgnore]
        public String PatientName
        {
            get { return Patient.Name + " " + Patient.Surname; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Room Room
        {
            get
            {
                if (room == null)
                {
                    room = lazyRoom.GetRoom(RoomId);
                }
                return room;
            }
            set
            {
                room = value;
                RoomId = value.Id;
            }
        }

        public int RoomId { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public VisitReport VisitReport
        {
            get
            {
                if (visitReport == null)
                {
                    visitReport = lazyVisitReport.GetVisitReport(base.Id);
                }
                return visitReport;
            }
            set
            {
                visitReport = value;
            }
        }

        public bool IsReviewed
        {
            get { return isReviewed; }
            set { isReviewed = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public bool CanReview
        {
            get
            {
                if (isReviewed == false && visitStatus == VisitStatus.completed)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
