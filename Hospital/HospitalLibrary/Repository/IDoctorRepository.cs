using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Repository
{
    interface IDoctorRepository: IGenericRepository<Doctor, string>
    {
        List<Doctor> GetDoctorsWithSpeciality(Speciality speciality);
    }
}
