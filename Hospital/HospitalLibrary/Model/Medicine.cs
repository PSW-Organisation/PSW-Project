using System;
using Newtonsoft.Json;

namespace Model
{
   public class Medicine
   {
        public Medicine(String name, String manufacturer, String packaging, int medicineID, MedicineCondition condition)
        {
            this.MedicineID = medicineID;
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Packaging = packaging;
            this.Condition = condition;
            this.Status = MedicineStatus.awaiting;
            this.ReplacementMedicine = null;
            this.ingridient = new System.Collections.Generic.List<Ingridient>();
            this.IsDeleted = false;
        }
        public String Name { get; set; }

        //******** Dodati deo - ako nesto ne radi
        public String Manufacturer { get; set; }
        public String Packaging { get; set; }
        public int MedicineID { get; set; }
        public MedicineStatus Status { get; set; }
        public MedicineCondition Condition { get; set; }
        public Boolean IsDeleted { get; set; }

        public Medicine ReplacementMedicine { get; set; }
        //********

        [JsonIgnore]
        public String ConditionSerbian
        {
            get
            {
                switch (Condition)
                {
                    case MedicineCondition.capsule:
                        return "kapsula";
                    case MedicineCondition.pill:
                        return "pilula";
                    default:
                        return "sirup";
                }
            }
        }

        [JsonIgnore]
        public String StatusSerbian
        {
            get
            {
                switch (Status)
                {
                    case MedicineStatus.awaiting:
                        return "Na èekanju";
                    case MedicineStatus.approved:
                        return "Odobren";
                    default:
                        return "Odbijen";
                }
            }
        }

        public System.Collections.Generic.List<Ingridient> ingridient;

        public System.Collections.Generic.List<Ingridient> Ingridient
        {
            get
            {
                if (ingridient == null)
                    ingridient = new System.Collections.Generic.List<Ingridient>();
                return ingridient;
            }
            set
            {
                RemoveAllIngridient();
                if (value != null)
                {
                    foreach (Ingridient oIngridient in value)
                        AddIngridient(oIngridient);
                }
            }
        }

        public void AddIngridient(Ingridient newIngridient)
        {
            if (newIngridient == null)
                return;
            if (this.ingridient == null)
                ingridient = new System.Collections.Generic.List<Ingridient>();
            if (!this.ingridient.Contains(newIngridient))
                this.ingridient.Add(newIngridient);
        }

        public void RemoveIngridient(Ingridient oldIngridient)
        {
            if (oldIngridient == null)
                return;
            if (this.ingridient != null)
                if (this.ingridient.Contains(oldIngridient))
                    this.ingridient.Remove(oldIngridient);
        }

        public void RemoveAllIngridient()
        {
            if (ingridient != null)
                ingridient.Clear();
        }

        override
        public String ToString()
        {
            return Name;
        }

    }

}
