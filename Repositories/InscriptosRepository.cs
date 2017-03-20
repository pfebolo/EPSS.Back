using System.Collections.Generic;
using System;
using EPSS.Models;
using EPSS.DTOs;
using System.Linq;
//using Microsoft.EntityFrameworkCore;




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
                    var q = db.Alumnos.Where(a => !db.Legajos.Any(l => l.AlumnoId == a.AlumnoId)).Select(a => new Inscriptos
                     {
                         AlumnoId = a.AlumnoId,
                         Nombre = a.Nombre,
                         Apellido = a.Apellido,
                         Dni = a.Dni
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
            // var db = new escuelapsdelsurContext();
            // db.Update(item);
            // db.SaveChanges();
        }

    }
}