using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface ICodigosPostalesRepository
    {
        IEnumerable<CodigosPostales> GetAll();
        CodigosPostales Find(int id);
        void Add(CodigosPostales item);
        void Remove(int id);

    }
    public class CodigosPostalesRepository: BaseRepository,ICodigosPostalesRepository
    {
        private List<CodigosPostales> _list;

        public CodigosPostalesRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<CodigosPostales>();
        }

        public void Add(CodigosPostales item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public CodigosPostales Find(int id)
        {
            // return _list.Find(n=>n.CodigosPostalesId==id);
            return _list.Find(n=>n.CodigoPostalId==id);
        }

        public IEnumerable<CodigosPostales> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var CodigoPostal in db.CodigosPostales.Include(CodigoPostal => CodigoPostal.Pais))
                {
                    _list.Add(CodigoPostal);
                }
               _logger.LogInformation("Buscar CodigosPostales --> OK");
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