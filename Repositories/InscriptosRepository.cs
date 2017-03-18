using System.Collections.Generic;
using System;
using EPSS.Models;
using EPSS.DTOs;

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
                    foreach (var alumno in db.Alumnos)
                    {
                        Inscriptos inscripto = new Inscriptos();
                        inscripto.AlumnoId = alumno.AlumnoId;
                        inscripto.Nombre = alumno.Nombre;
                        inscripto.Apellido = alumno.Apellido;
                        _list.Add(inscripto);
                    }
                    Console.WriteLine("Buscar Inscriptos--> OK");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
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