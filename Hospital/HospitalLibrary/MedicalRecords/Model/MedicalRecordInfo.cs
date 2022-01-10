using HospitalLibrary.Model;
using HospitalLibrary.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HospitalLibrary.MedicalRecords.Model
{
    public class MedicalRecordInfo : ValueObject
    {
        public string MedicalRecordId { get; }
        public string PersonalId { get; }
        public BloodType BloodType { get; }
        public int Height { get; }
        public int Weight { get; }
        public string Profession { get; }

        public MedicalRecordInfo() { }
        public MedicalRecordInfo(string medicalRecordId, string personalId, BloodType bloodType, int height, int weight, string profession)
        {
            MedicalRecordId = medicalRecordId;
            PersonalId = personalId;
            BloodType = bloodType;
            Height = height;
            Weight = weight;
            Profession = profession;
            Validate();
        }
        private void Validate()
        {
            if (Height<30 || Weight<10)
                throw new ArgumentException();
        }
        public MedicalRecordInfo Create(string medicalRecordId, string personalId, BloodType bloodType, int height, int weight, string profession)
        {
            return new MedicalRecordInfo(medicalRecordId, personalId, bloodType,  height, weight, profession);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PersonalId;
            yield return BloodType;
            yield return Height;
            yield return Weight;
            yield return Profession;
        }
    }
}
