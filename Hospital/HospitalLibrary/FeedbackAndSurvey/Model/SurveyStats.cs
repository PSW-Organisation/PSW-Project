namespace HospitalLibrary.FeedbackAndSurvey.Model
{
    public class SurveyStats
    {
        public int Id { get; set; } 
        public double Avg { get; set; }
        public int One { get; set; }
        public int Two { get; set; }
        public int Three { get; set; }
        public int Four { get; set; }
        public int Five { get; set; }


        public SurveyStats()
        {
            
        }
        public SurveyStats(int id, double avg, int one, int two, int three, int four, int five)
        {
            Id = id;
            Avg = avg;
            One = one;
            Two = two;
            Three = three;
            Four = four;
            Five = five;
        }
    }
}