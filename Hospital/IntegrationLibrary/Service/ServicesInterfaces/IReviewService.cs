using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IReviewService
    {
        public void AddNewDoctorReviewToStorage(DoctorReview doctorReview);
        public void AddNewHospitalReviewToStorage(HospitalReview hospitalReview);
        public bool CanPatientReviewHospital(Patient patient);
    }
}
