using HospitalLibrary.Medicines.Model;
using System;


namespace ehealthcare.Model
{
    [Serializable]
    public class Prescription
    {
        private bool active;
        private HospitalLibrary.Medicines.Model.Medicine medicine;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public Medicine Medicine
        {
            get { return medicine; }
            set { medicine = value; }
        }
    }
}