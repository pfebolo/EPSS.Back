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
        void Update(Eventos item);
        void Remove(int id);
    }
    public class EventosRepository : BaseRepository, IEventosRepository
    {
        private List<Eventos> _list;

        public EventosRepository(ILoggerFactory loggerFactory) : base(loggerFactory)
        {

            _list = new List<Eventos>();
        }

        public void Add(Eventos item)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    db.Eventos.Add(item);
                    db.SaveChanges();

                    _logger.LogInformation("Crear Evento (" + item.Id.ToString() + ") --> Ok");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
        public Eventos Find(int id)
        {
            Eventos EventoBuscado = null;
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    EventoBuscado = db.Eventos.Find(id);
                    _logger.LogInformation("Buscar EventoId: " + id.ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return EventoBuscado;
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

        public void Update(Eventos item)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    db.Update(item);
                    db.SaveChanges();
                    _logger.LogInformation("Actualizar Evento ID: " + item.Id.ToString() + " --> OK");
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