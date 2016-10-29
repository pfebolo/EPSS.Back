using System.Collections.Generic;
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public interface ILocalidadesRepository
    {
        IEnumerable<Localidades> GetAll();
        Localidades Find(int id);
        void Add(Localidades item);
        void Remove(int id);

    }
    public class LocalidadesRepository : ILocalidadesRepository
    {
        private List<Localidades> _list;

        public LocalidadesRepository()
        {

            _list = new List<Localidades>();
        }

        public void Add(Localidades item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Localidades Find(int id)
        {
            // return _list.Find(n=>n.LocalidadesId==id);
            return _list.Find(n=>n.LocalidadId==id);
        }

        public IEnumerable<Localidades> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Localidad in db.Localidades.Include(Localidad => Localidad.Partido).Include(Localidad => Localidad.CodigoPostal))
                {
                    _list.Add(Localidad);
                    //Console.WriteLine(Localidades.Nombre);
                }
               Console.WriteLine("Buscar Localidades --> OK");
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