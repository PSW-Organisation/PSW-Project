using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository
{
	public interface GenericRepository<T> where T : class
	{
		public List<T> GetAll();
		public T Get(int id);
		public void Save(T entity);
		public void SaveAll();
		public T Update(T entity);
		void Insert(T entity);
		public int GenerateId();
		public void GenerateIdIfNeeded();
		
		IEnumerable<T> Search(Expression<Func<T, bool>> predicate);

		public void Delete(T entity);
		
	}
}
