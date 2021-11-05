using ehealthcare.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HospitalLibrary.Repository.DbRepository
{
    public class GenericDbRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HospitalDbContext _dbContext;

        public GenericDbRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                Save();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetOneById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            Save();
        }
    }
}
