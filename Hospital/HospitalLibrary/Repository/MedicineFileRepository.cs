using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
   public class MedicineFileRepository:IMedicineRepository
   {
       public String FileName { get; set; }

       public MedicineFileRepository()
       { 
           FileName = "../../lekovi.json";
       }

       public List<Medicine> GetAll()
       { 
           var allMedicine = new List<Medicine>();
           var medicineFromFile = ReadFromFile();
           foreach (var medicine in medicineFromFile)
           { 
               if (medicine.IsDeleted == false)
               { 
                   allMedicine.Add(medicine);
               }
           }
           return allMedicine;
       }
       public Boolean Save(Medicine newMedicine)
       {
           newMedicine.MedicineID = GenerateNextId();
           var storedMedicine = ReadFromFile();
           foreach (var medicine in storedMedicine)
           {
               if (!medicine.IsDeleted && medicine.MedicineID == newMedicine.MedicineID)
               {
                   return false;
               }
           }
           storedMedicine.Add(newMedicine);
           WriteToFile(storedMedicine);
           return true;
       }
      
      public Boolean Update(Medicine editedMedicine)
      {
            var storedMedicine = ReadFromFile();
            foreach (var medicine in storedMedicine)
            {
                if (medicine.MedicineID == editedMedicine.MedicineID)
                {
                    medicine.Manufacturer = editedMedicine.Manufacturer;
                    medicine.Name = editedMedicine.Name;
                    medicine.Packaging = editedMedicine.Packaging;
                    medicine.Status = editedMedicine.Status;
                    medicine.ingridient = new List<Ingridient>(editedMedicine.ingridient);
                    medicine.Condition = editedMedicine.Condition;
                    medicine.ReplacementMedicine = editedMedicine.ReplacementMedicine;
                    WriteToFile(storedMedicine);
                    return true;
                }
            }
            return false;
        }
      
      public Medicine GetOne(int id)
      {
            var allMedicine = GetAll();
            foreach (var medicine in allMedicine)
            {
                if (medicine.MedicineID.Equals(id))
                {
                    return medicine;
                }
            }
            return null;
      }
      
      public Boolean Delete(int id)
      {
          var storedMedicine = ReadFromFile();
          foreach (var medicine in storedMedicine)
          {
              if (medicine.MedicineID == id && medicine.IsDeleted == false)
              {
                  medicine.IsDeleted = true;
                  WriteToFile(storedMedicine);
                  return true;
              }
          }
          return false;
      }
      
      public List<Medicine> ReadFromFile()
      {
          try
          { 
              var jsonFromFile = File.ReadAllText(FileName);
              var allMedicine = JsonConvert.DeserializeObject<List<Medicine>>(jsonFromFile);
              return allMedicine;
          }
          catch { }
          MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
          return new List<Medicine>();
        }

      private void WriteToFile(List<Medicine> medicine)
      {
          try
          {
              var jsonToFile = JsonConvert.SerializeObject(medicine, Formatting.Indented);
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

      private int GenerateNextId()
      {
          var storedMedicine = ReadFromFile();
          return storedMedicine.Count;
      }

      public List<Medicine> GetAwaiting()
      {
          var awaitingMedicine = new List<Medicine>();
          var storedMedicine = ReadFromFile();
          foreach (var medicine in storedMedicine)
          {
              if (medicine.IsDeleted == false && medicine.Status == MedicineStatus.awaiting)
              {
                  awaitingMedicine.Add(medicine);
              }
          }
          return awaitingMedicine;
      }

      public List<Medicine> GetApproved()
      {
          var approvedMedicine = new List<Medicine>();
          var storedMedicine = ReadFromFile();
          foreach (var medicine in storedMedicine)
          {
              if (medicine.IsDeleted == false && medicine.Status == MedicineStatus.approved)
              {
                  approvedMedicine.Add(medicine);
              }
          }
          return approvedMedicine;
      }
    }
}