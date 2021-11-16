using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IAllergenService
    {
        public List<Allergen> GetAllAllergens();
    }
}
