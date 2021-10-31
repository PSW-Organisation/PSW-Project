using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
    public class DeclinedMedicineFileRepository:IDeclinedMedicineRepository
    {
        public String FileName { get; set; }

        public DeclinedMedicineFileRepository()
        {
            FileName = "../../odbijenilekovi.json";
        }

        public List<DeclinedMedicine> GetAll()
        {
            var allDeclinedMedicine = new List<DeclinedMedicine>();
            var declinedMedicineFromFile = ReadFromFile();
            foreach (var declinedMedicine in declinedMedicineFromFile)
            {
                if (declinedMedicine.IsDeleted == false)
                {
                    allDeclinedMedicine.Add(declinedMedicine);
                }
            }
            return allDeclinedMedicine;
        }

        public Boolean Save(DeclinedMedicine newDeclinedMedicine)
        {
            newDeclinedMedicine.DeclinedMedicineID = GenerateNextId();
            var storedDeclinedMedicine = ReadFromFile();
            foreach (var declinedMedicine in storedDeclinedMedicine)
            {
                if (declinedMedicine.DeclinedMedicineID == newDeclinedMedicine.DeclinedMedicineID)
                {
                    return false;
                }
            }
            storedDeclinedMedicine.Add(newDeclinedMedicine);
            WriteToFile(storedDeclinedMedicine);
            return true;
        }

        public Boolean Update(DeclinedMedicine editedDeclinedMedicine)
        {
            var storedDeclinedMedicine = ReadFromFile();
            foreach (var declinedMedicine in storedDeclinedMedicine)
            {
                if (declinedMedicine.DeclinedMedicineID == editedDeclinedMedicine.DeclinedMedicineID)
                {
                    declinedMedicine.Medicine = editedDeclinedMedicine.Medicine;
                    declinedMedicine.Description = editedDeclinedMedicine.Description;
                    WriteToFile(storedDeclinedMedicine);
                    return true;
                }
            }
            return false;
        }

        public DeclinedMedicine GetOne(int id)
        {
            var allDeclinedMedicine = GetAll();
            foreach (var declinedMedicine in allDeclinedMedicine)
            {
                if (declinedMedicine.DeclinedMedicineID.Equals(id))
                {
                    return declinedMedicine;
                }
            }
            return null;
        }

        public Boolean Delete(int id)
        {
            var storedDeclinedMedicine = ReadFromFile();
            foreach (var declinedMedicine in storedDeclinedMedicine)
            {
                if (declinedMedicine.DeclinedMedicineID == id && declinedMedicine.IsDeleted == false)
                {
                    declinedMedicine.IsDeleted = true;
                    WriteToFile(storedDeclinedMedicine);
                    return true;
                }
            }
            return false;
        }

        public List<DeclinedMedicine> ReadFromFile()
        {
            List<DeclinedMedicine> dm = new List<DeclinedMedicine>();
            try
            {
                var jsonFromFile = File.ReadAllText(this.FileName);
                List<DeclinedMedicine> allDeclinedMedicine = JsonConvert.DeserializeObject<List<DeclinedMedicine>>(jsonFromFile);
                return allDeclinedMedicine;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return dm;
        }

        private void WriteToFile(List<DeclinedMedicine> declinedMedicine)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(declinedMedicine, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    writer.Write(jsonToFile);
                }
            }
            catch
            {
                MessageBox.Show("Neuspesno pisanje u fajl" + this.FileName + "!");
            }
        }

        public int GenerateNextId()
        {
            List<DeclinedMedicine> storedDeclinedMedicine = ReadFromFile();
            return storedDeclinedMedicine.Count;
        }

    }
}
