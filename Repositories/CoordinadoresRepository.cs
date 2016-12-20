using System.Collections.Generic;
using System;
using WebCore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public interface ICoordinadoresRepository
    {
        IEnumerable<Coordinadores> GetAll();
        Coordinadores Find(int id);
        void Add(Coordinadores item);
        void Remove(int id);

    }
    public class CoordinadoresRepository : ICoordinadoresRepository
    {
        private List<Coordinadores> _list;

        public CoordinadoresRepository()
        {

            _list = new List<Coordinadores>();
        }

        public void Add(Coordinadores item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Coordinadores Find(int id)
        {
            // return _list.Find(n=>n.CoordinadoresId==id);
            return _list.Find(n=>n.CoordinadorId==id);
        }

        public IEnumerable<Coordinadores> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Coordinador in db.Coordinadores)
                {
                    _list.Add(Coordinador);
                    //Console.WriteLine(Coordinadores.Nombre);
                }
               Console.WriteLine("Buscar Coordinadores --> OK");
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