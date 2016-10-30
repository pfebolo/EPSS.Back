using System.Collections.Generic;
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public interface IEstudiosRepository
    {
        IEnumerable<Estudios> GetAll();
        Estudios Find(int id);
        void Add(Estudios item);
        void Remove(int id);

    }
    public class EstudiosRepository : IEstudiosRepository
    {
        private List<Estudios> _list;

        public EstudiosRepository()
        {

            _list = new List<Estudios>();
        }

        public void Add(Estudios item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Estudios Find(int id)
        {
            // return _list.Find(n=>n.EstudiosId==id);
            return _list.Find(n=>n.AlumnoId==id);
        }

        public IEnumerable<Estudios> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Estudio in db.Estudios)
                {
                    _list.Add(Estudio);
                    //Console.WriteLine(Estudios.Nombre);
                }
               Console.WriteLine("Buscar Estudios --> OK");
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