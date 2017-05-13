using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IPartidosRepository
    {
        IEnumerable<Partidos> GetAll();
        Partidos Find(string id);
        void Add(Partidos item);
        void Remove(string id);

    }
    public class PartidosRepository: BaseRepository,IPartidosRepository
    {
        private List<Partidos> _list;

        public PartidosRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Partidos>();
        }

        public void Add(Partidos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Partidos Find(string id)
        {
            // return _list.Find(n=>n.PartidosId==id);
            return _list.Find(n=>n.ProvinciaId==id);
        }

        public IEnumerable<Partidos> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Partido in db.Partidos.Include(Partido => Partido.Provincia).ThenInclude(Provincia => Provincia.Pais))
                {
                    _list.Add(Partido);
                }
               _logger.LogInformation("Buscar Partidos --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            _logger.LogError(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(string id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}