using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class ExteriorGraphicRepository : GenericDbRepository<ExteriorGraphic>, IExteriorGraphicRepository
    {
        private HospitalDbContext _dbContext;

        public ExteriorGraphicRepository(HospitalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
