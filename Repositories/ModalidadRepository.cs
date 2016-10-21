using System.Collections.Generic;
using System;
using WebCore.API.Models;

namespace WebCore.API.Models
{
    public interface IModalidadRepository
    {
        IEnumerable<Modalidad> GetAll();
        Modalidad Find(int id);
        void Add(Modalidad item);
        void Remove(int id);

    }
    public class ModalidadRepository : IModalidadRepository
    {
        private List<Modalidad> _list;

        public ModalidadRepository()
        {

            _list = new List<Modalidad>();
        }

        public void Add(Modalidad item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Modalidad Find(int id)
        {
            // return _list.Find(n=>n.ModalidadId==id);
            return _list.Find(n=>n.modalidad_id==id);
        }

        public IEnumerable<Modalidad> GetAll()
        {
          _list.Clear();
          try
          {
            using (var db = new EPSSContext())
            {
              foreach (var Modalidad in db.Modalidades)
                {
                    _list.Add(Modalidad);
                    //Console.WriteLine(Modalidad.Nombre);
                }
               Console.WriteLine("Buscar Modalidades --> OK");
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