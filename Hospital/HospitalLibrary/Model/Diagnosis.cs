using System;

namespace ehealthcare.Model
{
    [Serializable]
    public class Diagnosis
    {
        private String id;
        private String name;

        public String Id
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