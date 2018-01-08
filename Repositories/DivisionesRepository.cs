using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EPSS.Repositories
{
	public class EstadoDivisionExpectedException : Exception
	{
		public EstadoDivisionExpectedException()
		{
		}

		public EstadoDivisionExpectedException(string message)
			: base(message)
		{
		}

		public EstadoDivisionExpectedException(string message, Exception inner)
			: base(message, inner)
		{
		}

	}

	//Extiende la Interfaz Génerica con métodos especificos del Modelo
	public interface IDivisionesRepository : IRepository<Divisiones>
	{
		void Promover(Divisiones divisionOrigen, Divisiones divisiondestino);
		void Egresar(Divisiones division);
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

		public void Promover(Divisiones divisionOrigen, Divisiones divisionDestino)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					var estudiantesAsignados = db.Grupos.Where(d => d.CarreraId == divisionOrigen.CarreraId
														&& d.ModoId == divisionOrigen.ModoId
														&& d.AnioInicio == divisionOrigen.AnioInicio
														&& d.MesInicio == divisionOrigen.MesInicio
														&& d.AnioLectivo == divisionOrigen.AnioLectivo
														&& d.NmestreLectivo == divisionOrigen.NmestreLectivo
														&& d.TurnoId == divisionOrigen.TurnoId
														&& d.DivisionId == divisionOrigen.DivisionId);
					foreach (var estudianteAsigando in estudiantesAsignados)
					{
						Grupos nuevaAsignacion = new Grupos();
						nuevaAsignacion.CarreraId = divisionDestino.CarreraId;
						nuevaAsignacion.ModoId = divisionDestino.ModoId;
						nuevaAsignacion.AnioInicio = divisionDestino.AnioInicio;
						nuevaAsignacion.MesInicio = divisionDestino.MesInicio;
						nuevaAsignacion.AnioLectivo = divisionDestino.AnioLectivo;
						nuevaAsignacion.NmestreLectivo = divisionDestino.NmestreLectivo;
						nuevaAsignacion.TurnoId = divisionDestino.TurnoId;
						nuevaAsignacion.DivisionId = divisionDestino.DivisionId;
						nuevaAsignacion.AlumnoId = estudianteAsigando.AlumnoId;

						db.Grupos.Add(nuevaAsignacion);
					}
					divisionOrigen.EstadoDivisionId = "Terminado";
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

		public void Egresar(Divisiones division)
		{
			try
			{
				if (division.EstadoDivisionId == EstadosDivision.Estados[(int)EstadoDivisionId.Cursando])
				{
					bool TerminarDivision = true;
					using (var db = new escuelapsdelsurContext())
					{
						var estudiantesAsignados = db.Grupos.Include(g => g.Legajo).Where(d => d.CarreraId == division.CarreraId
															&& d.ModoId == division.ModoId
															&& d.AnioInicio == division.AnioInicio
															&& d.MesInicio == division.MesInicio
															&& d.AnioLectivo == division.AnioLectivo
															&& d.NmestreLectivo == division.NmestreLectivo
															&& d.TurnoId == division.TurnoId
															&& d.DivisionId == division.DivisionId);
						foreach (Grupos estudianteAsigando in estudiantesAsignados)
						{
							Legajos legajo = estudianteAsigando.Legajo;
							if (legajo.EstadoEstudianteId == Enum.GetName(typeof(EstadoEstudianteId), EstadoEstudianteId.Activo))
							{
								legajo.EstadoEstudianteId = Enum.GetName(typeof(EstadoEstudianteId), EstadoEstudianteId.Egresado);
								db.Legajos.Update(legajo);
							}
							TerminarDivision &= !(legajo.EstadoEstudianteId == Enum.GetName(typeof(EstadoEstudianteId), EstadoEstudianteId.Suspendido));
						}
						if (TerminarDivision)
						{
							division.EstadoDivisionId = EstadosDivision.Estados[(int)EstadoDivisionId.Terminado];
							db.Divisiones.Update(division);
						}
						db.SaveChanges();
						_logger.LogInformation("Egresar " + "--> Ok");
					}
				}
				else
					throw new EstadoDivisionExpectedException("Se esperaba el estado: " + EstadosDivision.Estados[(int)EstadoDivisionId.Cursando]);
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
		}
	}
}