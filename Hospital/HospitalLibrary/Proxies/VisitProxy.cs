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
	interface IVisit
	{
		public Visit GetVisit(string id);
	}

	public class VisitImpl 
	{
		/*VisitRepository visitRepository;
		public Visit GetVisit(string id)
		{
			if (visitRepository == null)
				visitRepository = new VisitXMLRepository();
			return visitRepository.Get(id);
		}*/
		
	}

	public class VisitProxyImpl
	{
		/*private IVisit visit;
		public Visit GetVisit(string id)
		{
			if (visit == null)
			{
				visit = new VisitImpl();
			}
			return visit.GetVisit(id);
		}
		*/
	}
}
