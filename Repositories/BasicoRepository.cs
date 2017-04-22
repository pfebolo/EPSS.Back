using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IBasicoRepository
    {
        IEnumerable<Basico> GetAll();
        Basico Find(int id);
        void Add(Basico item);
        void Remove(int id);

    }
    public class BasicoRepository: BaseRepository,IBasicoRepository
    {
        private List<Basico> _list;

        public BasicoRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Basico>();
        }

        public void Add(Basico item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Basico Find(int id)
        {
            // return _list.Find(n=>n.BasicoId==id);
            return _list.Find(n => n.Basico_id == id);
        }

        public IEnumerable<Basico> GetAll()
        {
            _list.Clear();
            try
            {
                Basico b = new Basico();
                _list.Add(b);
                _logger.LogInformation("Buscar Basico --> OK");
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