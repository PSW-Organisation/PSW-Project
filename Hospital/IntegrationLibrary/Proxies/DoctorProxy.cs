using IntegrationLibrary.Repository.DatabaseRepository;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Proxies
{
	interface IDoctor
	{
		public Doctor GetDoctor(int id);
	}

	public class DoctorImpl : IDoctor
	{
		DoctorRepository doctorRepository;
		public Doctor GetDoctor(int id)
		{
			
			return doctorRepository.Get(id);
		}
	}

	public class DoctorProxyImpl : IDoctor
	{
		private IDoctor doctor;
		public Doctor GetDoctor(int id)
		{
			if (doctor == null)
			{
				doctor = new DoctorImpl();
			}
			return doctor.GetDoctor(id);
		}
	}
}
