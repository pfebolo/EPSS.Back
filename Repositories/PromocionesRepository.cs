using System.Collections.Generic;
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public interface IPromocionesRepository
    {
        IEnumerable<Promociones> GetAll();
        Promociones Find(int id);
        void Add(Promociones item);
        void Remove(int id);

    }
    public class PromocionesRepository : IPromocionesRepository
    {
        private List<Promociones> _list;

        public PromocionesRepository()
        {

            _list = new List<Promociones>();
        }

        public void Add(Promociones item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Promociones Find(int id)
        {
            // return _list.Find(n=>n.PromocionesId==id);
            return _list.Find(n=>n.PromocionId==id);
        }

        public IEnumerable<Promociones> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Promocion in db.Promociones)
                {
                    _list.Add(Promocion);
                    //Console.WriteLine(Promociones.Nombre);
                }
               Console.WriteLine("Buscar Promociones --> OK");
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