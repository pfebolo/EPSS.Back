using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface ICoordinacionesRepository
    {
        IEnumerable<Coordinacion> GetAll();
        Coordinacion Find(int id);
        void Add(Coordinacion item);
        void Remove(int id);

    }
    public class CoordinacionesRepository: BaseRepository,ICoordinacionesRepository
    {
        private List<Coordinacion> _list;

        public CoordinacionesRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
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
                }
               _logger.LogInformation("Buscar Coordinaciones --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            _logger.LogInformation(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}