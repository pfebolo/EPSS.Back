using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Repositories
{
    public interface IInteresadosEventosRepository
    {
        IEnumerable<InteresadosEventos> GetAll();
        InteresadosEventos Find(int id);
        void Add(InteresadosEventos item);
        void Remove(int id);

    }
    public class InteresadosEventosRepository : BaseRepository, IInteresadosEventosRepository
    {
        private List<InteresadosEventos> _list;

        public InteresadosEventosRepository(ILoggerFactory loggerFactory) : base(loggerFactory)
        {

            _list = new List<InteresadosEventos>();
        }

        public void Add(InteresadosEventos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public InteresadosEventos Find(int id)
        {
            // return _list.Find(n=>n.InteresadosEventosId==id);
            return _list.Find(n => n.Id == id);
        }

        public IEnumerable<InteresadosEventos> GetAll()
        {
            _list.Clear();
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    foreach (var InteresadoEvento in db.InteresadosEventos.Include(InteresadoEvento => InteresadoEvento.Evento).Include(InteresadoEvento => InteresadoEvento.Interesado))
                    // foreach (var InteresadoEvento in db.InteresadosEventos)
                    // foreach (var InteresadoEvento in db.InteresadosEventos.Include(InteresadoEvento => InteresadoEvento.Evento))
                    {
                        _list.Add(InteresadoEvento);
                    }
                    _logger.LogInformation("Buscar InteresadosEventos --> OK");
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