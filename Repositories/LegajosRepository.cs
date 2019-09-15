using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace EPSS.Repositories
{
	public interface ILegajosRepository
	{
		IEnumerable<Legajos> GetAll();
		Legajos Find(int id);
		Legajos FindByLegajoNro(int legajoNro);
		void Add(Legajos item);
		void Update(Legajos item);
		void Remove(int id);

	}
	public class LegajosRepository : BaseRepository, ILegajosRepository
	{
		private List<Legajos> _list;

		public LegajosRepository(ILoggerFactory loggerFactory) : base(loggerFactory)
		{

			_list = new List<Legajos>();
		}

		public void Add(Legajos item)
		{
			//item.Key=(_list.Count+1).ToString();
			//_list.Add(item);
		}

		public Legajos Find(int id)
		{
			Legajos ItemBuscado = null;
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					Alumnos AlumnoBuscado = db.Alumnos.Find(id);
					if (AlumnoBuscado != null && !AlumnoBuscado.EstaBorrado)
						ItemBuscado = db.Legajos.Find(id);
					else
						_logger.LogInformation("AlumnoID: " + id.ToString() + " --> EstaBorrado");
					_logger.LogInformation("Buscar LegajoId: " + id.ToString() + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return ItemBuscado;
		}

		public Legajos FindByLegajoNro(int legajoNro)
		{
			Legajos ItemBuscado = null;
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					ItemBuscado = db.Legajos.Single(legajo => legajo.LegajoNro == legajoNro);
					if (ItemBuscado==null)
						_logger.LogInformation("LegajoNro: " + legajoNro.ToString() + " --> NoEncontrado");
					else {
						Alumnos AlumnoBuscado = db.Alumnos.Find(ItemBuscado.AlumnoId);
						if (AlumnoBuscado.EstaBorrado) {
							ItemBuscado=null;
							_logger.LogInformation("LegajoNro: " + legajoNro.ToString() + " --> Borrado");	
						}
					}
					_logger.LogInformation("Buscar LegajoNro: " + legajoNro.ToString() + " --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return ItemBuscado;
		}

		public IEnumerable<Legajos> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					foreach (var Legajo in from ie in db.Legajos
											  .Include(Legajo => Legajo.Alumno)
												  .ThenInclude(Alumno => Alumno.Modalidad)
											  .Include(Legajo => Legajo.Alumno)
												  .ThenInclude(Alumno => Alumno.Carrera)
											  .Include(Legajo => Legajo.Alumno)
												  .ThenInclude(Alumno => Alumno.MedioDeContacto)
											  .Include(Legajo => Legajo.Alumno)
												.ThenInclude(Alumno => Alumno.Nacionalidad)
											  .Include(Legajo => Legajo.Localidad)
												  .ThenInclude(Localidad => Localidad.CodigoPostal)
											  .Include(Legajo => Legajo.Localidad)
												  .ThenInclude(Localidad => Localidad.Partido)
											  .Include(Legajo => Legajo.Estudios)
											  .Include(Legajo => Legajo.Trabajos)
											  .Include(Legajo => Legajo.EstadoEstudiante)
											  where ie.Alumno.EstaBorrado == false
											  select ie)
					{
						_list.Add(Legajo);
					}
					_logger.LogInformation("Buscar Legajos --> OK");
				}
			}
			catch (System.Exception ex)
			{
				_logger.LogError(ex.Message);
				throw ex;
			}
			return _list.AsReadOnly();
		}

		public void Remove(int id)
		{
			//_list.RemoveAll(n=>n.Key==id);
		}

		public void Update(Legajos item)
		{
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					db.Update(item);
					db.SaveChanges();
					_logger.LogInformation("Actualizar Legajo ID: " + item.AlumnoId.ToString() + "/ Legajo Nro: " + item.LegajoNro.ToString() + " --> OK");
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