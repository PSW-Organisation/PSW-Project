using System.Collections.Generic;
using System.Linq;
using ehealthcare.Model;
using HospitalLibrary.FeedbackAndSurvey.Model;
using HospitalLibrary.Repository.DbRepository;

namespace HospitalLibrary.FeedbackAndSurvey.Repository
{
    public class SurveyDbRepository : GenericDbRepository<Survey>, ISurveyRepository
    {
        private readonly HospitalDbContext _context;

        public SurveyDbRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<SurveyStats> GetSurveyStats()
        {
            List<SurveyStats> stats = new List<SurveyStats>();
            var query = _context.Questions
                                            .Where(i => i.Id > 0)
                                            .GroupBy(q => q.Id)
                                            .Select(q => new
                                            {
                                                Id = q.Key,
                                                Avg = q.Average(v => v.Value),
                                                One = _context.Questions.Count(p => p.Id == q.Key && p.Value == 1),
                                                Two = _context.Questions.Count(p => p.Id == q.Key && p.Value == 2),
                                                Three = _context.Questions.Count(p => p.Id == q.Key && p.Value == 3),
                                                Four = _context.Questions.Count(p => p.Id == q.Key && p.Value == 4),
                                                Five = _context.Questions.Count(p => p.Id == q.Key && p.Value == 5),
                                            })
                                            .OrderBy(b => b.Id).ToList();
            foreach (var stat in query)
            {
                stats.Add(new SurveyStats(stat.Id, stat.Avg, stat.One, stat.Two, stat.Three, stat.Four, stat.Five));
            }
            return stats;
        }
    }
}