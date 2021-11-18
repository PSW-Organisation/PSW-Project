using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HospitalLibrary.Repository.DbRepository
{
    public class GenericSTRINGIDRepository<T> : IGenericSTRINGIDRepository<T> where T : Entity
    {
        private readonly HospitalDbContext _dbContext;

        public GenericSTRINGIDRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                Save(entity);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public IList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Get(string id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            Save(entity);
        }

        public void Save(T entity)
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            Save(entity);
            return entity;
        }
    }
}