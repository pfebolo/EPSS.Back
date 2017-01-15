using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Repositories
{
    public interface ICoordinacionesRepository
    {
        IEnumerable<Coordinacion> GetAll();
        Coordinacion Find(int id);
        void Add(Coordinacion item);
        void Remove(int id);

    }
    public class CoordinacionesRepository : ICoordinacionesRepository
    {
        private List<Coordinacion> _list;

        public CoordinacionesRepository()
        {

            _list = new List<Coordinacion>();
        }

        public void Add(Coordinacion item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Coordinacion Find(int id)
        {
            // return _list.Find(n=>n.CoordinacionesId==id);
            return _list.Find(n=>n.PromocionId==id);
        }

        public IEnumerable<Coordinacion> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Coordinacion_ in db.Coordinacion  //TODO: Renombar Modelo Cordinacion x Coordinaciones
                                    .Include(Coordinacion => Coordinacion.Coordinador))
                {
                    _list.Add(Coordinacion_);
                    //Console.WriteLine(Coordinaciones.Nombre);
                }
               Console.WriteLine("Buscar Coordinaciones --> OK");
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