using ehealthcare.Service;
using HospitalLibrary.Model;
using System;


namespace ehealthcare.Model
{
    [Serializable]
    public class MedicalPermit : EntityDb
    {
       
        public virtual Doctor Doctor { get; set; }
       
        public String DoctorId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public MedicalPermit()
        {

        }

    }
}