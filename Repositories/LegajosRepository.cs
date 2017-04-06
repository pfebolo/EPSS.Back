using System.Collections.Generic;
using System;
using EPSS.Models;
using Microsoft.EntityFrameworkCore;

namespace EPSS.Repositories
{
    public interface ILegajosRepository
    {
        IEnumerable<Legajos> GetAll();
        Legajos Find(int id);
        void Add(Legajos item);
        void Update(Legajos item);
        void Remove(int id);

    }
    public class LegajosRepository : ILegajosRepository
    {
        private List<Legajos> _list;
        private Boolean legajosCargados=false;

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
            if (!legajosCargados) 
               GetAll();
            Legajos legajo = _list.Find(n=>n.AlumnoId==id);   
            Console.WriteLine("Buscar Legajo ID: " + id.ToString() + "/ Legajo Nro: " + legajo.LegajoNro.ToString() + " --> OK");
            return legajo;
        }

        public IEnumerable<Legajos> GetAll()
        {
          _list.Clear();
          legajosCargados=false;
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
               legajosCargados=true;
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
 
        public void Update(Legajos item)
        {
            var db = new escuelapsdelsurContext();
            db.Update(item);
            db.SaveChanges();
            Console.WriteLine("Actualizar Legajo ID: " + item.AlumnoId.ToString() + "/ Legajo Nro: " + item.LegajoNro.ToString() + " --> OK");
        }
 
    }
}