using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
    public class PatientFileRepository:IPatientRepository
    {
        public String FileName { get; set; }

        public PatientFileRepository()
        {
            this.FileName = "../../pacijenti.json";
        }

        public List<Patient> GetAll()
        {
            List<Patient> storedPatients = ReadFromFile();
            List<Patient> patients = new List<Patient>();
            foreach(Patient patient in storedPatients)
            {
                if(patient.IsDeleted == false)
                    patients.Add(patient);
            }
            return patients;
        }

        public string GetBullshit() 
        {
            return "Bullshit";
        }


        public Boolean Save(Patient newPatient)
        {
            List<Patient> storedPatients = ReadFromFile();

            foreach (Patient patient in storedPatients)
            {
                if (patient.Jmbg.Equals(newPatient.Jmbg) && patient.IsDeleted == false)
                    return false;
            }
            storedPatients.Add(newPatient);
            WriteToFile(storedPatients);
            return true;
        }

        public Boolean Update(Patient editedPatient)
        {
            List<Patient> storedPatients = ReadFromFile();
            foreach (Patient patient in storedPatients)
            {
                if (patient.Jmbg.Equals(editedPatient.Jmbg))
                {
                    patient.Name = editedPatient.Name;
                    patient.Surname = editedPatient.Surname;
                    patient.DateOfBirth = editedPatient.DateOfBirth;
                    patient.Sex = editedPatient.Sex;
                    patient.PhoneNumber = editedPatient.PhoneNumber;
                    patient.Adress = editedPatient.Adress;
                    patient.IdCard = editedPatient.IdCard;
                    patient.Email = editedPatient.Email;
                    patient.EmergencyContact = editedPatient.EmergencyContact;
                    patient.MedicalRecord = editedPatient.MedicalRecord;
                    patient.Username = editedPatient.Username;
                    patient.IsGuest = editedPatient.IsGuest;
                    patient.Password = editedPatient.Password;
                    patient.IsBlocked = editedPatient.IsBlocked;

                    WriteToFile(storedPatients);
                    return true;
                }
            }
            return false;
        }

        public Patient GetOne(String jmbg)
        {
            List<Patient> storedPatients = GetAll();
            foreach (Patient patient in storedPatients)
            {
                if (patient.Jmbg.Equals(jmbg))
                    return patient;
            }
            return null;
        }

        public Boolean Delete(string jmbg)
        {
            List<Patient> storedPatients = ReadFromFile();
            foreach (Patient patient in storedPatients)
            {
                if (patient.Jmbg.Equals(jmbg))
                {
                    patient.IsDeleted = true;
                    WriteToFile(storedPatients);
                    return true;
                }
            }
            return false;
        }

        private List<Patient> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<Patient> patients = JsonConvert.DeserializeObject<List<Patient>>(jsonFromFile);
                return patients;
            }
            catch
            { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<Patient>();
        }

        private void WriteToFile(List<Patient> patients)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(patients, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(this.FileName))
                {
                    writer.Write(jsonToFile);
                }
            }
            catch
            {
                MessageBox.Show("Neuspesno pisanje u fajl" + this.FileName + "!");
            }
        }
    }
}