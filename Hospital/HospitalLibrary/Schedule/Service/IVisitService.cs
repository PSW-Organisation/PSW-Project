using ehealthcare.Model;
using HospitalLibrary.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Schedule.Service
{
    public interface IVisitService
    {
        public List<Visit> GetVisitsByUsername(string username);

        public void CancelVisit(Visit visit);
        public Visit GetVisitById(int id);
        public bool AddVisit(Visit newVisit);
        public void ReviewVisit(Visit visitForUpdate);
        public List<Visit> GetForthcomingVisitsByDateAndDoctor(DateTime beginning, DateTime ending, string doctorId);
        public List<Visit> GetАllGeneratedFreeVisits(VisitRecommendation recommendation);
        public List<Visit> GetVisitsForRoom(int roomId);
    }
}
