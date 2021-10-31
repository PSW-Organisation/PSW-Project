using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
   public class DoctorEvaluationFileRepository : IDoctorEvaluationRepository
   {
        public String FileName { get; set; }

        public DoctorEvaluationFileRepository()
        {
            this.FileName = "../../doctor_evaluation.json";
        }

        public List<DoctorEvaluation> GetAll()
        {
            List<DoctorEvaluation> evaluations = new List<DoctorEvaluation>();
            List<DoctorEvaluation> storedEvaluations = ReadFromFile();
            for (int i = 0; i < storedEvaluations.Count; i++)
            {
                if (storedEvaluations[i].IsDeleted == false)
                {
                    evaluations.Add(storedEvaluations[i]);
                }
            }
            return evaluations;
        }

        public Boolean Save(DoctorEvaluation newEvaluation)
        {
            newEvaluation.Id = GenerateNextId();
            List<DoctorEvaluation> storedEvaluations = ReadFromFile();
            for (int i = 0; i < storedEvaluations.Count; i++)
            {
                if (storedEvaluations[i].Id.Equals(newEvaluation.Id))
                    return false;
            }
            storedEvaluations.Add(newEvaluation);
            WriteToFile(storedEvaluations);
            return true;
        }

        public Boolean Update(DoctorEvaluation editedEvaluation)
        {
            List<DoctorEvaluation> storedEvaluations = ReadFromFile();
            foreach (DoctorEvaluation evaluation in storedEvaluations)
            {
                if (evaluation.Id.Equals(editedEvaluation.Id) && evaluation.IsDeleted == false)
                {
                    evaluation.Comment = editedEvaluation.Comment;
                    evaluation.Id = editedEvaluation.Id;
                    evaluation.IsDeleted = editedEvaluation.IsDeleted;
                    evaluation.Rating = editedEvaluation.Rating;
                    WriteToFile(storedEvaluations);
                    return true;
                }
            }
            return false;
        }

        public DoctorEvaluation GetOne(int id)
        {
            List<DoctorEvaluation> evaluations = GetAll();
            for (int i = 0; i < evaluations.Count; i++)
            {
                if (evaluations[i].Id == id)
                    return evaluations[i];
            }
            return null;
        }

        public Boolean Delete(int id)
        {
            List<DoctorEvaluation> storedEvaluations = ReadFromFile();
            for (int i = 0; i < storedEvaluations.Count; i++)
            {
                if (storedEvaluations[i].Id == id && storedEvaluations[i].IsDeleted == false)
                {
                    storedEvaluations[i].IsDeleted = true;
                    WriteToFile(storedEvaluations);
                    return true;
                }
            }
            return false;
        }

        private List<DoctorEvaluation> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<DoctorEvaluation> evaluations = JsonConvert.DeserializeObject<List<DoctorEvaluation>>(jsonFromFile);
                return evaluations;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<DoctorEvaluation>();
        }

        private void WriteToFile(List<DoctorEvaluation> evaluations)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(evaluations, Formatting.Indented);
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
            List<DoctorEvaluation> evaluations = ReadFromFile();
            return evaluations.Count;
        }
    }
}