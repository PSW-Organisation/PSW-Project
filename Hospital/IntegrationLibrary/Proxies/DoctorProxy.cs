﻿using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Proxies
{
	interface IDoctor
	{
		public Doctor GetDoctor(string id);
	}

	public class DoctorImpl : IDoctor
	{
		DoctorRepository doctorRepository;
		public Doctor GetDoctor(string id)
		{
			if (doctorRepository == null)
				doctorRepository = new DoctorXMLRepository();
			return doctorRepository.Get(id);
		}
	}

	public class DoctorProxyImpl : IDoctor
	{
		private IDoctor doctor;
		public Doctor GetDoctor(string id)
		{
			if (doctor == null)
			{
				doctor = new DoctorImpl();
			}
			return doctor.GetDoctor(id);
		}
	}
}