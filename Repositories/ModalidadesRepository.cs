using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IModalidadesRepository
    {
        IEnumerable<Modalidades> GetAll();
        Modalidades Find(int id);
        void Add(Modalidades item);
        void Remove(int id);

    }
    public class ModalidadesRepository: BaseRepository,IModalidadesRepository
    {
        private List<Modalidades> _list;

        public ModalidadesRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Modalidades>();
        }

        public void Add(Modalidades item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Modalidades Find(int id)
        {
            // return _list.Find(n=>n.ModalidadesId==id);
            return _list.Find(n=>n.Id==id);
        }

        public IEnumerable<Modalidades> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Localidad in db.Modalidades)
                {
                    _list.Add(Localidad);
                }
               _logger.LogInformation("Buscar Modalidades --> OK");
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