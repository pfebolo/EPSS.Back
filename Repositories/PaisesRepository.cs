using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IPaisesRepository
    {
        IEnumerable<Paises> GetAll();
        Paises Find(string id);
        void Add(Paises item);
        void Remove(string id);

    }
    public class PaisesRepository: BaseRepository,IPaisesRepository
    {
        private List<Paises> _list;

        public PaisesRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Paises>();
        }

        public void Add(Paises item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Paises Find(string id)
        {
            // return _list.Find(n=>n.PaisesId==id);
            return _list.Find(n=>n.PaisId==id);
        }

        public IEnumerable<Paises> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Pais in db.Paises)
                {
                    _list.Add(Pais);
                }
               _logger.LogInformation("Buscar Paises --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            _logger.LogError(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(string id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}