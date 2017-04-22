using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IGruposRepository
    {
        IEnumerable<Grupos> GetAll();
        Grupos Find(int id);
        void Add(Grupos item);
        void Remove(int id);

    }
    public class GruposRepository: BaseRepository,IGruposRepository
    {
        private List<Grupos> _list;

        public GruposRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Grupos>();
        }

        public void Add(Grupos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Grupos Find(int id)
        {
            // return _list.Find(n=>n.GruposId==id);
            return _list.Find(n=>n.AlumnoId==id);
        }

        public IEnumerable<Grupos> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Grupo in db.Grupos
                                    .Include(Grupo => Grupo.Legajo)
                                        .ThenInclude(Legajo => Legajo.Alumno)
                                    .Include(Grupo => Grupo.Curso))
                {
                    _list.Add(Grupo);
                }
               _logger.LogInformation("Buscar Grupos --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            _logger.LogInformation(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}