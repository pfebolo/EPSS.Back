using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EPSS.Repositories
{
    public interface IInteresadosEventosRepository
    {
        IEnumerable<InteresadosEventos> GetAll();
        InteresadosEventos Find(int id);
        IEnumerable<InteresadosEventos> FindByEventoId(int eventoId);
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


        public IEnumerable<InteresadosEventos> FindByEventoId(int eventoId)
        {
            List<InteresadosEventos> buscados =  new List<InteresadosEventos>();
            try
            {
                using (var db = new escuelapsdelsurContext())

                    //  Forma Linq - "Query Syntax"
                    //  var q = from a in db.Alumnos
                    //          join l in db.Legajos on a.AlumnoId equals l.AlumnoId
                    //          select new Inscriptos {AlumnoId = a.AlumnoId,
                    //                                 Nombre =  a.Nombre, 
                    //                                 Apellido = a.Apellido, 
                    //                                 Dni= a.Dni};

                {
                    foreach (var InteresadoEvento in from ie in db.InteresadosEventos
                                                        .Include(InteresadoEvento => InteresadoEvento.Evento)
                                                        .Include(InteresadoEvento => InteresadoEvento.Interesado)
                                                        where ie.Evento.Id==eventoId 
                                                        select ie)
                                                        
                    {
                        if (InteresadoEvento.Interesado !=null) 
                            buscados.Add(InteresadoEvento);
                    }
                    _logger.LogInformation("Buscar InteresadosEventos x EventoId " + eventoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return buscados.AsReadOnly();

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