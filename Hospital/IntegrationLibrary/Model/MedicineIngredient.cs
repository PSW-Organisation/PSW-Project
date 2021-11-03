using System;

namespace ehealthcare.Model
{
    [Serializable]
    public class MedicineIngredient
    {
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}