using ehealthcare.Model;
using HospitalLibrary.Schedule.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using HospitalLibrary.MedicalRecord.Repository;
using HospitalLibrary.MedicalRecords.Repository;
using HospitalLibrary.Schedule.Model;

namespace HospitalLibrary.Schedule.Service
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IDoctorRepository _doctorRepository;

        public VisitService(IVisitRepository visitRepository, IDoctorRepository doctorRepository)
        {
            _visitRepository = visitRepository;
            _doctorRepository = doctorRepository;
        }

        public List<Visit> GetVisitsByUsername(string username)
        {
            return _visitRepository.GetVisitsByUsername(username);
        }

        public Visit GetVisitById(int id)
        {
           return _visitRepository.Get(id);
        }

        public bool AddVisit(Visit newVisit)
        {
            if(CheckIfDoctorBusy(newVisit)) return false;
            if(CheckIfPatientBusy(newVisit)) return false;
            _visitRepository.Insert(newVisit);
            return true;
        }

        public bool CheckIfDoctorBusy(Visit visit)
        {
            if (_visitRepository.CheckIfDoctorBusy(visit))
                return true;
            return false;
        }

        public bool CheckIfPatientBusy(Visit visit)
        {
            if (_visitRepository.CheckIfPatientBusy(visit))
                return true;
            return false;
        }

        public void CancelVisit(Visit visit)
        {
            visit.IsCanceled = true;
           _visitRepository.Update(visit);
        }

        public List<Visit> GetАllGeneratedFreeVisits(VisitRecommendation recommendation)
        {
            return GetGeneratedFreeVisitsByDate(recommendation);
        }

        private List<Visit> GetGeneratedFreeVisitsByDate(VisitRecommendation recommendation)
        {
            if (recommendation.IsVisitScheduleByPriority)  return GetGeneratedFreeVisits(recommendation);
            return GetFreeGeneratedVisitsByDoctor(recommendation.StartTime, recommendation.EndTime, recommendation.DoctorId);
        }

        private List<Visit> GetGeneratedFreeVisits(VisitRecommendation recommendation)
        {
            List<Visit> generatedFreeVisits = new List<Visit>();
            while (generatedFreeVisits.Count == 0)
            {
                if (HasRecommendationStartTimePassed(recommendation)) generatedFreeVisits = GetGeneratedFreeVisitsByPriority(recommendation);
                else
                {
                    recommendation.StartTime = recommendation.StartTime.AddDays(1);
                    generatedFreeVisits = GetGeneratedFreeVisitsByPriority(recommendation);
                }
                recommendation.StartTime = recommendation.StartTime.AddDays(-1);
                recommendation.EndTime = recommendation.EndTime.AddDays(1);
            }

            return generatedFreeVisits;
        }

        private static bool HasRecommendationStartTimePassed(VisitRecommendation recommendation)
        {
            return recommendation.StartTime > DateTime.Now;
        }

        private List<Visit> GetGeneratedFreeVisitsByPriority(VisitRecommendation recommendation)
        {
            List<Visit> generatedFreeVisits = new List<Visit>();
            if (recommendation.Priority) generatedFreeVisits = GetFreeGeneratedVisitsByDate(recommendation.StartTime, recommendation.EndTime, recommendation.DoctorId);
            else generatedFreeVisits = GetFreeGeneratedVisitsByDoctor(recommendation.StartTime, recommendation.EndTime, recommendation.DoctorId);

            return generatedFreeVisits;
        }

        private List<Visit> GetFreeGeneratedVisitsByDoctor(DateTime begining, DateTime ending, string doctorId)
        {
            List<Visit> generatedVisits = GetGeneratedVisits(begining, ending);
            List<Visit> generatedVisitsByDoctor = new List<Visit>();
            List<Visit> visits = _visitRepository.GetAllVisits();
            Doctor doctor = _doctorRepository.GetDoctorById(doctorId);
            foreach (var generatedVisit in generatedVisits)
            {
                generatedVisitsByDoctor = GetGeneratedVisitsByDoctor(doctorId, generatedVisitsByDoctor, visits, doctor, generatedVisit);
            }
            return generatedVisitsByDoctor;
        }

        private static List<Visit> GetGeneratedVisitsByDoctor(string doctorId, List<Visit> generatedVisitsByDoctor, List<Visit> visits, Doctor doctor, Visit generatedVisit)
        {
            if (!IsDoctorAdded(doctorId, visits, generatedVisit))
                generatedVisitsByDoctor.Add(new Visit(generatedVisit.StartTime, generatedVisit.EndTime, VisitType.examination,
                            doctor, doctorId, null, "", false, false));

            return generatedVisitsByDoctor;
        }

        private static bool IsDoctorAdded(string doctorId, List<Visit> visits, Visit generatedVisit)
        {
            bool doctorIsAdded = false;
            foreach (var visit in visits)
                if (visit.DoctorId.Equals(doctorId) && IsVisitForthcoming(generatedVisit, visit)) doctorIsAdded = true;

            return doctorIsAdded;
        }

        public List<Visit> GetForthcomingVisitsByDateAndDoctor(DateTime begining, DateTime ending, string doctorId)
        {
            return _visitRepository.GetForthcomingVisitsByDateAndDoctor(begining, ending, doctorId);
        }

        private List<Visit> GetFreeGeneratedVisitsByDate(DateTime begining, DateTime ending, string doctorId)
        {
            return GetGeneratedVisitsByDate(GetGeneratedVisits(begining, ending), _visitRepository.GetAllVisits(), 
                GetFillteredDoctors(_doctorRepository.GetAllDoctors(), _doctorRepository.GetDoctorById(doctorId)));
        }

        private static List<Doctor> GetFillteredDoctors(List<Doctor> doctors, Doctor selectedDoctor)
        {
            List<Doctor> filteredDoctors = new List<Doctor>();
            foreach (var doctor in doctors)
            {
                if (selectedDoctor.Specialization == doctor.Specialization)
                    filteredDoctors.Add(doctor);
            }
            return filteredDoctors;
        }

        private static List<Visit> GetGeneratedVisitsByDate(List<Visit> generatedVisits, List<Visit> visits, List<Doctor> filteredDoctors)
        {
            List<Visit> generatedVisitsByDate = new List<Visit>();
            foreach (var generatedVisit in generatedVisits)
            {
                generatedVisitsByDate = GetAddedVisitsByDate(generatedVisitsByDate, visits, filteredDoctors, generatedVisit);
            }
            return generatedVisitsByDate;
        }

        private static List<Visit> GetAddedVisitsByDate(List<Visit> generatedVisitsByDate, List<Visit> visits, List<Doctor> filteredDoctors, Visit generatedVisit)
        {
            foreach (var doctor in filteredDoctors)
            {
                generatedVisitsByDate = GetAddedGeneratedVisitsByDate(generatedVisitsByDate, visits, generatedVisit, doctor);
            }
            return generatedVisitsByDate;
        }

        private static List<Visit> GetAddedGeneratedVisitsByDate(List<Visit> generatedVisitsByDate, List<Visit> visits, Visit generatedVisit, Doctor doctor)
        {
            if (!IsDoctorAdded(visits, generatedVisit, doctor))
            {
                doctor.Password = "";
                generatedVisitsByDate.Add(new Visit(generatedVisit.StartTime, generatedVisit.EndTime, VisitType.examination,
                            doctor, doctor.Username, null, "", false, false));
            }
            return generatedVisitsByDate;
        }

        private static bool IsDoctorAdded(List<Visit> visits, Visit generatedVisit, Doctor doctor)
        {
            bool doctorIsAdded = false;
            foreach (var visit in visits)
            {
                if (doctor.Id.Equals(visit.DoctorId))
                {
                    if (IsVisitForthcoming(generatedVisit, visit)) doctorIsAdded = true;
                }
            }

            return doctorIsAdded;
        }

        private static bool IsVisitForthcoming(Visit generatedVisit, Visit visit)
        {
            return visit.StartTime == generatedVisit.StartTime && visit.EndTime > DateTime.Now && !visit.IsCanceled;
        }

        private List<Visit> GetGeneratedVisits(DateTime begining, DateTime ending)
        {
            begining = new DateTime(begining.Year, begining.Month, begining.Day, 08, 00, 00);
            ending = new DateTime(ending.Year, ending.Month, ending.Day, 08, 00, 00);
            DateTime startOfShift = new DateTime(begining.Year, begining.Month, begining.Day, 08, 00, 00);
            DateTime endOfShift = startOfShift;
            List<Visit> generatedVisits = new List<Visit>();
            bool whileBreak = true;
            while (whileBreak)
            {
                if (IsStartOfShiftBetweenBeginingAndEnding(startOfShift, begining, ending)) whileBreak = false;
                else {
                    for (int i = 0; i < 16; i++)
                    {
                        endOfShift = startOfShift.AddMinutes(30);
                        generatedVisits.Add(new Visit(startOfShift, endOfShift, VisitType.examination,
                                    null, "", null, "", false, false));
                        startOfShift = startOfShift.AddMinutes(30);
                    }
                    startOfShift = new DateTime(startOfShift.Year, startOfShift.Month, startOfShift.Day, 08, 00, 00);
                    startOfShift = startOfShift.AddDays(1);
                    endOfShift = startOfShift;
                }
            }
            return generatedVisits;
        }

        public void ReviewVisit(Visit visitForUpdate)
        {
            visitForUpdate.IsReviewed = true;
            _visitRepository.Update(visitForUpdate);
        }

        private bool IsStartOfShiftBetweenBeginingAndEnding(DateTime startOfShift, DateTime begining, DateTime ending)
        {
            return startOfShift > ending;
        }

        public List<Visit> GetVisitsForRoom(int roomId)
        {
            return _visitRepository.GetVisitsForRoom(roomId);
        }
    }
}
