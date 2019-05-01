using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EPSS.Repositories
{
	//Extiende la Interfaz Génerica con métodos especificos del Modelo
	public interface IInteraccionesInteresadosRepository : IRepository<InteraccionesInteresados>
	{
		IEnumerable<InteraccionesInteresados> FindByInteresadoId(int alumnoId);
	}
	public class InteraccionesInteresadosRepository : BaseRepositoryNew<InteraccionesInteresados>, IInteraccionesInteresadosRepository 
	{

		public InteraccionesInteresadosRepository(ILoggerFactory loggerFactory) : base(loggerFactory) { }

		public override IEnumerable<InteraccionesInteresados> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{//
					foreach (var InteraccionInteresado in db.InteraccionesInteresados.Include(InteraccionInteresado => InteraccionInteresado.Interesado)
														  )
					{
						_list.Add(InteraccionInteresado);
					}
					_logger.LogInformation("Buscar InteraccionesInteresados --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}
		public IEnumerable<InteraccionesInteresados> FindByInteresadoId(int InteresadoId)
		{
			List<InteraccionesInteresados> buscados = new List<InteraccionesInteresados>();
			try
			{
				using (var db = new escuelapsdelsurContext())

				{
					foreach (var InteraccionInteresado in from intac in db.InteraccionesInteresados.Include(InteraccionInteresado => InteraccionInteresado.Interesado)
													where intac.InteresadoId == InteresadoId
										  select intac)
					{
						buscados.Add(InteraccionInteresado);
					}
					_logger.LogInformation("Buscar InteraccionesInteresados x AlumnoId " + InteresadoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
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