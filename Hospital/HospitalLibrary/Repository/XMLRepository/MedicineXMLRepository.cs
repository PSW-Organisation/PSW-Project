using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class MedicineXMLRepository : GenericXMLRepository<Medicine>, MedicineRepository
	{
		public MedicineXMLRepository() : base("medicines.xml") { }
	}
}
