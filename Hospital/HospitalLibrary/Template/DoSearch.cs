using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Template
{
    class DoSearch<T> where T : class
    {
        public static List<T> GetSearchResult(Search<T> search, String input)
        {
            return search.SearchTemplate(input);
        }
    }
}
