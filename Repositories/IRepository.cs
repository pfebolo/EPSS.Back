using System.Collections.Generic;
using System;

namespace EPSS.Repositories
{
	public interface IRepository<Model>
	{
		IEnumerable<Model> GetAll();
		Model Find(int id);
		void Add(Model item);
		void Update(Model item);
		void Remove(int id);
	}
}