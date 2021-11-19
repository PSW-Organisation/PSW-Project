using ehealthcare.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehealthcare.Model
{
    [Serializable]
    [Table("Doctors")]
    public class Doctor : User
    {
        public Specialization Specialization { get; set; }
        
        public int UsedOffDays { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public Doctor() { }

        public Doctor(Specialization specialization, int usedOffDays)
        {
            Specialization = specialization;
            UsedOffDays = usedOffDays;
        }
    }
}