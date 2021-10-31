using System;

namespace Model
{
   public class HospitalEvaluation
   {
        public int Rating { get; set; }
        public String Comment { get; set; }
        public int Id { get; set; }
        public Boolean IsDeleted { get; set; }

        public HospitalEvaluation(int r, String c, int i, Boolean d)
        {
            this.Rating = r;
            this.Comment = c;
            this.Id = i;
            this.IsDeleted = d;
        }
    }
}