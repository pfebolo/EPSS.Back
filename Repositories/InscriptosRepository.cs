using System.Collections.Generic;
using System;
using EPSS.Models;
using EPSS.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Repositories
{
    public interface IInscriptosRepository
    {
        IEnumerable<Inscriptos> GetAll();
        void Update(IEnumerable<Inscriptos> items);


    }
    public class InscriptosRepository : IInscriptosRepository
    {
        private List<Inscriptos> _list;

        public InscriptosRepository()
        {
            _list = new List<Inscriptos>();
        }

        public IEnumerable<Inscriptos> GetAll()
        {
            _list.Clear();
            try
            {
                using (var db = new escuelapsdelsurContext())
                {

                    //  Forma Linq - "Query Syntax"
                    //  var q = from a in db.Alumnos
                    //          join l in db.Legajos on a.AlumnoId equals l.AlumnoId
                    //          select new Inscriptos {AlumnoId = a.AlumnoId,
                    //                                 Nombre =  a.Nombre, 
                    //                                 Apellido = a.Apellido, 
                    //                                 Dni= a.Dni};


                    // Forma Linq - "Method Syntax"
                    // var q = db.Alumnos.Join(db.Legajos, a => a.AlumnoId, l => l.AlumnoId, (a, l) => new Inscriptos
                    // {
                    //     AlumnoId = a.AlumnoId,
                    //     Nombre = a.Nombre,
                    //     Apellido = a.Apellido,
                    //     Dni = a.Dni
                    // });

                    //  Forma Linq - "Query Syntax"
                    // var q = from a in db.Alumnos
                    //          where !db.Legajos.Any(l => l.AlumnoId == a.AlumnoId)
                    //          select new Inscriptos {AlumnoId = a.AlumnoId,
                    //                                  Nombre =  a.Nombre, 
                    //                                  Apellido = a.Apellido, 
                    //                                  Dni= a.Dni};

                    // Forma Linq - "Method Syntax"
                    var q = db.Alumnos.Where(a => !db.Legajos.Any(l => l.AlumnoId == a.AlumnoId)).Include(a => a.Modalidad).Select(a => new Inscriptos
                    {
                        AlumnoId = a.AlumnoId,
                        Nombre = a.Nombre,
                        Apellido = a.Apellido,
                        Dni = a.Dni,
                        Mail = a.Mail,
                        Mail2 = a.Mail2,
                        Telefono = a.Telefono,
                        Celular = a.Celular,
                        ComoConocio = a.ComoConocio,
                        ModalidadId = a.Modalidad.Nombre,
                        GradoInteres = a.GradoInteres,
                        FechaInteresado = a.FechaInteresado,
                        Comentario = a.Comentario,
                        Provincia = a.Provincia,
                        SituacionInscripcion = a.SituacionInscripcion,
                        SituacionEspecial = a.SituacionEspecial,
                        Domicilio = a.Domicilio


                    });


                    _list = q.ToList();

                    Console.WriteLine("Buscar Inscriptos--> OK");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return _list.AsReadOnly();
        }


        public void Update(IEnumerable<Inscriptos> items)
        {
            using (var db = new escuelapsdelsurContext())
            {
                Legajos LegajoNuevo;
                Boolean HayLegajosNuevos = false;
                int dniok = 0;
                foreach (var item in items)
                {
                    if (item.LegajoNro.HasValue)
                    {
                        LegajoNuevo = new Legajos();
                        LegajoNuevo.AlumnoId = item.AlumnoId;
                        LegajoNuevo.LegajoNro = item.LegajoNro.Value;
                        LegajoNuevo.Sexo = "Masculino";
                        LegajoNuevo.FechaNacimiento = DateTime.Today;
                        dniok = 0;
                        int.TryParse(item.Dni, out dniok);
                        LegajoNuevo.Dni = dniok;
                        LegajoNuevo.DireccionCalle = String.Empty;
                        LegajoNuevo.DireccionNro = String.Empty;


                        db.Legajos.Add(LegajoNuevo);
                        HayLegajosNuevos = true;
                    }
                }

                if (HayLegajosNuevos)
                    db.SaveChanges();
                Console.WriteLine("Inscriptos:Crear legajos--> Ok");
            }

        }
    }

}
