using System;

namespace Model
{
    public class MedicalRecord
    {
        public String HealthInsuranceNumber { get; set; }
        public String MedicalIdNumber { get; set; }

        public System.Collections.Generic.List<Ingridient> allergen;

        public MedicalRecord(string hid, string mid)
        {
            this.HealthInsuranceNumber = hid;
            this.MedicalIdNumber = mid;
        }

        public System.Collections.Generic.List<Ingridient> Allergen
        {
            get
            {
                if (allergen == null)
                    allergen = new System.Collections.Generic.List<Ingridient>();
                return allergen;
            }
            set
            {
                RemoveAllAllergen();
                if (value != null)
                {
                    foreach (Ingridient oAllergen in value)
                        AddAllergen(oAllergen);
                }
            }
        }

        public void AddAllergen(Ingridient newAllergen)
        {
            if (newAllergen == null)
                return;
            if (this.allergen == null)
                allergen = new System.Collections.Generic.List<Ingridient>();
            if (!this.allergen.Contains(newAllergen))
                this.allergen.Add(newAllergen);
        }

        public void RemoveAllergen(Ingridient oldAllergen)
        {
            if (oldAllergen == null)
                return;
            if (this.allergen != null)
                if (this.allergen.Contains(oldAllergen))
                    this.allergen.Remove(oldAllergen);
        }

        public void RemoveAllAllergen()
        {
            if (allergen != null)
                allergen.Clear();
        }

        public System.Collections.Generic.List<Anamnesis> anamnesis;

        public System.Collections.Generic.List<Anamnesis> Anamnesis
        {
            get
            {
                if (anamnesis == null)
                    anamnesis = new System.Collections.Generic.List<Anamnesis>();
                return anamnesis;
            }
            set
            {
                RemoveAllAnamnesis();
                if (value != null)
                {
                    foreach (Anamnesis oAnamnesis in value)
                        AddAnamnesis(oAnamnesis);
                }
            }
        }

        public void AddAnamnesis(Anamnesis newAnamnesis)
        {
            if (newAnamnesis == null)
                return;
            if (this.anamnesis == null)
                this.anamnesis = new System.Collections.Generic.List<Anamnesis>();
            if (!this.anamnesis.Contains(newAnamnesis))
                this.anamnesis.Add(newAnamnesis);
        }

        public void RemoveAnamnesis(Anamnesis oldAnamnesis)
        {
            if (oldAnamnesis == null)
                return;
            if (this.anamnesis != null)
                if (this.anamnesis.Contains(oldAnamnesis))
                    this.anamnesis.Remove(oldAnamnesis);
        }

        public void RemoveAllAnamnesis()
        {
            if (anamnesis != null)
                anamnesis.Clear();
        }
        public System.Collections.Generic.List<Prescription> prescription;

        public System.Collections.Generic.List<Prescription> Prescription
        {
            get
            {
                if (prescription == null)
                    prescription = new System.Collections.Generic.List<Prescription>();
                return prescription;
            }
            set
            {
                RemoveAllPrescription();
                if (value != null)
                {
                    foreach (Prescription oPrescription in value)
                        AddPrescription(oPrescription);
                }
            }
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

        public void RemoveAllPrescription()
        {
            if (prescription != null)
                prescription.Clear();
        }

        public System.Collections.Generic.List<ReferralLetter> referralLetter;

        public System.Collections.Generic.List<ReferralLetter> ReferralLetter
        {
            get
            {
                if (referralLetter == null)
                    referralLetter = new System.Collections.Generic.List<ReferralLetter>();
                return referralLetter;
            }
            set
            {
                RemoveAllReferralLetter();
                if (value != null)
                {
                    foreach (ReferralLetter oReferralLetter in value)
                        AddReferralLetter(oReferralLetter);
                }
            }
        }

        public void AddReferralLetter(ReferralLetter newReferralLetter)
        {
            if (newReferralLetter == null)
                return;
            if (this.referralLetter == null)
                this.referralLetter = new System.Collections.Generic.List<ReferralLetter>();
            if (!this.referralLetter.Contains(newReferralLetter))
                this.referralLetter.Add(newReferralLetter);
        }

        public void RemoveReferralLetter(ReferralLetter oldReferralLetter)
        {
            if (oldReferralLetter == null)
                return;
            if (this.referralLetter != null)
                if (this.referralLetter.Contains(oldReferralLetter))
                    this.referralLetter.Remove(oldReferralLetter);
        }

        public void RemoveAllReferralLetter()
        {
            if (referralLetter != null)
                referralLetter.Clear();
        }

        public System.Collections.Generic.List<HospitalTreatment> hospitalTreatment;

        public System.Collections.Generic.List<HospitalTreatment> HospitalTreatment
        {
            get
            {
                if (hospitalTreatment == null)
                    hospitalTreatment = new System.Collections.Generic.List<HospitalTreatment>();
                return hospitalTreatment;
            }
            set
            {
                RemoveAllHospitalTreatment();
                if (value != null)
                {
                    foreach (HospitalTreatment oHospitalTreatment in value)
                        AddHospitalTreatment(oHospitalTreatment);
                }
            }
        }

        public void AddHospitalTreatment(HospitalTreatment newHospitalTreatment)
        {
            if (newHospitalTreatment == null)
                return;
            if (this.hospitalTreatment == null)
                this.hospitalTreatment = new System.Collections.Generic.List<HospitalTreatment>();
            if (!this.hospitalTreatment.Contains(newHospitalTreatment))
                this.HospitalTreatment.Add(newHospitalTreatment);
        }

        public void RemoveHospitalTreatment(HospitalTreatment oldHospitalTreatment)
        {
            if (oldHospitalTreatment == null)
                return;
            if (this.hospitalTreatment != null)
                if (this.hospitalTreatment.Contains(oldHospitalTreatment))
                    this.hospitalTreatment.Remove(oldHospitalTreatment);
        }

        public void RemoveAllHospitalTreatment()
        {
            if (hospitalTreatment != null)
                hospitalTreatment.Clear();
        }
    }
}