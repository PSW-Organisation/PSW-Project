using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository.XMLRepository
{
	public class GenericXMLRepository<T> where T : Entity
	{
		private List<T> repository;
		private string fileName;
		public GenericXMLRepository(string fileName)
		{
			this.fileName = fileName;
			DataIO dataIO = new DataIO();
			repository = dataIO.DeSerializeObject<List<T>>(fileName);
			if (repository == null)
			{
				repository = new List<T>();
			}
		}

		public List<T> GetAll()
		{
			return repository;
		}

		public T Get(string id)
		{
			foreach (T entity in repository)
			{
				if (entity.Id == id)
				{
					return entity;
				}
			}
			return null;
		}

		public void SaveAll()
		{
			DataIO dataIO = new DataIO();
			GenerateIdsIfNeeded();
			dataIO.SerializeObject(repository, fileName);
		}

		public void Save(T entity)
		{
			repository.Add(entity);
			SaveAll();
		}

		public void Update(T entity)
		{
			for (int i = repository.Count - 1; i >= 0; i--)
			{
				if (repository[i].Id == entity.Id)
				{
					repository.RemoveAt(i);
					repository.Insert(i, entity);
					break;
				}
			}
			SaveAll();
		}

		public void Delete(string id)
		{
			foreach (T entity in repository)
			{
				if (entity.Id == id)
				{
					repository.Remove(entity);
					break;
				}
			}
			SaveAll();
		}

		public void GenerateIdsIfNeeded()
		{
			foreach (T entity in repository)
			{
				if(entity.Id == "undefinedNumberKey")
				{
					entity.Id = GenerateId();
				}
			}
		}

		public string GenerateId()
		{
			
				int maxId = 0;
				foreach (T entity in repository)
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
				return (maxId + 1).ToString();
		}
	}
}
