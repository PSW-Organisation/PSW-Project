using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class GenericDatabaseRepository<T> : GenericRepository<T> where T : Entity
    {
        private readonly IntegrationDbContext _dbContext;

        public GenericDatabaseRepository(IntegrationDbContext context)
        {
            this._dbContext = context;
        }

        public void Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                SaveAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       
        public int GenerateId()
        {
            int maxId = 0;
            foreach (T entity in _dbContext.Set<T>().ToList())
            {
                try
                {
                    int maxCandidate = Convert.ToInt32(entity.Id);
                    if (maxCandidate > maxId)
                    {
                        maxId = maxCandidate;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return (maxId + 1);
        }

        public void GenerateIdIfNeeded()
        {
            foreach (T entity in _dbContext.Set<T>().ToList())
            {
                if (entity.Id == -1)
                {
                    entity.Id = GenerateId();
                }
            }
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

     

        public void Save(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void SaveAll()
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
            SaveAll();
            return entity;
        }
    }
}
