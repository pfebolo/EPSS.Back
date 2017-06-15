using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Repositories
{
    public interface IEventosRepository
    {
        IEnumerable<Eventos> GetAll();
        Eventos Find(int id);
        void Add(Eventos item);
        void Remove(int id);

    }
    public class EventosRepository: BaseRepository,IEventosRepository
    {
        private List<Eventos> _list;

        public EventosRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Eventos>();
        }

        public void Add(Eventos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Eventos Find(int id)
        {
            // return _list.Find(n=>n.EventosId==id);
            return _list.Find(n=>n.Id==id);
        }

        public IEnumerable<Eventos> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Evento in db.Eventos.Include(Evento => Evento.Lugar))
                {
                    _list.Add(Evento);
                }
               _logger.LogInformation("Buscar Eventos --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            _logger.LogError(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}