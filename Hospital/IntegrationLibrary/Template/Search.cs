using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Template
{
    abstract class Search<T> where T : class
    {
        public List<T> SearchTemplate(String input)
        {
            List<T> allItems = this.GetAll();
            List<T> searchResultItems = new List<T>();
            foreach(T i in allItems)
            {
                if (this.ItemContainsInput(i, input))
                    searchResultItems.Add(i); 
            }
            return searchResultItems;
        }
        protected abstract List<T> GetAll();
        protected abstract Boolean ItemContainsInput(T item, String input);
    }
}
