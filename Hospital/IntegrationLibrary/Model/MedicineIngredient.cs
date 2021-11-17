using System;
using System.ComponentModel.DataAnnotations;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class MedicineIngredient
    {
        private String name;

        [Key]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}