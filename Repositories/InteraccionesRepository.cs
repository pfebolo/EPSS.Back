using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EPSS.Repositories
{
	//Extiende la Interfaz Génerica con métodos especificos del Modelo
	public interface IInteraccionesRepository : IRepository<Interacciones>
	{
		IEnumerable<Interacciones> FindByAlumnoId(int alumnoId);
	}
	public class InteraccionesRepository : BaseRepositoryNew<Interacciones>, IInteraccionesRepository 
	{

		public InteraccionesRepository(ILoggerFactory loggerFactory) : base(loggerFactory) { }

		public override IEnumerable<Interacciones> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{//
					foreach (var Interaccion in db.Interacciones.Include(Interaccion => Interaccion.Legajo)
														  )
					{
						_list.Add(Interaccion);
					}
					_logger.LogInformation("Buscar Interacciones --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}
		public IEnumerable<Interacciones> FindByAlumnoId(int AlumnoId)
		{
			List<Interacciones> buscados = new List<Interacciones>();
			try
			{
				using (var db = new escuelapsdelsurContext())

				{
					foreach (var interaccion in from intac in db.Interacciones.Include(Interaccion => Interaccion.Legajo)
													where intac.AlumnoId == AlumnoId
										  select intac)
					{
						buscados.Add(interaccion);
					}
					_logger.LogInformation("Buscar Interacciones x AlumnoId " + AlumnoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return buscados.AsReadOnly();

		}

	}
}