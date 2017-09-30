using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;



namespace EPSS.Repositories
{
    public class DivisionesRepository: BaseRepositoryNew<Divisiones>
    {

        public DivisionesRepository(ILoggerFactory loggerFactory) : base (loggerFactory){}

        public override IEnumerable<Divisiones> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Division in db.Divisiones.Include(Division => Division.CursosXxx))
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

    }
}