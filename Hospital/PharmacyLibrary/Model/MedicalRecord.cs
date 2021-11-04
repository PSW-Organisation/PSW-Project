using ehealthcare.Service;
using System;
using System.Collections.Generic;

namespace ehealthcare.Model
{
    [Serializable]
    public class MedicalRecord
    {
        private List<Allergen> allergens;
        private int bloodType;
        private int height;
        private int weight;
        private int healthcareCategory;
        private string profession;
        private Address workAddress;
        private Address healthcareAdress;
        private Doctor personalDoctor;


        public List<Allergen> Allergens
        {
            get
            {
                if (allergens == null)
                    allergens = new List<Allergen>();
                return allergens;
            }
            set
            {
                if (value == null)
                {
                    allergens = new List<Allergen>();
                }
                else
                {
                    allergens = value;
                }
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Doctor PersonalDoctor
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