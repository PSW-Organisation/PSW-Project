using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
   public class EventsLogFileRepository : IEventsLogRepository
   {
        public String FileName { get; set; }

        public EventsLogFileRepository()
        {
            this.FileName = "../../events_log.json";
        }

        public List<EventsLog> GetAll()
        {
            List<EventsLog> logs1 = ReadFromFile();
            return logs1;
        }
      
        public Boolean Save(EventsLog log)
        {
            List<EventsLog> storedElogs = new List<EventsLog>();
            storedElogs = ReadFromFile();
            for (int i = 0; i < storedElogs.Count; i++)
            {
                if (storedElogs[i].PatientJmbg.Equals(log.PatientJmbg))
                    return false;
            }
            storedElogs.Add(log);
            WriteToFile(storedElogs);

            return true;
        }
      
        public Boolean Update(EventsLog log)
        {
            List<EventsLog> storegElogs = ReadFromFile();
            for (int i = 0; i < storegElogs.Count; i++)
            {
                if (storegElogs[i].PatientJmbg.Equals(log.PatientJmbg))
                {
                    storegElogs[i].PatientJmbg = log.PatientJmbg;
                    storegElogs[i].EventDates = log.EventDates;
                    WriteToFile(storegElogs);
                    return true;
                }
            }
            return false;
        }
      
        public EventsLog GetOne(String patientJmbg)
        {
            List<EventsLog> logs = ReadFromFile();
            for (int i = 0; i < logs.Count; i++)
            {
                if (logs[i].PatientJmbg == patientJmbg)
                {
                    return logs[i];
                }
            }
            return null;
        }

        public Boolean Delete(String patientJmbg)
        {
            throw new NotImplementedException();
        }

        private List<EventsLog> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<EventsLog> elogs = JsonConvert.DeserializeObject<List<EventsLog>>(jsonFromFile);
                return elogs;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<EventsLog>();
        }

        private void WriteToFile(List<EventsLog> elogs)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(elogs, Formatting.Indented);
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