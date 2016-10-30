using System.Collections.Generic;
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public interface ILegajosRepository
    {
        IEnumerable<Legajos> GetAll();
        Legajos Find(int id);
        void Add(Legajos item);
        void Remove(int id);

    }
    public class LegajosRepository : ILegajosRepository
    {
        private List<Legajos> _list;

        public LegajosRepository()
        {

            _list = new List<Legajos>();
        }

        public void Add(Legajos item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Legajos Find(int id)
        {
            // return _list.Find(n=>n.LegajosId==id);
            return _list.Find(n=>n.AlumnoId==id);
        }

        public IEnumerable<Legajos> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new escuelapsdelsurContext())
            {
              foreach (var Legajo in db.Legajos
                                        .Include(Legajo => Legajo.Alumno)
                                        .Include(Legajo => Legajo.Localidad)
                                            .ThenInclude(Localidad => Localidad.CodigoPostal)
                                        .Include(Legajo => Legajo.Localidad)
                                            .ThenInclude(Localidad => Localidad.Partido)
                                        .Include(Legajo => Legajo.Estudios))
                {
                    _list.Add(Legajo);
                    //Console.WriteLine(Legajos.Nombre);
                }
               Console.WriteLine("Buscar Legajos --> OK");
              }             
          }
            catch (System.Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
          return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}