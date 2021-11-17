using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehealthcare.Model
{
    [Serializable]
    [Table("Patients")]
    public class Patient : User
    {
        private MedicalRecord medicalRecord;
        private List<MedicalPermit> medicalPermit;

        public Patient()
        {
        }


        public virtual MedicalRecord Medical
        {
            get { return medicalRecord; }
            set { medicalRecord = value; }
        }

        public int MedicalRecordId { get; set; }

        public virtual ICollection<MedicalPermit> MedicalPermit
        {
            get
            {
                if (medicalPermit == null)
                    medicalPermit = new List<MedicalPermit>();
                return medicalPermit;
            }
            set
            {
                RemoveAllMedicalPermit();
                if (value != null)
                {
                    foreach (MedicalPermit oMedicalPermit in value)
                        AddMedicalPermit(oMedicalPermit);
                }
            }
        }

        public void AddMedicalPermit(MedicalPermit newMedicalPermit)
        {
            if (newMedicalPermit == null)
                return;
            if (this.medicalPermit == null)
                this.medicalPermit = new List<MedicalPermit>();
            if (!this.medicalPermit.Contains(newMedicalPermit))
                this.medicalPermit.Add(newMedicalPermit);
        }

        public void RemoveMedicalPermit(MedicalPermit oldMedicalPermit)
        {
            if (oldMedicalPermit == null)
                return;
            if (this.medicalPermit != null)
                if (this.medicalPermit.Contains(oldMedicalPermit))
                    this.medicalPermit.Remove(oldMedicalPermit);
        }

        public void RemoveAllMedicalPermit()
        {
            if (medicalPermit != null)
                medicalPermit.Clear();
        }
    }
}