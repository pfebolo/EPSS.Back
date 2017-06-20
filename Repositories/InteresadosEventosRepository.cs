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
        IEnumerable<InteresadosEventos> FindByInteresadoId(int interesadoId);
        void Add(InteresadosEventos item);
        void Remove(InteresadosEventos item);
        void Update(InteresadosEventos item);


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
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    db.InteresadosEventos.Add(item);
                    db.SaveChanges();

                    _logger.LogInformation("Crear InteresadoEvento (" + item.Id.ToString() + ") --> Ok");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public InteresadosEventos Find(int id)
        {
            InteresadosEventos item = null;
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    item = db.InteresadosEventos.Find(id);
                    _logger.LogInformation("Buscar InteresadoEventoId: " + id.ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            return item;
        }


        public IEnumerable<InteresadosEventos> FindByEventoId(int eventoId)
        {
            List<InteresadosEventos> buscados = new List<InteresadosEventos>();
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
                                                     where ie.Evento.Id == eventoId
                                                     select ie)
                    {
                        if (InteresadoEvento.Interesado != null)
                            buscados.Add(InteresadoEvento);
                    }
                    _logger.LogInformation("Buscar InteresadosEventos x EventoId " + eventoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            return buscados.AsReadOnly();

        }

        public IEnumerable<InteresadosEventos> FindByInteresadoId(int interesadoId)
        {
            List<InteresadosEventos> buscados = new List<InteresadosEventos>();
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    foreach (var InteresadoEvento in from ie in db.InteresadosEventos
                                                        .Include(InteresadoEvento => InteresadoEvento.Evento)
                                                        .Include(InteresadoEvento => InteresadoEvento.Interesado)
                                                     where ie.Interesado.InteresadoId == interesadoId
                                                     select ie)
                    {
                        buscados.Add(InteresadoEvento);
                    }
                    _logger.LogInformation("Buscar InteresadosEventos x InteresadoId " + interesadoId.ToString() + ", cantidad:" + buscados.Count().ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
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
                    //foreach (var InteresadoEvento in db.InteresadosEventos)
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
                throw ex;
            }
            return _list.AsReadOnly();
        }

        public void Remove(InteresadosEventos item)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    db.Remove(item);
                    db.SaveChanges();
                    _logger.LogInformation("Eliminado InteresadoEvento ID: " + item.Id.ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public void Update(InteresadosEventos item)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    db.Update(item);
                    db.SaveChanges();
                    _logger.LogInformation("Actualizar InteresadoEvento ID: " + item.Id.ToString() + " --> OK");
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