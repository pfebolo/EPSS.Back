using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;



namespace EPSS.Repositories
{
	public class DivisionesRepository : BaseRepositoryNew<Divisiones>
	{

		public DivisionesRepository(ILoggerFactory loggerFactory) : base(loggerFactory) { }

		public override IEnumerable<Divisiones> GetAll()
		{
			_list.Clear();
			try
			{
				using (var db = new escuelapsdelsurContext())
				{
					foreach (var Division in db.Divisiones.Include(Division => Division.Curso).ThenInclude(Curso => Curso.Carrera))
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
          Cursos Curso =  db.Cursos.Find(item.Curso.CarreraId,item.Curso.ModoId,item.Curso.AnioInicio,item.Curso.MesInicio,item.Curso.AnioLectivo,item.Curso.NmestreLectivo);
          if (Curso != null) {
            item.Curso=null;
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

	}
}