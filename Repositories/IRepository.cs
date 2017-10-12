using System.Collections.Generic;
using System;

namespace EPSS.Repositories
{
	public interface IRepository<Model>
	{
		IEnumerable<Model> GetAll();
		Model Find(params Object[] KeyValues);
		void Add(Model item);
		void Update(Model item);
		void Remove(Model item);
	}
}