using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class AllergenXMLRepository : GenericXMLRepository<Allergen>, AllergenRepository
	{
		public AllergenXMLRepository() : base("allergens.xml") { }
    }
}
