using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace vezba.Repository
{
    class UserFeedbackFileRepository:IUserFeedbackRepository
    {
        public String FileName { get; set; }

        public UserFeedbackFileRepository()
        {
            this.FileName = "../../feedback.json";
        }
        public List<UserFeedback> GetAll()
        {
            List<UserFeedback> storedFeedback = ReadFromFile();
            List<UserFeedback> feedback = new List<UserFeedback>();
            for (int i = 0; i < storedFeedback.Count; i++)
            {
                if (storedFeedback[i].IsDeleted == false)
                    feedback.Add(storedFeedback[i]);
            }
            return feedback;
        }
        public UserFeedback GetOne(int id)
        {
            List<UserFeedback> feedback = GetAll();
            foreach (UserFeedback f in feedback)
            {
                if (f.Id.Equals(id))
                    return f;
            }
            return null;
        }


        private List<UserFeedback> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<UserFeedback> feedback = JsonConvert.DeserializeObject<List<UserFeedback>>(jsonFromFile);
                return feedback;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<UserFeedback>();
        }

        public Boolean Save(UserFeedback newFeedback)
        {
            List<UserFeedback> storedFeedback = ReadFromFile();
            newFeedback.Id = GenerateNextId();
            foreach (UserFeedback f in storedFeedback)
            {
                if (f.Id == newFeedback.Id)
                    return false;
            }
            storedFeedback.Add(newFeedback);

            WriteToFile(storedFeedback);
            return true;
        }

        public Boolean Update(UserFeedback editedFeedback)
        {
            List<UserFeedback> storedFeedback = ReadFromFile();
            foreach (UserFeedback f in storedFeedback)
            {
                if (f.Id == editedFeedback.Id && f.IsDeleted == false)
                {
                    f.Rating = editedFeedback.Rating;
                    f.Content = editedFeedback.Content;
                    f.TimeWritten = editedFeedback.TimeWritten;
                    WriteToFile(storedFeedback);
                    return true;
                }
            }
            return false;
        }

        public Boolean Delete(int id)
        {
            List<UserFeedback> storedFeedback = ReadFromFile();
            foreach (UserFeedback f in storedFeedback)
            {
                if (f.Id == id && f.IsDeleted == false)
                {
                    f.IsDeleted = true;
                    WriteToFile(storedFeedback);
                    return true;

                }
            }
            return false;
        }

        private void WriteToFile(List<UserFeedback> feedback)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(feedback, Formatting.Indented);
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

        private int GenerateNextId()
        {
            List<UserFeedback> storedFeedback = ReadFromFile();
            return storedFeedback.Count;
        }
    }
}
