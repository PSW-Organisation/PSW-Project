using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class PatientXMLRepository : GenericXMLRepository<Patient>, PatientRepository
	{
		public PatientXMLRepository() : base("patients.xml") { }

        public Patient GetPatientByName(string fullName)
        {
            foreach (Patient patient in base.GetAll())
            {
                if (patient.Info.FullName == fullName)
                {
                    return patient;
                }
            }
            return null;
        }
    }
}
