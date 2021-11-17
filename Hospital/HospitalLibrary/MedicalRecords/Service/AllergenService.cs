using HospitalLibrary.MedicalRecords.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.MedicalRecords.Service
{
    public class AllergenService: IAllergenService
    {
        private readonly IAllergenRepository _allergenRepository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            _allergenRepository = allergenRepository;
        }

        public List<Allergen> GetAllergens()
        {
            return _allergenRepository.GetAll().ToList();
        }
    }
}
