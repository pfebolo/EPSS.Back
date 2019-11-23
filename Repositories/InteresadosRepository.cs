using System.Collections.Generic;
using System;
using EPSS.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
	public interface IInteresadosRepository
	{
		IEnumerable<Interesados> GetAll();
		IEnumerable<Interesados> GetAllbyPeriod(DateTime fechaFIN);
		Interesados Find(int id);
		void Add(Interesados item);
		void Update(Interesados item);
		void Remove(Interesados item);

	}
	public class InteresadosRepository : BaseRepository, IInteresadosRepository
	{
		private List<Interesados> _list;

		public InteresadosRepository(ILoggerFactory loggerFactory) : base(loggerFactory)
		{

			_list = new List<Interesados>();
		}

		public void Add(Interesados item)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					db.Interesados.Add(item);
					db.SaveChanges();

					_logger.LogInformation("Crear Alumno (" + item.InteresadoId.ToString() + "), E-Mail:" + item.Mail + " --> Ok");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
		}

		public Interesados Find(int id)
		{
			Interesados InteresadoBuscado = null;
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					InteresadoBuscado = db.Interesados.Find(id);
					if (InteresadoBuscado!=null) {
					if (InteresadoBuscado.ModalidadId.HasValue)
						InteresadoBuscado.Modalidad = db.Modalidades.Find(InteresadoBuscado.ModalidadId);
					if (InteresadoBuscado.CarreraId.HasValue)
						InteresadoBuscado.Carrera = db.Carreras.Find(InteresadoBuscado.CarreraId);
					if (InteresadoBuscado.MedioDeContactoId.HasValue)
						InteresadoBuscado.MedioDeContacto =db.MediosDeContacto.Find(InteresadoBuscado.MedioDeContactoId);
					}
					_logger.LogInformation("Buscar InteresadoId: " + id.ToString() + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return InteresadoBuscado;
		}

		public IEnumerable<Interesados> GetAll()
		{
			_list.Clear();

			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					foreach (var Interesado in db.Interesados.Include(a => a.Modalidad).Include(c => c.Carrera).Include(m => m.MedioDeContacto))
					{
						_list.Add(Interesado);
					}
					_logger.LogInformation("Buscar Interesados --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}


		public IEnumerable<Interesados> GetAllbyPeriod(DateTime fechaFIN)
		{
			_list.Clear();

			DateTime fechaINI = fechaFIN.AddMonths(-2); //TODO: Obtener de configuración

			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					foreach (var Interesado in db.Interesados.Where(a => a.FechaInteresado >= fechaINI && a.FechaInteresado <= fechaFIN).Include(a => a.Modalidad).Include(c => c.Carrera).Include(m => m.MedioDeContacto))
					{
						_list.Add(Interesado);
					}
					_logger.LogInformation("Buscar Interesados --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}


		public void Update(Interesados item)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					db.Update(item);
					db.SaveChanges();
					_logger.LogInformation("Actualizar Interesado ID: " + item.InteresadoId.ToString() + "/ Mail: " + item.Mail + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
		}


		public void Remove(Interesados item)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					db.Remove(item);
					db.SaveChanges();
					_logger.LogInformation("Eliminado Interesado ID: " + item.InteresadoId.ToString() + " --> OK");
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