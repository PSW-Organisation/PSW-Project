using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ehealthcare.Proxies
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
				if(doctorRepository == null)
					doctorRepository = new DoctorXMLRepository();
				return doctorRepository.Get(id);
			}
			else if (type == LoginType.patient)
			{
				if(patientRepository == null)
					patientRepository = new PatientXMLRepository();
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
