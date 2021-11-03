using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;

namespace ehealthcare.Service
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
