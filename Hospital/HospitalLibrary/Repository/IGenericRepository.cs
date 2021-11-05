using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HospitalLibrary.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        T GetOneById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
