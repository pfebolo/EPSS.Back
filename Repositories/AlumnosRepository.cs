using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IAlumnosRepository
    {
        IEnumerable<Alumnos> GetAll();
        Alumnos Find(int id);
        void Add(Alumnos item);
        void Update(Alumnos item);
        void Remove(int id);

    }
    public class AlumnosRepository : BaseRepository, IAlumnosRepository
    {
        private List<Alumnos> _list;

        public AlumnosRepository(ILoggerFactory loggerFactory) : base(loggerFactory)
        {

            _list = new List<Alumnos>();
        }

        public void Add(Alumnos item)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    // Alumnos AlumnoNuevo;
                    // AlumnoNuevo = new Alumnos();
                    // AlumnoNuevo.AlumnoId = item.AlumnoId;
                    // AlumnoNuevo.Nombre = item.Nombre;
                    // AlumnoNuevo.Apellido = item.Apellido;
                    // AlumnoNuevo.Mail = item.Mail;
                    // AlumnoNuevo.Mail2 = item.Mail2;
                    // AlumnoNuevo.Telefono = item.Telefono;
                    // AlumnoNuevo.Celular = item.Celular;
                    // AlumnoNuevo.ComoConocio = item.ComoConocio;
                    // AlumnoNuevo.ModalidadId = item.ModalidadId;
                    // AlumnoNuevo.GradoInteres = item.GradoInteres;
                    // AlumnoNuevo.FechaInteresado = item.FechaInteresado;
                    // AlumnoNuevo.Comentario = item.Comentario;
                    // AlumnoNuevo.Provincia = item.Provincia;
                    // AlumnoNuevo.SituacionInscripcion = item.SituacionInscripcion;
                    // AlumnoNuevo.SituacionEspecial = item.SituacionEspecial;
                    // AlumnoNuevo.Dni = item.Dni;
                    // AlumnoNuevo.Domicilio = item.Domicilio;
                    // AlumnoNuevo.FechaInteresadoOriginal = item.FechaInteresadoOriginal;
                    // AlumnoNuevo.AnioAcursar = item.AnioAcursar;
                    // AlumnoNuevo.NmestreAcursar = item.NmestreAcursar;
                    // AlumnoNuevo.DocTitulo = item.DocTitulo;
                    // AlumnoNuevo.DocDni = item.DocDni;
                    // AlumnoNuevo.DocAptoFisico = item.DocAptoFisico;
                    // AlumnoNuevo.DocFoto = item.DocFoto;
                    // AlumnoNuevo.DocCompromiso = item.DocCompromiso;
                    int idInteresado = item.AlumnoId;
                    item.AlumnoId+=50000; //Numero magico para que no colisione con sistema anterior
                    db.Alumnos.Add(item);
                    //Borrar Interesados
                    Interesados interesadoABorrar= db.Interesados.Find(idInteresado);
                    if (interesadoABorrar != null)
                       db.Interesados.Remove(interesadoABorrar);
                    db.SaveChanges();

                    _logger.LogInformation("Crear Alumno (" + item.AlumnoId.ToString() + "), DNI:" + item.Dni.ToString() + "--> Ok");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public Alumnos Find(int id)
        {
            Alumnos AlumnoBuscado=null;
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    AlumnoBuscado =  db.Alumnos.Find(id);
                    _logger.LogInformation("Buscar AlumnoId: " + id.ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return AlumnoBuscado;
        }

        public IEnumerable<Alumnos> GetAll()
        {
            _list.Clear();
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    foreach (var Alumno in db.Alumnos.Include(a => a.Modalidad))
                    {
                        _list.Add(Alumno);
                    }
                    _logger.LogInformation("Buscar Alumnos (2) --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return _list.AsReadOnly();
        }


        public void Update(Alumnos item)
        {
            var db = new escuelapsdelsurContext();
            db.Update(item);
            db.SaveChanges();
        }


        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}