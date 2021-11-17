using ehealthcare.Service;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ehealthcare.Model
{
    [Serializable]
    public class MedicalRecord
    {
        private Doctor personalDoctor;

        
        public virtual Patient Patient { get; set; }
       
        public string PersonalId { get; set; }
        public int BloodType { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Profession { get; set; }
        public string DoctorId { get; set; }

        
        [Key]
        public string PatientId { get; set; }


        [System.Xml.Serialization.XmlIgnore]
        public virtual Doctor PersonalDoctor
        {
            get { return personalDoctor; }
            set { personalDoctor = value; }
        }

        public String PersonalDoctorId
        {
            get
            {
                if (personalDoctor != null)
                {
                    return personalDoctor.Id;
                }

                return null;
            }
            set
            {
                DoctorService doctorService = new DoctorService();
                personalDoctor = doctorService.GetDoctorById(value);
            }
        }
    }
}