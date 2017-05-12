using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IProvinciasRepository
    {
        IEnumerable<Provincias> GetAll();
        Provincias Find(string id);
        void Add(Provincias item);
        void Remove(string id);

    }
    public class ProvinciasRepository: BaseRepository,IProvinciasRepository
    {
        private List<Provincias> _list;

        public ProvinciasRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
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
                }
               _logger.LogInformation("Buscar Provincias --> OK");
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