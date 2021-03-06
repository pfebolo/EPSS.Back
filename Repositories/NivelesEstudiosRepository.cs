using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface INivelesEstudiosRepository
    {
        IEnumerable<NivelesEstudios> GetAll();
        NivelesEstudios Find(string id);
        void Add(NivelesEstudios item);
        void Remove(string id);

    }
    public class NivelesEstudiosRepository: BaseRepository,INivelesEstudiosRepository
    {
        private List<NivelesEstudios> _list;

        public NivelesEstudiosRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<NivelesEstudios>();
        }

        public void Add(NivelesEstudios item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public NivelesEstudios Find(string id)
        {
            // return _list.Find(n=>n.NivelesEstudiosId==id);
            return _list.Find(n=>n.NivelEstudioId==id);
        }

        public IEnumerable<NivelesEstudios> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              //_list = db.NivelesEstudios;
              foreach (var  Nivel in db.NivelesEstudios)
                {
                    _list.Add(Nivel);
                }

               _logger.LogInformation("Buscar NivelesEstudios --> OK");
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