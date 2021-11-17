using ehealthcare.Service;
using HospitalLibrary.Model;
using System;


namespace ehealthcare.Model
{
    [Serializable]
    public class MedicalPermit : EntityDb
    {
        private Doctor doctor;
        private DateTime expirationDate;

        [System.Xml.Serialization.XmlIgnore]
        public Doctor Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public String DoctorId
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