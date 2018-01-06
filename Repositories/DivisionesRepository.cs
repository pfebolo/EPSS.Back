using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EPSS.Repositories
{

	//Extiende la Interfaz Génerica con métodos especificos del Modelo
	public interface IDivisionesRepository : IRepository<Divisiones>
	{
		void Promover(Divisiones divisionOrigen,Divisiones divisiondestino);
	}


	public class DivisionesRepository : BaseRepositoryNew<Divisiones>, IDivisionesRepository
	{

		public DivisionesRepository(ILoggerFactory loggerFactory) : base(loggerFactory) { }

		public override IEnumerable<Divisiones> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					foreach (var Division in db.Divisiones
													.Include(Division => Division.Curso)
														.ThenInclude(Curso => Curso.Carrera)
													.OrderBy(d => d.CarreraId)
														.ThenBy(d => d.AnioInicio)
														.ThenBy(d => d.MesInicio)
														.ThenBy(d => d.AnioLectivo)
														.ThenBy(d => d.NmestreLectivo)
														.ThenBy(d => d.TurnoId)
														.ThenBy(d => d.DivisionId)
														)
					{
						_list.Add(Division);
					}
					_logger.LogInformation("Buscar Divisiones --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return _list.AsReadOnly();
		}

		public override void Add(Divisiones item)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					Cursos Curso = db.Cursos.Find(item.Curso.CarreraId, item.Curso.ModoId, item.Curso.AnioInicio, item.Curso.MesInicio, item.Curso.AnioLectivo, item.Curso.NmestreLectivo);
					if (Curso != null)
					{
						item.Curso = null;
					}
					db.Divisiones.Add(item);
					db.SaveChanges();

					_logger.LogInformation("Crear " + typeof(Divisiones).Name + "--> Ok");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
		}

		public override void Update(Divisiones item)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					if (item.Curso != null)
					{
						db.Cursos.Update(item.Curso);
						item.Curso = null;
					}
					db.Divisiones.Update(item);
					db.SaveChanges();

					_logger.LogInformation("Crear " + typeof(Divisiones).Name + "--> Ok");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
		}

		public void Promover(Divisiones divisionOrigen,Divisiones divisionDestino)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					var estudiantesAsignados = db.Grupos.Where(d => d.CarreraId == divisionOrigen.CarreraId 
														&& d.ModoId  == divisionOrigen.ModoId
														&& d.AnioInicio  == divisionOrigen.AnioInicio
														&& d.MesInicio  == divisionOrigen.MesInicio
														&& d.AnioLectivo  == divisionOrigen.AnioLectivo
														&& d.NmestreLectivo  == divisionOrigen.NmestreLectivo
														&& d.TurnoId == divisionOrigen.TurnoId
														&& d.DivisionId == divisionOrigen.DivisionId);
					foreach (var estudianteAsigando in estudiantesAsignados)
					{
						Grupos nuevaAsignacion = new Grupos();
						nuevaAsignacion.CarreraId = divisionDestino.CarreraId;
						nuevaAsignacion.ModoId  = divisionDestino.ModoId;
						nuevaAsignacion.AnioInicio  = divisionDestino.AnioInicio;
						nuevaAsignacion.MesInicio  = divisionDestino.MesInicio;
						nuevaAsignacion.AnioLectivo = divisionDestino.AnioLectivo;
						nuevaAsignacion.NmestreLectivo  = divisionDestino.NmestreLectivo;
						nuevaAsignacion.TurnoId = divisionDestino.TurnoId;
						nuevaAsignacion.DivisionId = divisionDestino.DivisionId;
						nuevaAsignacion.AlumnoId = estudianteAsigando.AlumnoId;

						db.Grupos.Add(nuevaAsignacion);
					}
					divisionOrigen.EstadoDivisionId="Terminado";
					db.Divisiones.Update(divisionOrigen);
					db.SaveChanges();

					_logger.LogInformation("Promoción " + "--> Ok");
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