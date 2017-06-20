using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface ILugaresRepository
    {
        IEnumerable<Lugares> GetAll();
        Lugares Find(int id);
        void Add(Lugares item);
        void Remove(int id);

    }
    public class LugaresRepository: BaseRepository,ILugaresRepository
    {
        private List<Lugares> _list;

        public LugaresRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Lugares>();
        }

        public void Add(Lugares item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Lugares Find(int id)
        {
            // return _list.Find(n=>n.LugaresId==id);
            return _list.Find(n=>n.Id==id);
        }

        public IEnumerable<Lugares> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Lugar in db.Lugares)
                {
                    _list.Add(Lugar);
                }
               _logger.LogInformation("Buscar Lugares --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            _logger.LogError(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}