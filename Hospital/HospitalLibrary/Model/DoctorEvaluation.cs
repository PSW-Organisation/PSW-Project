using System;

namespace Model
{
   public class DoctorEvaluation
   {
        public int Rating { get; set; }
        public String Comment { get; set; }
        public int Id { get; set; }
        public Boolean IsDeleted { get; set; }
        public Doctor Doctor { get; set; }

        public DoctorEvaluation(int r, String c, int i, Boolean id, Doctor d)
        {
            this.Rating = r;
            this.Comment = c;
            this.Id = i;
            this.IsDeleted = id;
            this.Doctor = d;
        }

    }
}