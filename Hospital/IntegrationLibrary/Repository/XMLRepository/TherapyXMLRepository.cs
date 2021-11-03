﻿using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class TherapyXMLRepository : GenericXMLRepository<Therapy>, TherapyRepository
	{
		public TherapyXMLRepository() : base("therapies.xml") { }

	}
}