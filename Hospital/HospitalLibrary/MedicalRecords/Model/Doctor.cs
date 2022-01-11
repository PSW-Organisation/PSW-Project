using ehealthcare.Service;
using Newtonsoft.Json;
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
        public int RoomId { get; set; }

        public int ShiftOrder { get; set; }
       
        public virtual ICollection<Patient> Patients { get; set; }

        [JsonConstructor]
        public Doctor(string id) : base(id) { }

        public Doctor(string id, Specialization specialization, int usedOffDays) : base(id)
        {
            Specialization = specialization;
            UsedOffDays = usedOffDays;
        }
    }
}