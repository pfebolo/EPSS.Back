using System.Collections.Generic;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
namespace EPSS.Repositories
{
    public class CursosRepository: BaseRepositoryNew<Cursos>
    {

        public CursosRepository(ILoggerFactory loggerFactory) : base (loggerFactory){}

        public override IEnumerable<Cursos> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var item in db.Cursos.Include(Curso => Curso.Carrera))
                {
                    _list.Add(item);
                }
               _logger.LogInformation("Buscar Cursos --> OK");
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