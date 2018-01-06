using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EPSS.Repositories
{
	//Extiende la Interfaz Génerica con métodos especificos del Modelo
	public interface IGruposRepository : IRepository<Grupos>
	{
		IEnumerable<Grupos> FindByAlumnoId(int alumnoId);
		void MasiveAdd(Grupos[] items);
	}
	public class GruposRepository : BaseRepositoryNew<Grupos>, IGruposRepository
	{

		public GruposRepository(ILoggerFactory loggerFactory) : base(loggerFactory) { }

		public override IEnumerable<Grupos> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{//
					foreach (var Grupo in db.Grupos.Include(Grupo => Grupo.Division)
														  .ThenInclude(Division => Division.Curso)
															  .ThenInclude(Curso => Curso.Carrera)
													  .Include(Grupo => Grupo.Legajo)
														  .ThenInclude(Legajo => Legajo.Alumno)
													  .Include(Grupo => Grupo.Legajo)
														  .ThenInclude(Legajo => Legajo.EstadoEstudiante))
					{
						_list.Add(Grupo);
					}
					_logger.LogInformation("Buscar Grupos --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}
		public IEnumerable<Grupos> FindByAlumnoId(int AlumnoId)
		{
			List<Grupos> buscados = new List<Grupos>();
			try
			{
				using (var db = new escuelapsdelsurContext())

				{
					foreach (var grupo in from gr in db.Grupos.Include(Grupo => Grupo.Division)
															.ThenInclude(Division => Division.Curso)
															.ThenInclude(Curso => Curso.Carrera)
										  where gr.AlumnoId == AlumnoId
										  select gr)
					{
						buscados.Add(grupo);
					}
					_logger.LogInformation("Buscar Grupos x AlumnoId " + AlumnoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return buscados.AsReadOnly();

		}

		public virtual void MasiveAdd(Grupos[] items)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					foreach (Grupos item in items)
					{
						db.Grupos.Add(item);
					}
					db.SaveChanges();
					_logger.LogInformation("Crear grupos masivo --> Ok");
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