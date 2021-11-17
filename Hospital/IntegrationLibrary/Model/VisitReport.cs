using ehealthcare.Service;
using System;
using System.Collections.Generic;

namespace ehealthcare.Model
{   
    [Serializable]
    public class VisitReport : Entity
    {
        private DateTime reportDate;
        private Patient patient;
        private String anamnesis;
        private Diagnosis diagnosis;
        private List<Prescription> prescription;
        private string patientNote;

        public VisitReport() : base(-1) { }

        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public int PatientId
        {
            get { return patient.Id; }
            set
            {
                PatientService patientService = new PatientService();
                patient = patientService.GetPatientById(value);
            }
        }

        public String Anamnesis
        {
            get { return anamnesis; }
            set { anamnesis = value; }
        }

        public Diagnosis Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        public List<Prescription> Prescriptions
        {
            get
            {
                if (prescription == null)
                    prescription = new List<Prescription>();
                return prescription;
            }
            set { prescription = value; }
        }

        public void AddPrescription(Prescription newPrescription)
        {
            if (newPrescription == null)
                return;
            if (this.prescription == null)
                this.prescription = new System.Collections.Generic.List<Prescription>();
            if (!this.prescription.Contains(newPrescription))
                this.prescription.Add(newPrescription);
        }

        public void RemovePrescription(Prescription oldPrescription)
        {
            if (oldPrescription == null)
                return;
            if (this.prescription != null)
                if (this.prescription.Contains(oldPrescription))
                    this.prescription.Remove(oldPrescription);
        }

        public void RemoveAllPrescriptions()
        {
            if (prescription != null)
                prescription.Clear();
        }

        public string PatientNote
        {
            get { return patientNote; }
            set { patientNote = value; }
        }

        [System.Xml.Serialization.XmlIgnore]
        public string ReportDateString
        {
            get { return "Pregled " + reportDate.Day + "." + reportDate.Month + "." + reportDate.Year + "."; }
        }
    }
}
