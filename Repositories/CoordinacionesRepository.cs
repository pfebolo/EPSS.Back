using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;



namespace EPSS.Repositories
{
    public class CoordinacionesRepository: BaseRepositoryNew<Coordinaciones>
    {

        public CoordinacionesRepository(ILoggerFactory loggerFactory) : base (loggerFactory){}

        public override IEnumerable<Coordinaciones> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {//
              foreach (var Coordinacion in db.Coordinaciones.Include(Coordinacion => Coordinacion.Coordinador))
                {
                    _list.Add(Coordinacion);
                }
               _logger.LogInformation("Buscar Coordinaciones --> OK");
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