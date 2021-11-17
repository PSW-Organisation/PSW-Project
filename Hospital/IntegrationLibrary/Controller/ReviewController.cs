using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class ReviewController
	{
		private IReviewService reviewService;

		public ReviewController(IReviewService reviewService)
		{
			this.reviewService = reviewService;
		}

		public void AddNewDoctorReviewToStorage(DoctorReview doctorReview)
		{
			reviewService.AddNewDoctorReviewToStorage(doctorReview);
		}

		public void AddNewHospitalReviewToStorage(HospitalReview hospitalReview)
		{
			reviewService.AddNewHospitalReviewToStorage(hospitalReview);
		}

		public bool CanPatientReviewHospital(Patient patient)
		{
			return reviewService.CanPatientReviewHospital(patient);
		}
	}
}
