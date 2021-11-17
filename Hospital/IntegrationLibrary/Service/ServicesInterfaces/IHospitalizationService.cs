using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IHospitalizationService
    {
        public List<Hospitalization> GetHospitalizations();
        public Hospitalization CheckIfPatientHospitalized(Patient patient);
        public void AddHospitalizationToStorage(Hospitalization hospitalization);
        public void UpdateHospitalizationInStorage(Hospitalization hospitalization);
    }
}
