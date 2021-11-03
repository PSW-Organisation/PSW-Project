﻿using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class HospitalizationService
    {
        private HospitalizationRepository hospitalizationRepository;

        public HospitalizationService()
        {
            hospitalizationRepository = new HospitalizationXMLRepository();
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