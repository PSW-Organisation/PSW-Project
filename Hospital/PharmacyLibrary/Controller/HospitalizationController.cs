using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class HospitalizationController
    {
        private HospitalizationService hospitalizationService;

        public HospitalizationController()
        {
            hospitalizationService = new HospitalizationService();
        }

        public List<Hospitalization> GetHospitalizations()
        {
            return hospitalizationService.GetHospitalizations();
        }
        public Hospitalization CheckIfPatientHospitalized(Patient patient)
        {
            return hospitalizationService.CheckIfPatientHospitalized(patient);
        }

        public void AddHospitalizationToStorage(Hospitalization hospitalization)
        {
            hospitalizationService.AddHospitalizationToStorage(hospitalization);
        }

        public void UpdateHospitalizationInStorage(Hospitalization hospitalization)
        {
            hospitalizationService.UpdateHospitalizationInStorage(hospitalization);
        }
    }
}
