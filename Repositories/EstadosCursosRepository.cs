using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.Extensions.Logging;

namespace EPSS.Repositories
{
    public interface IEstadosCursosRepository
    {
        IEnumerable<EstadosCurso> GetAll();
        EstadosCurso Find(int id);
        void Add(EstadosCurso item);
        void Remove(int id);

    }
    public class EstadosCursosRepository: BaseRepository,IEstadosCursosRepository
    {
        private List<EstadosCurso> _list;

        public EstadosCursosRepository(ILoggerFactory loggerFactory) : base (loggerFactory)
        {

            _list = new List<EstadosCurso>();
        }

        public void Add(EstadosCurso item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public EstadosCurso Find(int id)
        {
            // return _list.Find(n=>n.EstadosCursosId==id);
            return _list.Find(n=>n.EstadoCursoId==id);
        }

        public IEnumerable<EstadosCurso> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var EstadoCurso in db.EstadosCurso)
                {
                    _list.Add(EstadoCurso);
                }
               _logger.LogInformation("Buscar EstadosCurso --> OK");
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