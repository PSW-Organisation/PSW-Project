using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;

namespace IntegrationLibrary.Service
{
    public class AllergenService
    {
        private AllergenRepository allergenRepository;

        public AllergenService()
        {
            allergenRepository = new AllergenXMLRepository();
        }

        public List<Allergen> GetAllAllergens()
        {
            return allergenRepository.GetAll();
        }
    }
}
