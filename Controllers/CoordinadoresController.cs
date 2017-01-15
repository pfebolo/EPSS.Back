using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EPSS.Models;
using EPSS.Repositories;

namespace WebCore.API.Controllers
{
    [Route("api/[controller]")]
    public class CoordinadoresController : Controller
    {
        private ICoordinadoresRepository _repo;
        
        public CoordinadoresController(ICoordinadoresRepository repo)
        {
            this._repo = repo;
        }


        [HttpGet]
        public IEnumerable<Coordinadores> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}", Name = "GetCoordinadores")]
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
        public IActionResult Create([FromBody] Coordinadores item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repo.Add(item);
            return CreatedAtRoute("GetCoordinadores", new { controller = "Coordinadores", CoordinadorId = item.CoordinadorId }, item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Remove(id);
        }
    }
}