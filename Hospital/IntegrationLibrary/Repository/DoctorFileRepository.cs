using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
    public class DoctorFileRepository:IDoctorRepository
    {
        public String FileName { get; set; }

        public DoctorFileRepository()
        {
            this.FileName = "../../doctors.json";
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> storedDoctors = ReadFromFile();
            List<Doctor> doctors = new List<Doctor>();
            for (int i = 0; i < storedDoctors.Count; i++)
            {
                if (storedDoctors[i].IsDeleted == false)
                    doctors.Add(storedDoctors[i]);
            }
            return doctors;
        }

        public List<Doctor> GetDoctorsWithSpeciality(Speciality speciality)
        {
            List<Doctor> doctors = GetAll();
            List<Doctor> doctorsWithSpeciality = new List<Doctor>();
            foreach (Doctor d in doctors)
            {
                if (d.Speciality.Name.Equals(speciality.Name))
                    doctorsWithSpeciality.Add(d);
            }
            return doctorsWithSpeciality;
        }

        public Doctor GetOne(String jmbg)
        {
            List<Doctor> doctors = GetAll();
            foreach (Doctor doctor in doctors)
            {
                if (doctor.Jmbg.Equals(jmbg))
                    return doctor;
            }
            return null;
        }
      
      
        private List<Doctor> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<Doctor> doctors = JsonConvert.DeserializeObject<List<Doctor>>(jsonFromFile);
                return doctors;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<Doctor>();
        }

        public Boolean Save(Doctor newDoctor)
        {
            List<Doctor> storedDoctors = ReadFromFile();

            foreach (Doctor doctor in storedDoctors)
            {
                if (doctor.Jmbg == newDoctor.Jmbg)
                    return false;
            }
            storedDoctors.Add(newDoctor);

            WriteToFile(storedDoctors);
            return true;
        }

        public Boolean Update(Doctor editedDoctor)
        {
            List<Doctor> storedDoctors = ReadFromFile();
            foreach (Doctor doctor in storedDoctors)
            {
                if (doctor.Jmbg == editedDoctor.Jmbg && doctor.IsDeleted == false)
                {
                    doctor.VacationDays = editedDoctor.VacationDays;
                    doctor.WorkingSchedule = editedDoctor.WorkingSchedule;
                    doctor.AvailableDaysOff = editedDoctor.AvailableDaysOff;

                    WriteToFile(storedDoctors);
                    return true;
                }
            }
            return false;
        }

        public Boolean Delete(string jmbg)
        {
            List<Doctor> storedDoctors = ReadFromFile();
            foreach (Doctor doctor in storedDoctors)
            {
                if (doctor.Jmbg == jmbg && doctor.IsDeleted == false)
                {
                    doctor.IsDeleted = true;
                    WriteToFile(storedDoctors);
                    return true;

                }
            }
            return false;
        }

        private void WriteToFile(List<Doctor> doctors)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(doctors, Formatting.Indented);
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