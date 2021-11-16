﻿using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Repository.XMLRepository;
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
		public User GetUser(string id, LoginType type);
	}

	public class UserImpl : IUser
	{
		DoctorRepository doctorRepository;
		PatientRepository patientRepository;
		public User GetUser(string id, LoginType type)
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
		public User GetUser(string id, LoginType type)
		{
			if (user == null)
			{
				user = new UserImpl();
			}
			return user.GetUser(id, type);
		}
	}
}
