using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public class LugaresRepository: BaseRepositoryNew<Lugares>
    {

        public LugaresRepository(ILoggerFactory loggerFactory) : base (loggerFactory){}
        public override Lugares Find(params Object[] KeyValues)
        {
            Lugares ItemBuscado = null;
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    ItemBuscado = db.Lugares.Find(KeyValues);
                    _logger.LogInformation("Buscar LugarId: " + KeyValues.ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
            return ItemBuscado;
        }

        public override IEnumerable<Lugares> GetAll()
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

        public override void Update(Lugares item)
        {
            try
            {
                using (var db = new escuelapsdelsurContext())
                {
                    db.Update(item);
                    db.SaveChanges();
                    //_logger.LogInformation("Actualizar Evento ID: " + item.Id.ToString() + " --> OK");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }

        }


    }
}