using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationLibrary.Proxies
{
	interface IUser
	{
		public User GetUser(int id, LoginType type);
	}

	public class UserImpl : IUser
	{
		DoctorRepository doctorRepository;
		PatientRepository patientRepository;
		public User GetUser(int id, LoginType type)
		{
			if (type == LoginType.doctor)
			{
			
				return doctorRepository.Get(id);
			}
			else if (type == LoginType.patient)
			{
				
				return patientRepository.Get(id);
			}
			else return null;
		}
	}

	public class UserProxyImpl : IUser
	{
		private IUser user;
		public User GetUser(int id, LoginType type)
		{
			if (user == null)
			{
				user = new UserImpl();
			}
			return user.GetUser(id, type);
		}
	}
}
