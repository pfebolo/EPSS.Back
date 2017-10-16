using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;



namespace EPSS.Repositories
{
    public class GruposRepository: BaseRepositoryNew<Grupos>
    {

        public GruposRepository(ILoggerFactory loggerFactory) : base (loggerFactory){}

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
                                                    .ThenInclude(Legajo => Legajo.Alumno))
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

    }
}