using System.Collections.Generic;

namespace WebCore.API.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();
        Blog Find(int id);
        void Add(Blog item);
        void Remove(int id);

    }
    public class BlogRepository : IBlogRepository
    {
        private List<Blog> _list;

        public BlogRepository()
        {
            _list = new List<Blog>();
        }

        public void Add(Blog item)
        {
            //item.Key=(_list.Count+1).ToString();
            //_list.Add(item);
        }

        public Blog Find(int id)
        {
            return _list.Find(n=>n.BlogId==id);
        }

        public IEnumerable<Blog> GetAll()
        {

          _list.Clear();  
          using (var db = new BloggingContext())
          {
              foreach (var blog in db.Blogs)
              {
                  _list.Add(blog);
              }

          }

          return _list.AsReadOnly();
        }

        public void Remove(int id)
        {
            //_list.RemoveAll(n=>n.Key==id);
        }
    }
}