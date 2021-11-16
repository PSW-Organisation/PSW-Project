using IntegrationLibrary.Service.ServicesInterfaces;
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

		private IAllergenService allergenService;

		public AllergenController(IAllergenService allergenService)
		{
			this.allergenService = allergenService;
		}

		public List<Allergen> GetAllAllergens()
		{
			return allergenService.GetAllAllergens();
		}
	}
}
