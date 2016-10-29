// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using WebCore.API.Models;

// namespace WebCore.API.Controllers
// {
//     [Route("api/[controller]")]
//     public class BlogController : Controller
//     {
//         private IBlogRepository _repo;
//         public BlogController(IBlogRepository repo)
//         {
//             this._repo = repo;
//         }


//         [HttpGet]
//         public IEnumerable<Blog> GetAll()
//         {
//             return _repo.GetAll();
//         }

//         [HttpGet("{id}", Name = "GetBlog")]
//         public IActionResult GetById(int id)
//         {
//             var item = _repo.Find(id);
//             if (item == null)
//             {
//                 return NotFound();
//             }
//             return new ObjectResult(item);
//         }

//         [HttpPost]
//         public IActionResult Create([FromBody] Blog item)
//         {
//             if (item == null)
//             {
//                 return BadRequest();
//             }
//             _repo.Add(item);
//             return CreatedAtRoute("GetBlog", new { controller = "Blog", BlogId = item.BlogId }, item);
//         }

//         [HttpDelete("{id}")]
//         public void Delete(int id)
//         {
//             _repo.Remove(id);
//         }
//     }
// }