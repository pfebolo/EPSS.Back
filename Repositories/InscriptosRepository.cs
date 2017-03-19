using System.Collections.Generic;
using System;
using EPSS.Models;
using EPSS.DTOs;
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

                    List<Alumnos> listAlumnos = new List<Alumnos>();
                    foreach (var alumno in db.Alumnos)
                    {
                        listAlumnos.Add(alumno);
                    }


                    foreach (var insc in listAlumnos)
                    {

                        db.Entry(insc).Reference(b => b.Legajos).Load();

                        if (insc.Legajos == null)
                        {
                            Inscriptos inscripto = new Inscriptos();
                            inscripto.AlumnoId = insc.AlumnoId;
                            inscripto.Nombre = insc.Nombre;
                            inscripto.Apellido = insc.Apellido;
                            inscripto.Dni = insc.Dni;
                            
                            _list.Add(inscripto);
                        }
                    }


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