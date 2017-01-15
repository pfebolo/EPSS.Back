using System.Collections.Generic;
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Repositories
{
    public interface ICursosRepository
    {
        IEnumerable<Cursos> GetAll();
        Cursos Find(int id);
        void Add(Cursos item);
        void Remove(int id);

    }
    public class CursosRepository : ICursosRepository
    {
        private List<Cursos> _list;

        public CursosRepository()
        {

            _list = new List<Cursos>();
        }

        public void Add(Cursos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Cursos Find(int id)
        {
            // return _list.Find(n=>n.CursosId==id);
            return _list.Find(n=>n.CursoId==id);
        }

        public IEnumerable<Cursos> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Curso in db.Cursos.Include(a => a.EstadoCurso))
                {
                    _list.Add(Curso);
                    //Console.WriteLine(Cursos.Nombre);
                }
               Console.WriteLine("Buscar Cursos --> OK");
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