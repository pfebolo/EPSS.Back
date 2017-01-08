using System.Collections.Generic;
using System;

namespace API.Models
{
    public interface IModalidadesRepository
    {
        IEnumerable<Modalidades> GetAll();
        Modalidades Find(int id);
        void Add(Modalidades item);
        void Remove(int id);

    }
    public class ModalidadesRepository : IModalidadesRepository
    {
        private List<Modalidades> _list;

        public ModalidadesRepository()
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
                    //Console.WriteLine(Modalidades.Nombre);
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