using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace EPSS.Controllers
{
    [Route("api/[controller]")]
    public class EstudiosController : Controller
    {
        private IEstudiosRepository _repo;
        
        public EstudiosController(IEstudiosRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Estudios> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetEstudios")]
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
        public IActionResult Create([FromBody] Estudios item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetEstudios", new { controller = "Estudios", EstudioId = item.EstudioId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}