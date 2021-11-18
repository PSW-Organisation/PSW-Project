using ehealthcare.Service;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehealthcare.Model
{
    [Serializable]
    [Table("Doctors")]
    public class Doctor : User
    {
        public Specialization Specialization { get; set; }
        
        public int UsedOffDays { get; set; }

        public Doctor() { }
       
    }
}