using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IMedicalRecordService
    {
        public void SetPatientsDoctor(int patientId, Doctor doctor);
        public bool CheckIfAlergic(Patient patient, Medicine medicine);
    }
}
