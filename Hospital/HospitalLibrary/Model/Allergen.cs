using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ehealthcare.Model
{
    [Serializable]
    public class Allergen : Entity
    {
        private String type;

        public Allergen() : base("undefinedKey") { }

        public string Type
        {
            get { return type; }

            set { type = value; }
        }

       /* public bool IsAlergic
        {
            get { return isAlergic; }

            set { isAlergic = value; }
        }

        */
    }
}