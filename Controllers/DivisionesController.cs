using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class DivisionesController : Controller
    {
        private IRepository<Divisiones> _repo;
        
        public DivisionesController(IRepository<Divisiones> repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Divisiones> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetDivisiones")]
        public IActionResult GetById(int id)
        {
            var item = _repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Divisiones item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetDivisiones", new { controller = "Divisiones", id = item.CarreraId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}