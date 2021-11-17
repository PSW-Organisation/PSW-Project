using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository
{
	public interface GenericRepository<T> where T : Entity
	{
		public List<T> GetAll();
		public T Get(int id);
		public void SaveAll();
		public void Save(T entity);
		public void Update(T entity);
		public void Delete(int id);
		public int GenerateId();
	}
}
