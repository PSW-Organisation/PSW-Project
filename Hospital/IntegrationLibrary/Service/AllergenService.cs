using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;

namespace ehealthcare.Service
{
    public class AllergenService : IAllergenService
    {
        private AllergenRepository allergenRepository;

        public AllergenService(AllergenRepository allergenRepository)
        {
            this.allergenRepository = allergenRepository;
        }

        public List<Allergen> GetAllAllergens()
        {
            return allergenRepository.GetAll();
        }
    }
}
