using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IModosRepository
    {
        IEnumerable<Modos> GetAll();
        Modos Find(string id);
        void Add(Modos item);
        void Update(Modos item);
        void Remove(string id);

    }
    public class ModosRepository: BaseRepository,IModosRepository
    {
        private List<Modos> _list;

        public ModosRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<Modos>();
        }

        public void Add(Modos item)
        {
            var db = new escuelapsdelsurContext();
            db.Add(item);
            db.SaveChanges();
        }

        public void Update(Modos item)
        {
            var db = new escuelapsdelsurContext();
            db.Update(item);
            db.SaveChanges();
        }

        public Modos Find(string id)
        {
            return _list.Find(n => n.ModoId == id);
        }

        public IEnumerable<Modos> GetAll()
        {
            _list.Clear();
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    //_list = db.Modos;
                    foreach (var Modo in db.Modos)
                    {
                        _list.Add(Modo);
                    }

                    _logger.LogInformation("Buscar Modos --> OK");
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