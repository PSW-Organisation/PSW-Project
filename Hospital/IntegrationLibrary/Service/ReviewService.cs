using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Service
{
	public class ReviewService : IReviewService
	{
		private DoctorReviewRepository doctorReviewRepository;
		private HospitalReviewRepository hospitalReviewRepository;

		public ReviewService(DoctorReviewRepository doctorReviewRepository, HospitalReviewRepository hospitalReviewRepository)
		{
			this.doctorReviewRepository = doctorReviewRepository;
			this.hospitalReviewRepository = hospitalReviewRepository;
		}

		public void AddNewDoctorReviewToStorage(DoctorReview doctorReview)
		{
			doctorReviewRepository.Save(doctorReview);
		}

		public void AddNewHospitalReviewToStorage(HospitalReview hospitalReview)
		{
			hospitalReviewRepository.Save(hospitalReview);
		}

		public bool CanPatientReviewHospital(Patient patient)
		{
			List<HospitalReview> hospitalReviews = hospitalReviewRepository.GetAll();
			if(hospitalReviews.Count != 0)
			{
				foreach (HospitalReview hospitalReview in hospitalReviews)
				{
					if(hospitalReview.Patient.Id == patient.Id)
					{
						if(hospitalReview.RatingDate.AddDays(30) > DateTime.Now)
						{
							return false;
						}
					}
				}
			}
			return true;
		}
	}
}
