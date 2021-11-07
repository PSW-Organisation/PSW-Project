using ehealthcare.Model;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Repository
{
    public class ExteriorGraphicRepository : IExteriorGraphicRepository
    {
        private HospitalDbContext _dbContext;

        public ExteriorGraphicRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public string GenerateId()
        {
            throw new NotImplementedException();
        }

        public ExteriorGraphic Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<ExteriorGraphic> GetAll()
        {
            return _dbContext.ExteriorGraphic.ToList();
        }

        public void Save(ExteriorGraphic entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ExteriorGraphic entity)
        {
            throw new NotImplementedException();
        }
    }
}
