using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
    public class HospitalizationXMLRepository : GenericXMLRepository<Hospitalization>, HospitalizationRepository
    {
        public HospitalizationXMLRepository() : base("hospitalizations.xml") { }
    }
}
