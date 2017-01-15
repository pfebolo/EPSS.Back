using System.Collections.Generic;
using System;
using EPSS.Models;

namespace EPSS.Repositories
{
    public interface IBasicoRepository
    {
        IEnumerable<Basico> GetAll();
        Basico Find(int id);
        void Add(Basico item);
        void Remove(int id);

    }
    public class BasicoRepository : IBasicoRepository
    {
        private List<Basico> _list;

        public BasicoRepository()
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
                //Console.WriteLine(Basico.Nombre);
                Console.WriteLine("Buscar Basico --> OK");
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