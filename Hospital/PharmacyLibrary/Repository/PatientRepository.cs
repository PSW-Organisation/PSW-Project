using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository
{
    public interface PatientRepository : GenericRepository<Patient>
    {
        public Patient GetPatientByName(string fullName);
    }
}
