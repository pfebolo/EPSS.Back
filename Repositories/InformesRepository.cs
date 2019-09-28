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
		Informes FindByInforme(int alumnoId,int coordinadoraId, int anioLectivo);
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
													   .Include(Informe => Informe.Coordinador))
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
		public IEnumerable<Informes> FindByAlumnoId(int alumnoId)
		{
			List<Informes> buscados = new List<Informes>();
			try
			{
				using (var db = new escuelapsdelsurContext())

				{
					foreach (var Informe in from Info in db.Informes.Include(Informe => Informe.Legajo)
																	.Include(Informe => Informe.Coordinador)
															where Info.AlumnoId == alumnoId
										  					select Info)
					{
						buscados.Add(Informe);
					}
					_logger.LogInformation("Buscar Informes x AlumnoId " + alumnoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return buscados.AsReadOnly();

		}

		public Informes FindByInforme(int alumnoId,int coordinadoraId, int anioLectivo)
		{
			Informes informe = null;
			List<Informes> buscados = new List<Informes>();
			try
			{
				using (var db = new escuelapsdelsurContext())

				{
					foreach (var Informe in from Info in db.Informes.Include(Informe => Informe.Legajo)
																	.Include(Informe => Informe.Coordinador)
															where Info.AlumnoId == alumnoId
															  && Info.CoordinadorId == coordinadoraId
															  && Info.AnioLectivo == anioLectivo
										  					select Info)
					{
						buscados.Add(Informe);
					}
					if (buscados.Count == 1) {
						informe = buscados.ElementAt(0);
						_logger.LogInformation("Buscar Informes x UniqueKey (" + alumnoId.ToString() + ", " + coordinadoraId.ToString() + ", " + anioLectivo.ToString() +  ") --> OK");
						}
					else
						_logger.LogInformation("Buscar Informes x UniqueKey (" + alumnoId.ToString() + ", " + coordinadoraId.ToString() + ", " + anioLectivo.ToString() +  ") --> OK (No encontrado)");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return informe;

		}

	}
}