using ehealthcare.Service;

namespace ehealthcare.Model
{
    public class TherapyNotification : PersonalizedNotification
    {
        private Therapy therapy;
        private bool medicineTaken;

        [System.Xml.Serialization.XmlIgnore]
        public Therapy Therapy
        {
            get { return therapy; }
            set { therapy = value; }
        }

        public int TherapyId
        {
            get { return therapy.Id; }
            set
            {
                TherapyService therapyService = new TherapyService();
                therapy = therapyService.GetTherapyById(value);
            }
        }

        public bool MedicineTaken
        {
            get { return medicineTaken; }
            set { medicineTaken = value; }
        }
    }
}
