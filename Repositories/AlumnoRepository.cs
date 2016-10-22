using System.Collections.Generic;
using System;
using System.Linq;
using WebCore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace WebCore.API.Models
{
    public interface IAlumnoRepository
    {
        IEnumerable<Alumno> GetAll();
        Alumno Find(int id);
        void Add(Alumno item);
        void Remove(int id);

    }
    public class AlumnoRepository : IAlumnoRepository
    {
        private List<Alumno> _list;

        public AlumnoRepository()
        {

            _list = new List<Alumno>();
        }

        public void Add(Alumno item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Alumno Find(int id)
        {
            return _list.Find(n=>n.id==id);
        }

        public IEnumerable<Alumno> GetAll()
        {
          _list.Clear();
          try
          {
            Console.WriteLine("Buscar Alumnos --> Configura  contexto");
            using (var db = new EPSSContext())
            {
              Console.WriteLine("Buscar Alumnos --> Intenta abrir contexto y obtener alumnos de DB");
              foreach (var Alumno in db.Alumnos.Include(a => a.modalidad))
                {

                    //  Alumno.modalidad = new Modalidad();
                    // Alumno.modalidad.modalidad_id=2;
                    // Alumno.modalidad.Nombre = "Carrera a Distancia";
                    _list.Add(Alumno);
                    //Console.WriteLine(Alumno.Nombre);

                }
                // Console.WriteLine(_list.Count().ToString());
                // foreach(Alumno AlumnoX in _list)
                // {
                //      var ai = (int)AlumnoX.modalidad_id;
                //      var qm = db.Modalidades.Where(x => x.modalidad_id == ai);
                //      AlumnoX.modalidad = qm.First();
                //      //  Alumno.modalidad = new Modalidad();
                //      // Alumno.modalidad.modalidad_id=2;
                //      // Alumno.modalidad.Nombre = "Carrera a Distancia";
                //      // _list.Add(Alumno);
                //      Console.WriteLine(AlumnoX.nombre);

                //  }
                //  Console.WriteLine(_list.Count().ToString());
               
               Console.WriteLine("Buscar Alumnos --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}