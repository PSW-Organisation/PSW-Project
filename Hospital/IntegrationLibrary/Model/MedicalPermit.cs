using IntegrationLibrary.Service;
using System;


namespace IntegrationLibrary.Model
{
    [Serializable]
    public class MedicalPermit
    {
        private Doctor doctor;
        private DateTime expirationDate;

        [System.Xml.Serialization.XmlIgnore]
        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public int DoctorId
        {
            get { return doctor.Id; }
            set
            {
                DoctorService doctorService = new DoctorService();
                doctor = doctorService.GetDoctorById(value);
            }
        }

        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }
    }
}