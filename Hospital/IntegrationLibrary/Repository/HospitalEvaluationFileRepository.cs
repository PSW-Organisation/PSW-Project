using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
   public class HospitalEvaluationFileRepository : IHospitalEvaluationRepository
   {
        public String FileName { get; set; }

        public HospitalEvaluationFileRepository()
        {
            this.FileName = "../../hospital_evaluation.json";
        }

        public List<HospitalEvaluation> GetAll()
        {
            List<HospitalEvaluation> evaluations = new List<HospitalEvaluation>();
            List<HospitalEvaluation> storedEvaluations = ReadFromFile();
            for (int i = 0; i < storedEvaluations.Count; i++)
            {
                if (storedEvaluations[i].IsDeleted == false)
                {
                    evaluations.Add(storedEvaluations[i]);
                }
            }
            return evaluations;
        }

        public Boolean Save(HospitalEvaluation newEvaluation)
        {
            newEvaluation.Id = GenerateNextId();
            List<HospitalEvaluation> storedEvaluations = ReadFromFile();
            for (int i = 0; i < storedEvaluations.Count; i++)
            {
                if (storedEvaluations[i].Id.Equals(newEvaluation.Id))
                    return false;
            }
            storedEvaluations.Add(newEvaluation);
            WriteToFile(storedEvaluations);
            return true;
        }

        public Boolean Update(HospitalEvaluation editedEvaluation)
        {
            List<HospitalEvaluation> storedEvaluations = ReadFromFile();
            foreach (HospitalEvaluation evaluation in storedEvaluations)
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

        public HospitalEvaluation GetOne(int id)
        {
            List<HospitalEvaluation> evaluations = GetAll();
            for (int i = 0; i < evaluations.Count; i++)
            {
                if (evaluations[i].Id == id)
                    return evaluations[i];
            }
            return null;
        }

        public Boolean Delete(int id)
        {
            List<HospitalEvaluation> storedEvaluations = ReadFromFile();
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

        private List<HospitalEvaluation> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<HospitalEvaluation> evaluations = JsonConvert.DeserializeObject<List<HospitalEvaluation>>(jsonFromFile);
                return evaluations;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<HospitalEvaluation>();
        }

        private void WriteToFile(List<HospitalEvaluation> evaluations)
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

        public int GenerateNextId()
        {
            List<HospitalEvaluation> evaluations = ReadFromFile();
            return evaluations.Count;
        }
    }
}