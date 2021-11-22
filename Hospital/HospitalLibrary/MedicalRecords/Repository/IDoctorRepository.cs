﻿using ehealthcare.Model;
using HospitalLibrary.Repository;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.MedicalRecord.Repository
{
    public interface IDoctorRepository : IGenericSTRINGIDRepository<Doctor>
    {
        public int FindLeastNumberOfPatient();
        List<Doctor> GetLeastOccupiedDoctors(int minPatients);
    }
}