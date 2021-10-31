using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using vezba.Command;

namespace vezba.ViewModel.PatientViewModel
{
    public class GradeHospitalViewModel
    {
        public NavigationService NavigationService { get; set; }
        public int SelectedGrade { get; set; }
        public String CommentInput { get; set; }
        private HospitalEvaluationService HospitalEvaluationService { get; set; }
        public RelayCommand GradeHospitalCommand { get; set; }
        public GradeHospitalViewModel(NavigationService navigation)
        {
            NavigationService = navigation;
            HospitalEvaluationService = new HospitalEvaluationService();

            GradeHospitalCommand = new RelayCommand(Execute_OrderAppointmentCommand, CanExecuteCommand);
        }

        public void Execute_OrderAppointmentCommand(object obj)
        {
            HospitalEvaluation hospitalEvaluation = AddEvaluation();
            Boolean saved = HospitalEvaluationService.SaveEvaluation(hospitalEvaluation);
            if (saved)
            {
                var s = new SuccessfulGradeHospital();
                s.Show();
            }
        }

        public bool CanExecuteCommand(object obj)
        {
            return true;
        }

        private HospitalEvaluation AddEvaluation()
        {
            int rating = 0;
            switch (SelectedGrade)
            {
                case 0:
                    rating = 1;
                    break;
                case 1:
                    rating = 2;
                    break;
                case 2:
                    rating = 3;
                    break;
                case 3:
                    rating = 4;
                    break;
                case 4:
                    rating = 5;
                    break;
                default:
                    rating = 1;
                    break;
            }
            HospitalEvaluation hospitalEvaluation = new HospitalEvaluation(rating, CommentInput, 0, false);
            return hospitalEvaluation;
        }
    }
}
