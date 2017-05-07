using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IInteresadosRepository
    {
        IEnumerable<Interesados> GetAll();
        Interesados Find(int id);
        void Add(Interesados item);
        void Update(Interesados item);
        void Remove(int id);

    }
    public class InteresadosRepository: BaseRepository,IInteresadosRepository
    {
        private List<Interesados> _list;

        public InteresadosRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Interesados>();
        }

        public void Add(Interesados item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Interesados Find(int id)
        {
            // return _list.Find(n=>n.InteresadosId==id);
            return _list.Find(n=>n.InteresadoId==id);
        }

        public IEnumerable<Interesados> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Interesado in db.Interesados.Include(a => a.Modalidad))
                {
                    _list.Add(Interesado);
                }
               _logger.LogInformation("Buscar Interesados --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            _logger.LogError(ex.Message);
          }
          return _list.AsReadOnly();
        }


        public void Update(Interesados item)
        {
            var db = new escuelapsdelsurContext();
            db.Update(item);
            db.SaveChanges();
        }


        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}