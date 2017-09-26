using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EPSS.Models;



namespace EPSS.Repositories
{
	public class BaseRepository
	{
		protected ILogger _logger;

		public BaseRepository(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger(this.GetType().ToString());
		}


	}


	public class BaseRepositoryNew<Model> : IRepository<Model> where Model : class
	{
		protected ILogger _logger;
		protected List<Model> _list;

		public BaseRepositoryNew(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger(this.GetType().ToString());
			_list = new List<Model>();
		}

		public virtual void Add(Model item)
		{
			item = default(Model);
			_list.Add(item);
		}

		public virtual Model Find(int id)
		{
			return default(Model);
		}

		public virtual IEnumerable<Model> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db =  new escuelapsdelsurContext())
				{
					foreach (var item in db.Set<Model>())
					{
						_list.Add(item);
					}
				}
				_logger.LogInformation("Buscar " + typeof(Model).Name +" --> OK");
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}

		public virtual void Update(Model item)
		{
		}

		public virtual void Remove(int id)
		{
			//_list.RemoveAll(n=>n.Key==id);
		}
	}
}
