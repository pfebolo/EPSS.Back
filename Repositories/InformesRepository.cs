using System.Collections.Generic;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EPSS.Repositories
{
	//Extiende la Interfaz Génerica con métodos especificos del Modelo
	public interface IInformesRepository : IRepository<Informes>
	{
		IEnumerable<Informes> FindByAlumnoId(int alumnoId);
	}
	public class InformesRepository : BaseRepositoryNew<Informes>, IInformesRepository 
	{

		public InformesRepository(ILoggerFactory loggerFactory) : base(loggerFactory) { }

		public override IEnumerable<Informes> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{//
					foreach (var Informe in db.Informes.Include(Informe => Informe.Legajo)
														  )
					{
						_list.Add(Informe);
					}
					_logger.LogInformation("Buscar Informes --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}
		public IEnumerable<Informes> FindByAlumnoId(int AlumnoId)
		{
			List<Informes> buscados = new List<Informes>();
			try
			{
				using (var db = new escuelapsdelsurContext())

				{
					foreach (var Informe in from Info in db.Informes.Include(Informe => Informe.Legajo)
													where Info.AlumnoId == AlumnoId
										  select Info)
					{
						buscados.Add(Informe);
					}
					_logger.LogInformation("Buscar Informes x AlumnoId " + AlumnoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
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