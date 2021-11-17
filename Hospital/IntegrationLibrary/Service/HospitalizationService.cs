using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
    public class HospitalizationService : IHospitalizationService
    {
        private HospitalizationRepository hospitalizationRepository;

        public HospitalizationService(HospitalizationRepository hospitalizationRepository)
        {
            this.hospitalizationRepository = hospitalizationRepository;
        }

        public List<Hospitalization> GetHospitalizations()
        {
            return hospitalizationRepository.GetAll();
        }

        public Hospitalization CheckIfPatientHospitalized(Patient patient)
        {
            List<Hospitalization> hospitalizations = hospitalizationRepository.GetAll();
            foreach (Hospitalization hospitalization in hospitalizations)
            {
                if (hospitalization.PatientId == patient.Id && hospitalization.IsActive)
                {
                    return hospitalization;
                }
            }
            return null;
        }

        public void AddHospitalizationToStorage(Hospitalization hospitalization)
        {
            hospitalizationRepository.Save(hospitalization);
        }

        public void UpdateHospitalizationInStorage(Hospitalization hospitalization)
        {
            hospitalizationRepository.Update(hospitalization);
        }
    }
}
