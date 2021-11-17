using ehealthcare.Service;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehealthcare.Model
{
    [Serializable]
    [Table("Doctors")]
    public class Doctor : User
    {
        private Specialization specialization;
        private int usedOffdays;
       

        public Doctor()
        {
        }

        public Specialization Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public int UsedOffDays
        {
            get { return usedOffdays; }
            set { usedOffdays = value; }
        }

       
       
    }
}