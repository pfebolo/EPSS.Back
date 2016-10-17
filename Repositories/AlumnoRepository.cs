using System.Collections.Generic;
using System;
using WebCore.API.Models;

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
            using (var db = new EPSSContext())
            {
              foreach (var Alumno in db.Alumnos)
                {
                    _list.Add(Alumno);
                    //Console.WriteLine(Alumno.Nombre);
                }
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