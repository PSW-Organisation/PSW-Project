using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;

namespace IntegrationLibrary.Service
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
