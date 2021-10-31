using Model;
using System;
using System.Collections.Generic;
using vezba.Repository;

namespace Service
{
   public class DoctorEvaluationService
   {
        private IDoctorEvaluationRepository DoctorEvaluationRepository { get; set; }
        public DoctorEvaluationService()
        {
            DoctorEvaluationRepository = new DoctorEvaluationFileRepository();
        }

        public Boolean SaveEvaluation(DoctorEvaluation newEvaluation)
        {
            return DoctorEvaluationRepository.Save(newEvaluation);
        }
    }
}