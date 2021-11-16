using System;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Allergen : Entity
    {
        private String type;
        private Boolean isAlergic;

        public Allergen() : base("undefinedKey") { }

        public string Type
        {
            get { return type; }

            set { type = value; }
        }

        public bool IsAlergic
        {
            get { return isAlergic; }

            set { isAlergic = value; }
        }
    }
}