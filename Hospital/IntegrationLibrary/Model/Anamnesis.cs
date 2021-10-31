// File:    Anamnesis.cs
// Author:  graho
// Created: 16 April 2021 17:26:58
// Purpose: Definition of Class Anamnesis

using System;

namespace Model
{
   public class Anamnesis
   {
        public DateTime Time { get; set; }
        public String Comment { get; set; }
        public String Patient { get; set; }
        public String Doctor { get; set; }

        public Anamnesis(DateTime time, String comment, String patient, String doctor)
        {
            Time = time;
            Comment = comment;
            Patient = patient;
            Doctor = doctor;
        }
    }
}