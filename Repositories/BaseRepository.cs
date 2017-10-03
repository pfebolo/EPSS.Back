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
			// item = default(Model);
			// _list.Add(item);
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					db.Set<Model>().Add(item);
					db.SaveChanges();

					_logger.LogInformation("Crear " + typeof(Model).Name + "--> Ok");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}


		}

		public virtual Model Find(params Object[] KeyValues)
		{
			//return default(Model);

			Model ItemBuscado = null;
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					ItemBuscado = db.Set<Model>().Find(KeyValues);
					_logger.LogInformation("Buscar " + typeof(Model).Name + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return ItemBuscado;
		}

		public virtual IEnumerable<Model> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					foreach (var item in db.Set<Model>())
					{
						_list.Add(item);
					}
				}
				_logger.LogInformation("Buscar " + typeof(Model).Name + " --> OK");
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}

		public virtual void Update(Model item)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					db.Update(item);
					db.SaveChanges();
					_logger.LogInformation("Actualizar " + typeof(Model).Name + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
		}

		public virtual void Remove(Model item)
		{
			try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    db.Remove(item);
                    db.SaveChanges();
                    _logger.LogInformation("Eliminar " + typeof(Model).Name + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
		}
	}
}
