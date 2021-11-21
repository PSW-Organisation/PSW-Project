using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using HospitalLibrary;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Repository;

namespace ehealthcare.Service
{
    public class AllergenService
    {
        private readonly IAllergenRepository _allergenRepository;

        public AllergenService(IAllergenRepository allergenRepository)
        {
            _allergenRepository = allergenRepository;
        }
    }
}
