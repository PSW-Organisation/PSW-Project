using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ehealthcare.Model;

namespace HospitalLibrary.Repository.DbRepository
{
    public interface IGenericSTRINGIDRepository<T> where T : Entity
    {
        void Delete(T entity);
        T Get(string id);
        IList<T> GetAll();
        void Insert(T entity);
        void Save(T entity);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        T Update(T entity);
    }
}