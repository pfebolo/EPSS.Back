using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace EPSS.Repositories
{

    public class InscriptoInexistenteException : System.Exception
    {
        public InscriptoInexistenteException() { }
        public InscriptoInexistenteException(string message) : base(message) { }
        public InscriptoInexistenteException(string message, System.Exception inner) : base(message, inner) { }

    }

    public interface IAlumnosRepository
    {
        IEnumerable<Alumnos> GetAll();
        Alumnos Find(int id);
        void Add(Alumnos item);
        void Update(Alumnos item);
        void Remove(Alumnos item);

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
                    item.Mail2="Enviar"; //Marca el envio de E-mail de bienvenida y completado de cuestionario.
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
            Alumnos valorOriginal =  db.Alumnos.Find(item.AlumnoId);
            item.Mail2 = valorOriginal.Mail2;
            db.Entry(valorOriginal).State=EntityState.Detached;
            db.Update(item);
            db.SaveChanges();
        }

        public void Remove(Alumnos item)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {

                    int legajo = db.Legajos.Count(n => n.AlumnoId == item.AlumnoId);
                    if (legajo==0) {


                    Interesados interesado = new Interesados();
                    //interesado.InteresadoId = item.AlumnoId-50000;
                    interesado.Nombre = item.Nombre;
                    interesado.Apellido = item.Apellido;
                    interesado.Mail = item.Mail;
                    interesado.Mail2 = item.Mail2;
                    interesado.Telefono = item.Telefono;
                    interesado.Celular = item.Celular;
                    interesado.ComoConocio = item.ComoConocio;
                    interesado.ModalidadId = item.ModalidadId;
                    interesado.GradoInteres = item.GradoInteres;
                    interesado.FechaInteresado = item.FechaInteresadoOriginal;
                    interesado.Comentario = item.Comentario;
                    interesado.Provincia = item.Provincia;
                    interesado.SituacionInscripcion = item.SituacionInscripcion;
                    interesado.SituacionEspecial = item.SituacionEspecial;
                    interesado.CarreraId = 0; //TODO: Este dato se pierde ¿?
                    interesado.AnioAcursar = item.AnioAcursar;
                    interesado.NmestreAcursar = item.NmestreAcursar;
                    interesado.Turno = item.Turno;
                    interesado.Seguimiento = false;
                    interesado.MedioDeContactoId = 12; //TODO: Este dato se pierde ¿?
                    db.Remove(item);
                    db.Interesados.Add(interesado);
                    db.SaveChanges();
                    _logger.LogInformation("Eliminado Inscripto ID: " + item.AlumnoId.ToString() + " --> OK");
                    _logger.LogInformation("Re-Creando Interesado ID: " + interesado.InteresadoId.ToString() + " --> OK");
                    }
                    else
                    {
                     throw new InscriptoInexistenteException("El Inscripto ID: " + item.AlumnoId.ToString() + " tiene legajo asignado.");
                   }
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