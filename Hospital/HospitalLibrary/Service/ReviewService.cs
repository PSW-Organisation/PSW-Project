using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
	public class ReviewService
	{

		private DoctorReviewRepository doctorReviewRepository;
		private HospitalReviewRepository hospitalReviewRepository;

		public ReviewService()
		{
			doctorReviewRepository = new DoctorReviewXMLRepository();
			hospitalReviewRepository = new HospitalReviewXMLRepository();
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
