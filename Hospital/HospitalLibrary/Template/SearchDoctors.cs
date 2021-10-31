using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Template
{
    class SearchDoctors : Search<Doctor>
    {
        protected override List<Doctor> GetAll()
        {
            DoctorService doctorService = new DoctorService();
            List<Doctor> allDoctors = doctorService.GetAllDoctors();
            return allDoctors;
        }

        protected override bool ItemContainsInput(Doctor doctor, string input)
        {
            if (doctor.NameAndSurname.ToLower().Contains(input.ToLower()))
                return true;
            if (doctor.SpecialityName.ToLower().Contains(input.ToLower()))
                return true;
            if (doctor.Jmbg.ToLower().Contains(input.ToLower()))
                return true;
            return false;
        }
    }
}
