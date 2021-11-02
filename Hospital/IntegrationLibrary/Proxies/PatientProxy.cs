using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Proxies
{
	interface IPatient
	{
		public Patient GetPatient(string id);
	}

	public class PatientImpl : IPatient
	{
		PatientRepository patientRepository;
		public Patient GetPatient(string id)
		{
			if (patientRepository == null)
				patientRepository = new PatientXMLRepository();
			return patientRepository.Get(id);
		}
	}

	public class PatientProxyImpl : IPatient
	{
		private IPatient patient;
		public Patient GetPatient(string id)
		{
			if (patient == null)
			{
				patient = new PatientImpl();
			}
			return patient.GetPatient(id);
		}
	}
}
