using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ehealthcare.Model
{
    [Serializable]
    public class Entity
    {
        private string id;

        public Entity(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

    }
}
