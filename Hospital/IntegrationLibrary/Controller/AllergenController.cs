using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class AllergenController
	{

		private AllergenService allergenService;

		public AllergenController()
		{
			allergenService = new AllergenService();
		}

		public List<Allergen> GetAllAllergens()
		{
			return allergenService.GetAllAllergens();
		}
	}
}
