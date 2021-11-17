using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ehealthcare.Model;
using ehealthcare.Repository;

namespace ehealthcare.Service
{
    public class AllergenService
    {
        private AllergenRepository allergenRepository;

        public AllergenService()
        {
        }

        public List<Allergen> GetAllAllergens()
        {
            return allergenRepository.GetAll();
        }
    }
}
