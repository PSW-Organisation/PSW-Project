using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Proxies
{
	interface IPatient
	{
		public Patient GetPatient(int id);
	}

	public class PatientImpl : IPatient
	{
		PatientRepository patientRepository;
		public Patient GetPatient(int id)
		{
			
			return patientRepository.Get(id);
		}
	}

	public class PatientProxyImpl : IPatient
	{
		private IPatient patient;
		public Patient GetPatient(int id)
		{
			if (patient == null)
			{
				patient = new PatientImpl();
			}
			return patient.GetPatient(id);
		}
	}
}
