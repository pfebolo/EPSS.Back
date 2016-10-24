using System.Collections.Generic;
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public interface IProvinciasRepository
    {
        IEnumerable<Provincias> GetAll();
        Provincias Find(string id);
        void Add(Provincias item);
        void Remove(string id);

    }
    public class ProvinciasRepository : IProvinciasRepository
    {
        private List<Provincias> _list;

        public ProvinciasRepository()
        {

            _list = new List<Provincias>();
        }

        public void Add(Provincias item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Provincias Find(string id)
        {
            // return _list.Find(n=>n.ProvinciasId==id);
            return _list.Find(n=>n.ProvinciaId==id);
        }

        public IEnumerable<Provincias> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Provincia in db.Provincias.Include(a => a.Pais))
                {
                    _list.Add(Provincia);
                    //Console.WriteLine(Provincias.Nombre);
                }
               Console.WriteLine("Buscar Provincias --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(string id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}