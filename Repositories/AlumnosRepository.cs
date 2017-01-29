using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;

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
    public class AlumnosRepository : IAlumnosRepository
    {
        private List<Alumnos> _list;

        public AlumnosRepository()
        {

            _list = new List<Alumnos>();
        }

        public void Add(Alumnos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Alumnos Find(int id)
        {
            // return _list.Find(n=>n.AlumnosId==id);
            return _list.Find(n=>n.AlumnoId==id);
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
                    //Console.WriteLine(Alumnos.Nombre);
                }
               Console.WriteLine("Buscar Alumnos (2) --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            Console.WriteLine(ex.Message);
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