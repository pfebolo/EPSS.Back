using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;



namespace EPSS.Repositories
{
    public class GruposXxxRepository: BaseRepositoryNew<GruposXxx>
    {

        public GruposXxxRepository(ILoggerFactory loggerFactory) : base (loggerFactory){}

        public override IEnumerable<GruposXxx> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {//
              foreach (var Grupo in db.GruposXxx.Include(Grupo => Grupo.Division)
                                                    .ThenInclude(Division => Division.CursosXxx)
                                                        .ThenInclude(Curso => Curso.Carrera)
                                                .Include(Grupo => Grupo.LegajoNew))
                {
                    _list.Add(Grupo);
                }
               _logger.LogInformation("Buscar GruposXxx --> OK");
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