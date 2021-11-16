using System;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Diagnosis
    {
        private int id;
        private String name;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}